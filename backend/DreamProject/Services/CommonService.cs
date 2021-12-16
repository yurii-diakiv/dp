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

        public List<Column> GetAllColumnsByBoardId(int boardId)
        {
            return _commonRepository.GetAllColumnsByBoardId(boardId);
        }

        public Column GetColumnById(int id)
        {
            return _commonRepository.GetColumnById(id);
        }

        public int InsertColumn(string name, int boardId)
        {
            return _commonRepository.InsertColumn(name, boardId);
        }

        public void UpdateСolumnNameById(int id, string name)
        {
            _commonRepository.UpdateСolumnNameById(id, name);
        }

        // Board
        public List<Board> GetAllBoards()
        {
            return _commonRepository.GetAllBoards();
        }

        public Board GetBoardById(int id)
        {
            return _commonRepository.GetBoardById(id);
        }

        public int InsertBoard(string name)
        {
            return _commonRepository.InsertBoard(name);
        }

        public void UpdateBoardNameById(int id, string name)
        {
            _commonRepository.UpdateBoardNameById(id, name);
        }

        // Card
        public List<Card> GetCardsByColumnId(int columnId)
        {
            return _commonRepository.GetCardsByColumnId(columnId);
        }

        public Card GetCardById(int id)
        {
            return _commonRepository.GetCardById(id);
        }

        public int InsertCard(string title, string text, int columnId)
        {
            return _commonRepository.InsertCard(title, text, columnId);
        }
    }
}
