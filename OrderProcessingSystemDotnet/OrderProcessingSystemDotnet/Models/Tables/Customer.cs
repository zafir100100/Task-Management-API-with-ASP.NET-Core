

namespace OrderProcessingSystemDotnet.Models.Tables
{
    public class Customer
    {
        public int Id { get; set; }
        public int SalesRepEmployeeNum { get; set; }    
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Phone { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? PostalCode { get; set; }
        public string? Country { get; set; }
        public decimal? CreditLimit { get; set; }
    }
}
