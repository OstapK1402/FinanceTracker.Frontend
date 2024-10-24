using Task12.BLL.DTO.BaseReport;

namespace Task12.BLL.DTO
{
    public class PeriodReport : BaseReportModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
