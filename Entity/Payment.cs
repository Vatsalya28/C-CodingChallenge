using System;

namespace DotnetAssessment.Entity
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
        public Client Client { get; set; }

        
        public Payment(int paymentId, DateTime paymentDate, double paymentAmount, Client client)
        {
            PaymentId = paymentId;
            PaymentDate = paymentDate;
            PaymentAmount = paymentAmount;
            Client = client;
        }

       
        public override string ToString()
        {
            return $"Payment ID: {PaymentId}\tPayment Date: {PaymentDate}\tPayment Amount: {PaymentAmount}\tClient: {Client}";
        }
    }
}
