using System;
using System.Collections.Generic;

namespace Libs
{
    public class Customer : User
    {
        public bool AccountLinked { get; set; }
        public bool IsSuspended { get; set; }
        public double EWalletBalance { get; set; }
        private List<Booking> bookingHistory;

        public Customer(string userID, string name, string phoneNumber, string password)
            : base(userID, name, phoneNumber, password)
        {
            AccountLinked = false;
            IsSuspended = false;
            EWalletBalance = 300000000;
            bookingHistory = new List<Booking>();
        }

        public override void Register()
        {
            Console.WriteLine($"Khách hàng {Name} đã đăng ký thành công.");
        }

        public override bool Login(string password)
        {
            return this.Password == password && !IsSuspended;
        }

        public Booking BookRide()
        {
            if (IsSuspended)
            {
                Console.WriteLine("Tài khoản của bạn đã bị tạm dừng. Không thể đặt xe.");
                return null;
            }

            Console.WriteLine("Chọn tuyến đường:");
            Console.WriteLine("1. Vinhomes đến ĐH FPT (7km)");
            Console.WriteLine("2. ĐH FPT về Vinhomes (9km)");
            int choice = int.Parse(Console.ReadLine());

            double distance = 0;
            switch (choice)
            {
                case 1:
                    distance = 7;
                    break;
                case 2:
                    distance = 9;
                    break;
                default:
                    Console.WriteLine("Tuyến đường không hợp lệ.");
                    return null;
            }

            double fare = CalculateFare(distance);
            if (EWalletBalance < fare)
            {
                Console.WriteLine("Số dư ví điện tử không đủ để thanh toán chuyến đi.");
                return null;
            }

            Booking booking = new Booking("B001", "Vinhomes", "ĐH FPT", "Xe", fare, "Đã xác nhận");
            bookingHistory.Add(booking);
            Console.WriteLine($"Đặt xe thành công với giá: {fare} VNĐ.");
            return booking;
        }

        public void CompleteRide(Booking booking, Driver driver)
        {
            if (booking != null)
            {
                EWalletBalance -= booking.Fare;
                driver.ReceivePayment(booking.Fare);
                Console.WriteLine($"Chuyến đi hoàn thành. Số dư ví điện tử còn lại: {EWalletBalance} VNĐ.");
            }
        }

        public void CancelBooking()
        {
            if (bookingHistory.Count > 0)
            {
                bookingHistory.RemoveAt(bookingHistory.Count - 1);
                Console.WriteLine("Đặt xe cuối cùng đã bị hủy.");
            }
            else
            {
                Console.WriteLine("Không có đặt xe nào để hủy.");
            }
        }

        private double CalculateFare(double distance)
        {
            return distance * 5000000;
        }

        public List<Booking> ViewBookingHistory()
        {
            return bookingHistory;
        }
    }
}