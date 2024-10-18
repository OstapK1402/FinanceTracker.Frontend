namespace Task12.BLL.DTO.BaseReport
{
    public abstract class BaseReportModel
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public IEnumerable<FinancialOperationDTO> Operations { get; set; }
    }
}
