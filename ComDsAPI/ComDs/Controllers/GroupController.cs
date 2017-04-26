using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComDs.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComDs.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private readonly GroupService _groupService;
        public GroupController(GroupService groupService)
        {
            this._groupService = groupService;
        }
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            var list = this._groupService.GetList();
            return Json(list);
        }
    }
}
