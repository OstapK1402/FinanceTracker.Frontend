using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task12.BLL.DTO;

namespace Task12.BLL.IService
{
    internal interface IFinancialOperationService
    {
        Task<IEnumerable<FinancialOperationDTO>> GetAllFinancialOperations(CancellationToken token);
        Task<FinancialOperationDTO> GetFinancialOperationById(int id, CancellationToken token);
        Task<string> CreateFinancialOperation(FinancialOperationDTO data, CancellationToken token);
        Task<string> UpdateFinancialOperation(int id, FinancialOperationDTO data, CancellationToken token);
        Task<string> DeleteFinancialOperation(int id, CancellationToken token);
    }
}
