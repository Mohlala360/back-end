using ControllerApp.TempModels.Users;
using System;

namespace ControllerApp.TempModels.Cars
{
    public class TempCarBooking
    {
        public int CarBookingId { get; set; }
        public string BookingReason { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public TempUser User { get; set; }
        public int UserId { get; set; }
        public TempCar Car { get; set; }
        public int CarId { get; set; }
        public DateTime DateCaptured { get; set; }
        public int UserCatured { get; set; }
    }
}
