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

        public List<Column> GetAllColumnsByBoardId(int boardId)
        {
            try
            {
                var dbContext = _dbContextFactory.GetDbContext();

                var columns = dbContext.Columns.Where(x=>x.BoardId == boardId).ToList();

                foreach(var column in columns)
                {
                    column.ColumnCards = dbContext.Cards.Where(x => x.ColumnId == column.Id).ToList();
                }

                return columns;
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

        public int InsertColumn(string name, int boardId)
        {
            var dbContext = _dbContextFactory.GetDbContext();
            var newColumn = new Column { Name = name, BoardId = boardId };
            dbContext.Columns.Add(newColumn);

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

        // Board
        public List<Board> GetAllBoards()
        {
            try
            {
                var dbContext = _dbContextFactory.GetDbContext();

                var boards = dbContext.Boards.ToList();

                foreach(var board in boards)
                {
                    board.BoardColumn = dbContext.Columns.Where(x => x.BoardId == board.Id).ToList();

                    var columns = board.BoardColumn.ToList();

                    foreach (var column in columns)
                    {
                        column.ColumnCards = dbContext.Cards.Where(x => x.ColumnId == column.Id).ToList();
                    }
                }

                return boards;
            }
            catch
            {
                return null;
            }
        }

        public Board GetBoardById(int id)
        {
            try
            {
                var dbContext = _dbContextFactory.GetDbContext();

                var Board = dbContext.Boards.FirstOrDefault(x => x.Id == id);
                return Board;
            }
            catch
            {
                return null;
            }
        }

        public int InsertBoard(string name)
        {
            var dbContext = _dbContextFactory.GetDbContext();
            var newBoard = new Board { Name = name };
            dbContext.Boards.Add(newBoard);

            dbContext.SaveChanges();

            return newBoard.Id;
        }

        public void UpdateBoardNameById(int id, string name)
        {
            var dbContext = _dbContextFactory.GetDbContext();

            var column = dbContext.Columns.FirstOrDefault(x => x.Id == id);
            if (column != null)
            {
                column.Name = name;

                dbContext.SaveChanges();
            }
        }

        // Card
        public List<Card> GetCardsByColumnId(int columnId)
        {
            try
            {
                var dbContext = _dbContextFactory.GetDbContext();

                return dbContext.Cards.Where(x=>x.ColumnId == columnId).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Card GetCardById(int id)
        {
            try
            {
                var dbContext = _dbContextFactory.GetDbContext();

                var Card = dbContext.Cards.FirstOrDefault(x => x.Id == id);
                return Card;
            }
            catch
            {
                return null;
            }
        }

        public int InsertCard(string title, string text, int columnId)
        {
            var dbContext = _dbContextFactory.GetDbContext();
            var newCard = new Card { Title = title, Text = text, ColumnId = columnId };
            dbContext.Cards.Add(newCard);

            dbContext.SaveChanges();

            return newCard.Id;
        }
    }
}
