using ControllerApp.Domains.Cars;

namespace ControllerApp.TempModels.Cars
{
    public class TempCarBookState
    {
        public int CarBookStateId { get; set; }
        public int CarBookStatusId { get; set; }
        public int CarBookingId { get; set; }
        public TempCarBooking CarBooking { get; set; }
        public CarBookStatus CarBookStatus { get; set; }
    }
}
