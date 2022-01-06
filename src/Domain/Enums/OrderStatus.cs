namespace Domain.Enums
{
    public enum OrderStatus
    {
        ManualVerificationNeeded = 0,
        Confirmed = 1, 
        Completed = 2,
        Shipped = 3,
        Cancelled = 4
    }
}