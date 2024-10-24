using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task12.BLL.DTO;

namespace Task12.BLL.IService
{
    internal interface IReportService
    {
        Task<DailyReport> GetReportByDate(DateTime date, CancellationToken token);
        Task<PeriodReport> GetReportByPeriod(DateTime startDate, DateTime endDate, CancellationToken token);
    }
}
