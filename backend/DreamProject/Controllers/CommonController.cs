using DreamProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace DreamProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [Route("GetAllColumnsByBoardId")]
        [HttpGet]
        public JsonResult GetAllColumnsByBoardId(int boardId)
        {
            var columns = _commonService.GetAllColumnsByBoardId(boardId);

            return new JsonResult(columns);
        }

        [Route("GetColumnById")]
        [HttpGet]
        public JsonResult GetColumnById(int id)
        {
            var column = _commonService.GetColumnById(id);

            return new JsonResult(column);
        }

        [Route("InsertColumn")]
        [HttpPut]
        public JsonResult InsertColumn(string name, int boardId)
        {
            var newColumnId = _commonService.InsertColumn(name, boardId);

            return new JsonResult(newColumnId);
        }

        [Route("UpdateСolumnNameById")]
        [HttpPost]
        public void UpdateСolumnNameById(int id, string name)
        {
            _commonService.UpdateСolumnNameById(id, name);
        }


        // Board
        [Route("GetAllBoards")]
        [HttpGet]
        public JsonResult GetAllBoards()
        {
            return new JsonResult(_commonService.GetAllBoards());
        }

        [Route("GetBoardById")]
        [HttpGet]
        public JsonResult GetBoardById(int id)
        {
            return new JsonResult(_commonService.GetBoardById(id));
        }

        [Route("InsertBoard")]
        [HttpPut]
        public JsonResult InsertBoard(string name)
        {
            return new JsonResult(_commonService.InsertBoard(name));
        }

        [Route("UpdateBoardNameById")]
        [HttpPost]
        public void UpdateBoardNameById(int id, string name)
        {
            _commonService.UpdateBoardNameById(id, name);
        }

        // Card
        [Route("GetCardsByColumnId")]
        [HttpGet]
        public JsonResult GetCardsByColumnId(int columnId)
        {
            return new JsonResult(_commonService.GetCardsByColumnId(columnId));
        }

        [Route("GetCardById")]
        [HttpGet]
        public JsonResult GetCardById(int id)
        {
            return new JsonResult(_commonService.GetCardById(id));
        }

        [Route("InsertCard")]
        [HttpPost]
        public JsonResult InsertCard(string title, string text, int columnId)
        {
            return new JsonResult(_commonService.InsertCard(title, text, columnId));
        }
    }
}
