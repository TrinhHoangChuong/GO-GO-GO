using System;

namespace Libs
{
    public class Driver : User
    {
        public string VehicleType { get; set; }
        public string AvailabilityStatus { get; set; }

        public Driver(string userID, string name, string phoneNumber, string password, string vehicleType, string availabilityStatus)
            : base(userID, name, phoneNumber, password)
        {
            VehicleType = vehicleType;
            AvailabilityStatus = availabilityStatus;
        }

        public override void Register()
        {
            Console.WriteLine($"Tài xế {Name} đã đăng ký thành công.");
        }

        public void ReceiveBooking(Booking booking)
        {
            Console.WriteLine($"Tài xế {Name} đã nhận đặt xe {booking.BookingID}.");
        }

        public void ConfirmRide()
        {
            Console.WriteLine($"Tài xế {Name} đã xác nhận chuyến đi.");
        }

        public void ConfirmPayment()
        {
            Console.WriteLine($"Tài xế {Name} đã xác nhận thanh toán.");
        }

        public void ReceivePayment(double amount)
        {
            Console.WriteLine($"Tài xế {Name} đã nhận được {amount} VNĐ.");
        }

        public string ViewFeedback()
        {
            return "Xem phản hồi từ khách hàng.";
        }
    }
}