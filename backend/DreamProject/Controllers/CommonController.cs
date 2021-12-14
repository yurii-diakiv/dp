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

        [Route("GetAllColumns")]
        [HttpGet]
        public JsonResult GetAllColumns()
        {
            var columns = _commonService.GetAllColumns();

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
        public JsonResult InsertColumn(string name)
        {
            var newColumnId = _commonService.InsertColumn(name);

            return new JsonResult(newColumnId);
        }

        [Route("UpdateСolumnNameById")]
        [HttpPost]
        public void UpdateСolumnNameById(int id, string name)
        {
            _commonService.UpdateСolumnNameById(id, name);
        }
    }
}
