using System.ComponentModel.DataAnnotations;

namespace Task12.Data.DTO
{
    public class FinancialOperationDTO
    {
        public int OperationId { get; set; }
        [Required(ErrorMessage = "The Amount not filled")]
        [Range(0.01, Double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "The Operation Date is not filled")]
        [Range(typeof(DateTime), "2000-01-01", "2050-01-01", ErrorMessage = "The Operation Date is out of range")]
        public DateTime OperationDate { get; set; }

        [Required(ErrorMessage = "The Transactions Type Id is not filled")]
        public int TransactionsTypeId { get; set; }
        public TransactionsTypeDTO? TransactionsType { get; set; }

        [StringLength(300, ErrorMessage = "The Description length must be from 0 to 300 characters")]
        public string Description { get; set; }
    }
}
