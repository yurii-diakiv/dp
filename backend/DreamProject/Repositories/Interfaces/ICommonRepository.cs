using DreamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamProject.Repositories.Interfaces
{
    public interface ICommonRepository
    {
        List<Column> GetAllColumnsByBoardId(int boardId);
        Column GetColumnById(int id);
        int InsertColumn(string name, int boardId);
        void UpdateСolumnNameById(int id, string name);
        // Board
        List<Board> GetAllBoards();
        Board GetBoardById(int id);
        int InsertBoard(string name);
        void UpdateBoardNameById(int id, string name);
        // Card
        List<Card> GetCardsByColumnId(int columnId);
        Card GetCardById(int id);
        int InsertCard(string title, string text, int columnId);
    }
}
