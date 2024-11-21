using System;
using System.Linq;
using System.Threading.Tasks;
using GreenTaxi.Repositories;
using GreenTaxi.Repositories.Entities;
using GreenTaxi.Services;
using GreenTaxi.Services.Interfaces;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Khởi tạo dịch vụ
        var customerService = new CustomerService(new CustomerRepository(new DbrtContext()));
        var bookingService = new BookingService(new BookingRepository(new DbrtContext()));
        var paymentService = new PaymentService(new PaymentRepository(new DbrtContext()));

        Customer loggedInCustomer = null;

        // Menu Đăng ký và Đăng nhập
        while (true)
        {
            Console.WriteLine("Chào mừng bạn đến với Green Taxi");
            Console.WriteLine("1. Đăng ký");
            Console.WriteLine("2. Đăng nhập");
            Console.WriteLine("3. Thoát");
            Console.Write("Chọn một lựa chọn: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Nhập số điện thoại: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Nhập mật khẩu: ");
                string password = Console.ReadLine();
                Console.Write("Nhập tên: ");
                string name = Console.ReadLine();

                try
                {
                    loggedInCustomer = await customerService.RegisterAsync(phoneNumber, password, name);
                    Console.WriteLine("Đăng ký thành công! Vui lòng đăng nhập.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
            else if (choice == "2")
            {
                Console.Write("Nhập số điện thoại: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Nhập mật khẩu: ");
                string password = Console.ReadLine();

                try
                {
                    loggedInCustomer = await customerService.LoginAsync(phoneNumber, password);
                    Console.WriteLine("Đăng nhập thành công!");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Cảm ơn bạn đã sử dụng dịch vụ! Hẹn gặp lại.");
                break;
            }
        }

        // Menu chính sau khi đăng nhập thành công
        while (true)
        {
            Console.WriteLine("\nMenu chính");
            Console.WriteLine("1. Đặt chuyến xe");
            Console.WriteLine("2. Xem số dư ví");
            Console.WriteLine("3. Xem lịch sử đặt xe");
            Console.WriteLine("4. Thoát");
            Console.Write("Chọn một lựa chọn: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                await CreateBookingAsync(bookingService, paymentService, loggedInCustomer);
            }
            else if (option == "2")
            {
                Console.WriteLine($"Số dư ví của bạn: {loggedInCustomer.WalletBalance} VND");
            }
            else if (option == "3")
            {
                await ShowBookingHistory(bookingService, loggedInCustomer);
            }
            else if (option == "4")
            {
                Console.WriteLine("Cảm ơn bạn đã sử dụng dịch vụ! Hẹn gặp lại.");
                break;
            }
            else
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
            }
        }
    }

    static async Task CreateBookingAsync(IBookingService bookingService, IPaymentService paymentService, Customer loggedInCustomer)
    {
        try
        {
            // Chọn tuyến đường
            string route = ChooseRoute();
            // Chọn loại xe
            string vehicle = ChooseVehicle();
            decimal price = CalculatePrice(route);

            int driverId = 1; // Giả sử ID tài xế
            var (startLocation, endLocation) = GetLocations(route);

            // Tạo đặt xe
            var booking = await bookingService.CreateBookingAsync(
                loggedInCustomer.CustomerId,
                driverId,
                startLocation,
                endLocation,
                price
            );

            // Xác nhận đặt xe
            if (booking != null)
            {
                Console.WriteLine($"Đặt chuyến xe thành công! Giá: {price} VND. Bạn có muốn xác nhận không? (y/n)");
                string confirm = Console.ReadLine();
                if (confirm.ToLower() == "y")
                {
                    Console.WriteLine("Tài xế đang trên đường đến đón bạn!");
                    await HandlePayment(paymentService, loggedInCustomer, booking, price);
                }
                else
                {
                    Console.WriteLine("Đặt xe đã bị hủy.");
                }
            }
            else
            {
                Console.WriteLine("Đặt chuyến xe thất bại. Vui lòng thử lại.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi tạo đặt xe: {ex.Message}");
        }
    }

    static async Task HandlePayment(IPaymentService paymentService, Customer loggedInCustomer, Booking booking, decimal price)
    {
        try
        {
            Console.WriteLine("Bạn có muốn thanh toán không? (y/n)");
            string paymentChoice = Console.ReadLine();
            if (paymentChoice.ToLower() == "y")
            {
                if (loggedInCustomer.WalletBalance >= price)
                {
                    loggedInCustomer.WalletBalance -= price;
                    await paymentService.CreatePaymentAsync(booking.BookingId, price);
                    Console.WriteLine("Thanh toán thành công!");
                }
                else
                {
                    Console.WriteLine("Số dư không đủ! Thanh toán thất bại.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi thanh toán: {ex.Message}");
        }
    }

    static async Task ShowBookingHistory(IBookingService bookingService, Customer loggedInCustomer)
    {
        try
        {
            Console.WriteLine("Lịch sử đặt xe:");
            var bookings = await bookingService.GetBookingsByCustomerIdAsync(loggedInCustomer.CustomerId);
            if (bookings.Any())
            {
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"Mã đặt xe: {booking.BookingId}, Tuyến đường: {booking.StartLocation} -> {booking.EndLocation}, Giá: {booking.Fare}, Trạng thái: {booking.Status}");
                }
            }
            else
            {
                Console.WriteLine("Bạn chưa đặt chuyến xe nào.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi lấy lịch sử đặt xe: {ex.Message}");
        }
    }

    // Chọn tuyến đường
    static string ChooseRoute()
    {
        Console.WriteLine("Chọn tuyến đường: ");
        Console.WriteLine("1. ĐH FPT -> Vinhomes (7km)");
        Console.WriteLine("2. Vinhomes -> ĐH FPT (9km)");
        Console.Write("Chọn tuyến đường: ");
        return Console.ReadLine() == "1" ? "ĐH FPT -> Vinhomes" : "Vinhomes -> ĐH FPT";
    }

    // Chọn loại xe
    static string ChooseVehicle()
    {
        Console.WriteLine("Chọn loại xe: ");
        Console.WriteLine("1. Xe máy");
        Console.WriteLine("2. Xe điện");
        Console.WriteLine("3. Xe taxi");
        Console.Write("Chọn loại xe: ");
        return Console.ReadLine() switch
        {
            "1" => "Xe máy",
            "2" => "Xe điện",
            _ => "Xe taxi",
        };
    }

    static decimal CalculatePrice(string route)
    {
        return route == "ĐH FPT -> Vinhomes" ? 7 * 5000 : 9 * 5000;
    }

    static (string startLocation, string endLocation) GetLocations(string route)
    {
        return route == "ĐH FPT -> Vinhomes" ? ("ĐH FPT", "Vinhomes") : ("Vinhomes", "ĐH FPT");
    }
}
