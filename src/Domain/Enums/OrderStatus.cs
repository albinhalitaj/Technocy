namespace Domain.Enums
{
    public enum OrderStatus
    {
        ManualVerificationNeeded = 0,
        Hold = 1, // waiting for call
        Completed = 2,
        Shipped = 3,
        Cancelled = 4
    }
}