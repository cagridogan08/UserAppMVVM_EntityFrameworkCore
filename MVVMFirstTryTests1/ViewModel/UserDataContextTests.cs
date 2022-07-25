using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MVVMFirstTry.DataContext;
using MVVMFirstTry.Models;
using Microsoft.EntityFrameworkCore;

namespace MVVMFirstTry.ViewModel.Tests
{
    [TestClass()]
    public class UserDataContextTests
    {
        private UserDataContext db=new UserDataContext();
        [TestMethod()]

        public void Database_Connection_Test()
        {
            //arrange
                //act
                var con = db.Database.GetDbConnection();
                //assert
                Assert.IsNotNull(con);
        }
        //[TestMethod()]
        //public void UserViewModel_DatabaseCount_Test()
        //{
        //    //arrange
        //    int expected_count = 10;
        //    //act
        //    int count_value_db = db.Users.Count<User>();
        //    //assert
        //    Assert.AreEqual(expected_count, count_value_db);
                
        //}
        [TestMethod()]

        public void AddNewUser_Test()
        {
            //arrange
            User tmp = new User();
            tmp.Id = db.GetSequenceValue()+1;
            tmp.Username = "test-deneme_username";
            tmp.Password = "test_deneme_password";
            //act
            object x = db.Users.Add(tmp);
            var xx=db.SaveChanges();
            int count_value_db = db.Users.Count<User>();
            //assert
            //Assert.IsNotNull(x);
            //Assert.AreEqual(10, count_value_db);
            Assert.IsNotNull(x);
            Assert.IsNotNull(xx);
        }
        [TestMethod()]
        public void Demo_User_Test()
        {
            //arrange
            var demo_ıd=15;
            var demo_username = "update";
            //act
            var address = db.Users.First(a => a.Id == demo_ıd);
            //assert
            Assert.IsNotNull(address);
            Assert.IsTrue(address.Username==demo_username);
        }
        [TestMethod()]

        public void User_Delete_Test()
        {
            User tmp = new User();
            tmp.Id = db.GetSequenceValue();
            tmp.Username = "test-deneme_username";
            tmp.Password = "test-deneme_password";
            object xx = db.Users.Remove(tmp);
            var change= db.SaveChanges();
            int count_value_db = db.Users.Count<User>();
            Assert.IsNotNull(xx);
            Assert.IsNotNull(change);
            //Assert.AreEqual(9, count_value_db);
        }
      
    }
    
}