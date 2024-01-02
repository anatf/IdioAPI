namespace IdioAPI.Models
{
    public partial class Invoice
    {
        public InvoiceTransactionLog CreateTransaction()
        {
            return new InvoiceTransactionLog()
            {
                Amount = (decimal)this.Amount,
                Status = (int)this.Status,
                InvoiceId = this.Id,
                Timestamp = DateTime.Now
            };
        }
    }
}
