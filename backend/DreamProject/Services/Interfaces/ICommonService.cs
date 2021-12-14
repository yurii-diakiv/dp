using DreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamProject.Services.Interfaces
{
    public interface ICommonService
    {
        List<Column> GetAllColumns();


        Column GetColumnById(int id);


        int InsertColumn(string name);


        void UpdateСolumnNameById(int id, string name);
    }
}
