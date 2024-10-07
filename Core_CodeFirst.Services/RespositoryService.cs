using Core_CodeFirst.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_CodeFirst.Services
{
    public class RespositoryService
    {
        private readonly IRepository _repository;

        public RespositoryService(IRepository repository)
        {
            _repository = repository;
        }

        public string GetData()
        {
            var data = _repository.GetData();
            return data.ToUpper(); // Logic
        }
    }
}
