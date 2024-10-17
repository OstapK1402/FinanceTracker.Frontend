using Task12.Data.DTO.Base;

namespace Task12.Data.DTO
{
    public class PeriodReport : BaseReportModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
