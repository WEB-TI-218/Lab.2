using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.BusinessLogic.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {categoryName = "BMV"}
                    new Category {categoryName = "Mercedes"}

                }
            }
        }

           
            
            
       
    }
}
