namespace Task12.Data.DTO.Base
{
    public abstract class BaseReportModel
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public IEnumerable<FinancialOperationDTO> Operations { get; set; }
    }
}
