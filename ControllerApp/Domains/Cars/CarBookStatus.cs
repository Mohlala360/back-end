
namespace ControllerApp.Domains.Cars
{
    public enum CarBookStatuses
    {
        New = 1,
        Out,
        Back
    }

    public class CarBookStatus
    {
        public int CarBookStatusId { get; set; }
        public string Status { get; set; }
    }
}
