using System.ComponentModel.DataAnnotations;

namespace Task12.Data.DTO
{
    public class TransactionsTypeDTO
    {
        public int TypeId { get; set; }

        [Required(ErrorMessage = "The Name is not filled")]
        public string Name { get; set; }
        public bool IsIncome { get; set; }
    }
}
