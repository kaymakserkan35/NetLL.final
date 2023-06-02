using NettLL.Design.DatabaseOperations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NettLL.Design.DatabaseOperations.DataAccess
{
    internal interface ICategoryOperations
    {

        public bool createCategory(Category category);
        public Category readCategory(int id);
        public List<Category> readAllCategories();
        public List<Category> readAllCategories(Expression<Func<Category, bool>> filter = null);
        public void updateCategory(Category category);
        public void deleteCategory(int id);

    }
}
