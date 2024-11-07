using System;
using System.Collections.Generic;

namespace Libs
{
    public class Admin : User
    {
        private List<Customer> customers;
        private List<Driver> drivers;
        private List<Booking> bookings;

        public Admin(string userID, string name, string phoneNumber, string password)
            : base(userID, name, phoneNumber, password)
        {
            customers = new List<Customer>();
            drivers = new List<Driver>();
            bookings = new List<Booking>();
        }

        public override void Register()
        {
            Console.WriteLine($"Quản trị viên {Name} đã đăng ký thành công.");
        }

        public void DeleteCustomer(string userID)
        {
            Console.WriteLine($"Tài khoản khách hàng với ID {userID} đã bị xóa.");
        }

        public void SuspendCustomer(string userID)
        {
            Console.WriteLine($"Tài khoản khách hàng với ID {userID} đã bị tạm dừng.");
        }

        public void AddDriver(Driver driver)
        {
            drivers.Add(driver);
            Console.WriteLine($"Tài xế {driver.Name} đã được thêm thành công.");
        }

        public void RemoveDriver(string userID)
        {
            Console.WriteLine($"Tài xế với ID {userID} đã bị xóa.");
        }

        public void CancelBooking(string bookingID)
        {
            Console.WriteLine($"Đặt xe với ID {bookingID} đã bị hủy.");
        }

        public void DisplayRevenue()
        {
            Console.WriteLine("Doanh thu hiện tại là: ...");
        }

        public void GenerateReport()
        {
            Console.WriteLine("Báo cáo: Tổng số tiền đã thu được và tổng số chuyến xe đã đặt.");
        }
    }
}