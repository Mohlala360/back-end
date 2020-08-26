namespace ControllerApp.Domains.UserBooks
{
    public enum UserBookStatuses
    {
        Alocate = 1,
        Return ,
    }

    public class UserBookStatus
    {
        public int UserBookStatusId { get; set; }
        public string Description { get; set; }
    }
}
