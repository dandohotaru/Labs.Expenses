using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Common;
using Labs.Expenses.W.Domain.Entities;

namespace Labs.Expenses.W.Domain.Handlers
{
    public class AddExpenseHandler :IHandler<AddExpenseCommand, AddExpenseResult>
    {
        public AddExpenseHandler(IDataContext dataContext)
        {
            if (dataContext == null)
                throw new ArgumentNullException("dataContext");

            DataContext = dataContext;
        }

        protected IDataContext DataContext { get; private set; }

        public AddExpenseResult Execute(AddExpenseCommand command)
        {
            var expense = DataContext
                .Query<Expense>()
                .SingleOrDefault(p => p.Id == command.ExpenseId);
            if (expense != null)
                throw new Exception("The provided expense already exists in the data store.");



            //expense = new Expense
            //{
                
            //}

            throw new NotImplementedException("ToDo");
        }
    }
}
