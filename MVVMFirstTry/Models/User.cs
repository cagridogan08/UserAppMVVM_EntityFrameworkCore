using System.ComponentModel;
namespace MVVMFirstTry.Models
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string s)
        {
            
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
        private int id;
        public int Id { get { return id; } set { id = value;OnPropertyChanged(nameof(Id)); } }
        private string? username;
        private string? password;
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }
        public string Password
        {
            get{ return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
        public override string ToString()
        {
            return username+":"+password;
        }
    }
}
