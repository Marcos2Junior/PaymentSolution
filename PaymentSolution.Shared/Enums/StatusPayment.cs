namespace PaymentSolution.Shared.Enums
{
    public enum StatusPayment
    {
        Active = 1,
        Complete = 2,
        Processing = 3,
        Unrealized = 4,
        Refunded = 5,
        RemovedByReceivingCustomer = 6,
        RemovedByPSP = 7
    }
}
