using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Common;
using Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KharchaRecorder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;
        private readonly ILogger _logger;

        public ExpenseController(ExpenseService expenseService, ILogger logger)
        {
            _expenseService = expenseService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PostExpense(Expense expense)
        {
            Result result = new Result();
            result = _expenseService.PostExpense(expense);
            return GetActionResult(result);
        }

        public IActionResult GetActionResult(Result result)
        {
            try
            {
                if (result.Error)
                {
                    _logger.LogError(result.ErrMsg);
                    return Conflict(new { message = result.ErrMsg });
                }
                else if (result.AuthorizationError)
                {   
                    _logger.LogError(result.ErrMsg);
                    return Unauthorized(new { message = result.ErrMsg });
                }
                else
                {
                    if (result.Obj != null)
                    {
                        return Ok(result.Obj);
                    }
                    else
                    {
                        //_logger.Info(result);
                        return Ok(new { message = result.Msg });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}
