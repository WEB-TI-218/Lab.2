using System.Web;
using eUseControl.Domain.Entities.User;
using System.Collections.Generic
using eUseControl.Web1.Models;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }//////
    }
}
