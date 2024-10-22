using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task12.BLL.DTO;

namespace Task12.BLL.IService
{
    public interface ITransactionTypeService
    {
        Task<IEnumerable<TransactionsTypeDTO>> GetAllTransactionsTypes(CancellationToken token);
        Task<TransactionsTypeDTO> GetTransactionsTypeById(int id, CancellationToken token);
        Task<string> CreateTransactionsType(TransactionsTypeDTO data, CancellationToken token);
        Task<string> UpdateTransactionsType(int id, TransactionsTypeDTO data, CancellationToken token);
        Task<string> DeleteTransactionsType(int id, CancellationToken token);
    }
}
