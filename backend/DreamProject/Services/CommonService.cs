using DreamProject.Models;
using DreamProject.Repositories.Interfaces;
using DreamProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamProject.Services
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;


        public CommonService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public List<Column> GetAllColumns()
        {
            return _commonRepository.GetAllColumns();
        }

        public Column GetColumnById(int id)
        {
            return _commonRepository.GetColumnById(id);
        }

        public int InsertColumn(string name)
        {
            return _commonRepository.InsertColumn(name);
        }

        public void UpdateСolumnNameById(int id, string name)
        {
            _commonRepository.UpdateСolumnNameById(id, name);
        }
    }
}
