using MVVMFirstTry.DataContext;
using MVVMFirstTry.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MVVMFirstTry.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public UserViewModel()
        {
            User = new User();
            UserList = new ObservableCollection<User>();
            using (var db = new UserDataContext())
            {

                foreach (var user in db.Users.OrderBy(u => u.Id))
                {
                    UserList.Add(user);
                }
                _id = db.GetSequenceValue();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private int ? _id;
        private void OnPropertyChanged(string s)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged("User"); }
        }
        private User selectedUser;
        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        private ObservableCollection<User> _userlist;
        public ObservableCollection<User> UserList
        {
            get
            {
                return _userlist;
            }
            set
            {
                _userlist = value;
                OnPropertyChanged("UserList");
            }
        }
        private ICommand addcommand;
        public ICommand AddCommand
        {
            get
            {
                if (addcommand == null)
                {
                    addcommand = new CommandHandler(AddNewUser, CanAdd, false);
                }
                return addcommand;
            }
        }
        private void AddNewUser(object param)
        {
            using (var db = new UserDataContext())
            {
                User saveItem = new User();
                _id++;
                saveItem.Id = (int)_id;
                saveItem.Username = User.Username;
                saveItem.Password = User.Password;
                db.Users.Add(saveItem);
                UserList.Add(saveItem);
                var xx = db.SaveChanges();

            }
            User = new User();
        }
        private bool CanAdd(object para)
        {
            if (string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(User.Password))
            {
                if (UserList.Count == 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new CommandHandler(UpdateUser, CanUpdate, false);
                }
                return updateCommand;
            }
        }
        private void UpdateUser(object param)
        {
            if(selectedUser != null)
            {
                using (var db = new UserDataContext())
                {
                    selectedUser.Username=User.Username;
                    selectedUser.Password=User.Password;
                    var item = UserList.FirstOrDefault(i => i.Id == selectedUser.Id);
                    if (item != null)
                    {
                        item = selectedUser;
                    }
                    db.Update(selectedUser);
                    db.SaveChanges();
                }
            }

        }
        private bool CanUpdate(object para)
        {
            if (string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(User.Password)||SelectedUser==null)
            {
                if (UserList.Count == 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new CommandHandler(DeleteUser, CanDelete, false);
                }
                return deleteCommand;
            }
        }
        private void DeleteUser(object param)
        {
            using (var db = new UserDataContext())
            {
                db.Users.Remove(SelectedUser);
                UserList.Remove(SelectedUser);
                var xx = db.SaveChanges();
            }
        }
        private bool CanDelete(object para)
        {
            if (selectedUser != null)
            {
                return true;
            }
            return false;
        } 
    }
}
