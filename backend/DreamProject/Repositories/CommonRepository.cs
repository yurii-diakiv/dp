using DreamProject.Models;
using DreamProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamProject.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly DbContextFactory _dbContextFactory;

        public CommonRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public List<Column> GetAllColumns()
        {
            try
            {
                var dbContext = _dbContextFactory.GetDbContext();

                return dbContext.Columns.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Column GetColumnById(int id)
        {
            try
            {
                var dbContext = _dbContextFactory.GetDbContext();

                var column = dbContext.Columns.FirstOrDefault(x => x.Id == id);
                return column;
            }
            catch
            {
                return null;
            }
        }

        public int InsertColumn(string name)
        {
            var dbContext = _dbContextFactory.GetDbContext();
            var newColumn = new Column { Name = name };
            dbContext.Add(newColumn);

            dbContext.SaveChanges();

            return newColumn.Id;
        }

        public void UpdateСolumnNameById(int id, string name)
        {
            var dbContext = _dbContextFactory.GetDbContext();

            var column = dbContext.Columns.FirstOrDefault(x => x.Id == id);
            if (column != null)
            {
                column.Name = name;

                dbContext.SaveChanges();
            }
        }

    }
}
