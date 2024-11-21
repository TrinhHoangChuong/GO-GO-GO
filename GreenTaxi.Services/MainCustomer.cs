//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using GreenTaxi.Repositories;
//using GreenTaxi.Repositories.Entities;
//using GreenTaxi.Services;
//using GreenTaxi.Services.Interfaces;

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        Console.OutputEncoding = System.Text.Encoding.UTF8;

//        var customerService = new CustomerService(new CustomerRepository(new DbrtContext()));
//        var bookingService = new BookingService(new BookingRepository(new DbrtContext()));
//        var paymentService = new PaymentService(new PaymentRepository(new DbrtContext()));

//        Customer loggedInCustomer = null;

//        while (true)
//        {
//            Console.WriteLine("Chào mừng bạn đến với Green Taxi");
//            Console.WriteLine("1. Đăng ký");
//            Console.WriteLine("2. Đăng nhập");
//            Console.WriteLine("3. Thoát");
//            Console.Write("Chọn một lựa chọn: ");
//            string choice = Console.ReadLine();

//            if (choice == "1")
//            {
//                Console.Write("Nhập số điện thoại: ");
//                string phoneNumber = Console.ReadLine();
//                Console.Write("Nhập mật khẩu: ");
//                string password = Console.ReadLine();
//                Console.Write("Nhập tên: ");
//                string name = Console.ReadLine();

//                try
//                {
//                    loggedInCustomer = await customerService.RegisterAsync(phoneNumber, password, name);
//                    Console.WriteLine("Đăng ký thành công!");
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//            }
//            else if (choice == "2")
//            {
//                Console.Write("Nhập số điện thoại: ");
//                string phoneNumber = Console.ReadLine();
//                Console.Write("Nhập mật khẩu: ");
//                string password = Console.ReadLine();

//                try
//                {
//                    loggedInCustomer = await customerService.LoginAsync(phoneNumber, password);
//                    Console.WriteLine("Đăng nhập thành công!");
//                    break;
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//            }
//            else if (choice == "3")
//            {
//                break;
//            }
//        }

//        while (true)
//        {
//            Console.WriteLine("\nMenu chính");
//            Console.WriteLine("1. Đặt chuyến xe");
//            Console.WriteLine("2. Xem số dư ví");
//            Console.WriteLine("3. Xem lịch sử đặt xe");
//            Console.WriteLine("4. Thoát");
//            Console.Write("Chọn một lựa chọn: ");
//            string option = Console.ReadLine();

//            if (option == "1")
//            {
//                Console.WriteLine("Chọn tuyến đường: ");
//                Console.WriteLine("1. ĐH FPT -> Vinhomes (7km)");
//                Console.WriteLine("2. Vinhomes -> ĐH FPT (9km)");
//                Console.Write("Chọn tuyến đường: ");
//                string route = Console.ReadLine() == "1" ? "ĐH FPT -> Vinhomes" : "Vinhomes -> ĐH FPT";

//                Console.WriteLine("Chọn loại xe: ");
//                Console.WriteLine("1. Xe máy");
//                Console.WriteLine("2. Xe điện");
//                Console.WriteLine("3. Xe taxi");
//                Console.Write("Chọn loại xe: ");
//                string vehicle = Console.ReadLine() == "1" ? "Xe máy" : Console.ReadLine() == "2" ? "Xe điện" : "Xe taxi";

//                decimal price = route == "ĐH FPT -> Vinhomes" ? 7 * 5000 : 9 * 5000;

//                int driverId = 1;  

//                string startLocation = route == "ĐH FPT -> Vinhomes" ? "ĐH FPT" : "Vinhomes";
//                string endLocation = route == "ĐH FPT -> Vinhomes" ? "Vinhomes" : "ĐH FPT";

//                var booking = await bookingService.CreateBookingAsync(
//                    loggedInCustomer.CustomerId,
//                    driverId,
//                    startLocation,
//                    endLocation,
//                    price
//                );

//                Console.WriteLine($"Đặt chuyến xe thành công! Giá: {price} VND. Bạn có muốn xác nhận không? (y/n)");
//                string confirm = Console.ReadLine();
//                if (confirm.ToLower() == "y")
//                {
//                    Console.WriteLine("Tài xế đang trên đường đến đón bạn!");

//                    Console.WriteLine("Bạn có muốn thanh toán không? (y/n)");
//                    string paymentChoice = Console.ReadLine();
//                    if (paymentChoice.ToLower() == "y")
//                    {
//                        if (loggedInCustomer.WalletBalance >= price)
//                        {
//                            loggedInCustomer.WalletBalance -= price;
//                            await paymentService.CreatePaymentAsync(booking.BookingId, price);
//                            Console.WriteLine("Thanh toán thành công!");
//                        }
//                        else
//                        {
//                            Console.WriteLine("Số dư không đủ! Thanh toán thất bại.");
//                        }
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Đặt xe đã bị hủy.");
//                }
//            }
//            else if (option == "2")
//            {
//                Console.WriteLine($"Số dư ví của bạn: {loggedInCustomer.WalletBalance} VND");
//            }
//            else if (option == "3")
//            {
//                Console.WriteLine("Lịch sử đặt xe:");
//                var bookings = await bookingService.GetBookingsByCustomerIdAsync(loggedInCustomer.CustomerId);
//                foreach (var booking in bookings)
//                {
//                    Console.WriteLine($"Mã đặt xe: {booking.BookingId}, Tuyến đường: {booking.StartLocation} -> {booking.EndLocation}, Giá: {booking.Fare}, Trạng thái: {booking.Status}");
//                }
//            }
//            else if (option == "4")
//            {
//                break;
//            }
//        }
//    }
//}
