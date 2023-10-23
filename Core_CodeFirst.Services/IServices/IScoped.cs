using Core_CodeFirst.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_CodeFirst.Services.IServices
{
    public interface IScoped
    {
        Guid GetOperationID();
    }
}
