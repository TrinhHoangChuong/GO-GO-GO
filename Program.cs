using System;
using System.Collections.Generic;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Customer> customers = new List<Customer>();
            List<Driver> drivers = new List<Driver>();

            Console.WriteLine("Chào mừng đến với hệ thống đặt xe!");
            Console.WriteLine("Bạn muốn đăng ký tài khoản với tư cách nào?");
            Console.WriteLine("1. Khách hàng");
            Console.WriteLine("2. Tài xế");
            Console.Write("Chọn (1 hoặc 2): ");
            string accountType = Console.ReadLine();

            if (accountType == "1")
            {
                Customer customer = new Customer();
                Console.Write("Nhập tên khách hàng: ");
                customer.UserName = Console.ReadLine();
                Console.Write("Nhập số điện thoại: ");
                customer.PhoneNumber = Console.ReadLine();
                Console.Write("Nhập mật khẩu: ");
                customer.Password = Console.ReadLine();

                customers.Add(customer);
                Console.WriteLine("Đăng ký khách hàng thành công!");

                Console.WriteLine("Bạn muốn đặt xe từ:");
                Console.WriteLine("1. Vinhomes đến ĐH FPT");
                Console.WriteLine("2. ĐH FPT đến Vinhomes");
                Console.Write("Chọn (1 hoặc 2): ");
                string routeChoice = Console.ReadLine();

                Booking booking = customer.BookRide(routeChoice);
                if (booking != null)
                {
                    booking.DisplayBookingInfo(); 
                    Console.Write("Bạn có muốn xác nhận chuyến đi không? (y/n): ");
                    string confirmChoice = Console.ReadLine();
                    if (confirmChoice.ToLower() == "y")
                    {
                        Console.Write($"Chi phí chuyến đi là: {booking.Cost} VNĐ. Bạn có muốn thanh toán không? (y/n): ");
                        string paymentChoice = Console.ReadLine();
                        if (paymentChoice.ToLower() == "y")
                        {
                            customer.CompleteRide(booking);
                        }
                        Console.Write("Bạn muốn đánh giá chuyến đi này (1-5): ");
                        int rating = int.Parse(Console.ReadLine());
                        booking.RateTrip(rating);

                        Console.Write("Bạn có muốn báo cáo vấn đề gì không? (y/n): ");
                        string reportChoice = Console.ReadLine();
                        if (reportChoice.ToLower() == "y")
                        {
                            Console.Write("Nhập nội dung báo cáo: ");
                            string reportContent = Console.ReadLine();
                            Console.WriteLine("Báo cáo của bạn đã được gửi thành công!");
                        }
                    }
                }
            }
            else if (accountType == "2")
            {
                Driver driver = new Driver();
                Console.Write("Nhập tên tài xế: ");
                driver.UserName = Console.ReadLine();
                Console.Write("Nhập số điện thoại: ");
                driver.PhoneNumber = Console.ReadLine();
                Console.Write("Nhập mật khẩu: ");
                driver.Password = Console.ReadLine();
                Console.Write("Nhập loại xe: ");
                driver.VehicleType = Console.ReadLine();
                driver.Status = "Available"; 
                drivers.Add(driver);
                Console.WriteLine("Đăng ký tài xế thành công!");
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ.");
            }

            Console.ReadKey();
        }
    }

    public class Customer
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public Booking BookRide(string routeChoice)
        {
            string route = routeChoice == "1" ? "Vinhomes đến ĐH FPT" : "ĐH FPT đến Vinhomes";
            double cost = routeChoice == "1" ? 100000 : 120000; 
            Console.WriteLine($"Đặt xe thành công từ {route}. Chi phí chuyến đi là: {cost} VNĐ.");
            return new Booking(route, cost); 
        }

        public void CompleteRide(Booking booking)
        {
            Console.WriteLine("Chuyến đi đã hoàn thành. Cảm ơn bạn đã sử dụng dịch vụ.");
        }
    }

    public class Driver
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string VehicleType { get; set; }
        public string Status { get; set; }

        public string ViewFeedback()
        {
            return "Không có phản hồi nào.";
        }
    }

    public class Booking
    {
        public string Route { get; private set; }
        public double Cost { get; private set; }
        public int Rating { get; private set; }

        public Booking(string route, double cost)
        {
            Route = route;
            Cost = cost;
            Rating = 0; 
        }

        public void DisplayBookingInfo()
        {
            Console.WriteLine($"Thông tin chuyến đi: {Route}");
            Console.WriteLine($"Chi phí chuyến đi: {Cost} VNĐ");
        }

        public void RateTrip(int rating)
        {
            if (rating >= 1 && rating <= 5)
            {
                Rating = rating;
                Console.WriteLine($"Cảm ơn bạn đã đánh giá chuyến đi với điểm: {Rating}");
            }
            else
            {
                Console.WriteLine("Điểm đánh giá không hợp lệ. Vui lòng nhập từ 1 đến 5.");
            }
        }
    }
}