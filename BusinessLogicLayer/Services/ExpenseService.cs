using DataAccessLayer.Interfaces;
using Models.Common;
using Models.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class ExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        #region Methods

        public Result PostExpense(Expense expense)
        {
            return _expenseRepository.PostExpense(expense);
        }

        public Result PutExpense(Expense expense)
        {
            return _expenseRepository.PutExpense(expense);
        }

        public Result DeleteExpense(Expense expense)
        {
            return _expenseRepository.DeleteExpense(expense);
        }
        public Result GetExpTypes()
        {
            return _expenseRepository.GetExpTypes();
        }

        public Result GetPaymentTypes()
        {
            return _expenseRepository.GetPaymentTypes();
        }

        public Result GetListOfExpense()
        {
            return _expenseRepository.GetListOfExpense();
        }
        #endregion
    }
}
