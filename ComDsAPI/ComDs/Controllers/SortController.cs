using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComDs.Service;
using Microsoft.AspNetCore.Authorization;
using ComDs.Config;
using ComDs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComDs.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SortController : Controller
    {
        private readonly SortService _sortService;
        public SortController(SortService sortService)
        {
            this._sortService = sortService;
        }
        // GET: api/values
        [HttpGet("group/{id}")]
        public JsonResult Get(int id)
        {
            var list = _sortService.GetListByGroupID(id);
            return Json(list);
        }
        [HttpGet("school")]
        [Authorize(Policy = "normal")]
        public JsonResult GetSchool()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
            var user = StoreSignedUser.list.Where(m => m.userToken == token).Select(m => m.user).FirstOrDefault();
            var list = _sortService.GetListByUserID(user.UserID);
            return Json(list);
        }
        [HttpPost("{id}")]
        [Authorize(Policy = "normal")]
        public JsonResult Post(int id)
        {
            ResultState result = new ResultState();
            result.State = 500;
            result.Msg = "亲，你已经投过票了";
            var item = _sortService.FindItemByID(id);
            if(item.RandomID != 0)
                return Json(result);
            else
            {
                try
                {
                    int num = _sortService.ProduceRandom(item);
                    result.State = 200;
                    result.Msg = num.ToString();
                    return Json(result);
                }
                catch (Exception)
                {
                    result.Msg = "程序内部异常，请联系管理员";
                    return Json(result);
                }
            }
        }
    }
}
