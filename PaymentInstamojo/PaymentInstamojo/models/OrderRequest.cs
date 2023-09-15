namespace PaymentInstamojo.models
{
    public class OrderRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? TransectionId { get; set; }
        public double? Ammount { get; set; }

    }
}
