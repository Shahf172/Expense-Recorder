using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Models.Common;
using Models.DAL;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly KharchaRecorderContext _context;
        private readonly ILogger _logger;

        public ExpenseRepository(KharchaRecorderContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public Result PostExpense(Expense expense)
        {
            Result result = new Result();
            try
            {
                var obj = _context.Add(expense);
                _context.SaveChanges();
                result.Obj = obj.Entity;
                return result;
            }
            catch(Exception ex)
            {
                return Utility.GetException(ex, _logger, result);
            }
        }

        public Result PutExpense(Expense expense)
        {
            Result result = new Result();
            try
            {
                var obj = _context.Update(expense);
                _context.SaveChanges();
                result.Obj = obj.Entity;
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, _logger, result);
            }
        }

        public Result DeleteExpense(Expense expense)
        {
            Result result = new Result();
            try
            {
                var obj = _context.Remove(expense);
                _context.SaveChanges();
                result.Obj = obj.Entity;
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, _logger, result);
            }
        }

        public Result GetExpTypes()
        {
            Result result = new Result();
            try
            {
                var obj = _context.ExpenseTypes.ToList();
                result.Obj = obj;
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, _logger, result);
            }
        }

        public Result GetPaymentTypes()
        {
            Result result = new Result();
            try
            {
                var obj = _context.PaymentModes.ToList();
                result.Obj = obj;
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, _logger, result);
            }
        }

        public Result GetListOfExpense()
        {
            Result result = new Result();
            try
            {

                var obj =  (from exp in _context.Expenses
                                 join expTypes in _context.ExpenseTypes on exp.ExpenseTypeId equals expTypes.Id
                                 join payModes in _context.PaymentModes on exp.PaymentModeId equals payModes.Id
                                 //where exp.CreateDate.Value.Year.Equals(2022) where exp.CreateDate.Value.Month.Equals(2)
                                 orderby exp.CreateDate descending
                           select new ExpenseDetail
                           {
                               Id = exp.Id,
                               Name = exp.Name,
                               Amount = exp.Amount,
                               DataEntryDate = exp.DataEntryDate,
                               CreateDate = exp.CreateDate,
                               DeletedDate = exp.DeletedDate,
                               ExpenseTypeId = expTypes.Id,
                               ExpType = expTypes.Name,
                               PaymentMode = payModes.Name,
                               PaymentModeId = payModes.Id,
                               Status = exp.Status,
                               UpdatedDate = exp.UpdatedDate
                           }
                           ).ToList();
                result.Obj = obj;
                return result;
            }
            catch (Exception ex)
            {
                return Utility.GetException(ex, _logger, result);
            }
        }
    }
}
