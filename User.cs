using System;

namespace Libs
{
    public class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public User(string userID, string name, string phoneNumber, string password)
        {
            UserID = userID;
            Name = name;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public virtual void Register()
        {
            Console.WriteLine($"{Name} đã đăng ký thành công.");
        }

        public virtual bool Login(string password)
        {
            return this.Password == password;
        }

        public virtual string UpdateProfile()
        {
            return "Thông tin người dùng đã được cập nhật.";
        }
    }
}