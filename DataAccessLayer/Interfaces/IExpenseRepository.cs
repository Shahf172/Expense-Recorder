
using Models.Common;
using Models.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IExpenseRepository
    {
        Result PostExpense(Expense expense);
        Result GetExpTypes();
        Result GetPaymentTypes();
        Result GetListOfExpense();
        Result PutExpense(Expense expense);
        Result DeleteExpense(Expense expense);
    }
}
