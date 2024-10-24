using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12.BLL.Interface
{
    public interface IHttpResponseValidator
    {
        Task ValidateAsync(HttpResponseMessage response);
    }
}
