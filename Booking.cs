namespace Libs
{
    public class Booking
    {
        public string BookingID { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public string VehicleType { get; set; }
        public double Fare { get; set; }
        public string Status { get; set; }

        public Booking() { }

        public Booking(string bookingID, string pickupLocation, string dropoffLocation, string vehicleType, double fare, string status)
        {
            BookingID = bookingID;
            PickupLocation = pickupLocation;
            DropoffLocation = dropoffLocation;
            VehicleType = vehicleType;
            Fare = fare;
            Status = status;
        }
        public void DisplayBookingInfo()
        {
            Console.WriteLine($"Booking ID: {BookingID}");
            Console.WriteLine($"Pickup Location: {PickupLocation}");
            Console.WriteLine($"Dropoff Location: {DropoffLocation}");
            Console.WriteLine($"Fare: {Fare} VNĐ");
            Console.WriteLine($"Status: {Status}");
        }
    }
}