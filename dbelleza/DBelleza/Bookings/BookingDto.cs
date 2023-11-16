namespace Bookings
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
    }
}
