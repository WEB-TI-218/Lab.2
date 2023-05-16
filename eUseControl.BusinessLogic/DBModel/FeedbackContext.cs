using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.DBModel
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext() :
            base("eUseControl")
        { }
        public virtual DbSet<FDbTable> Feedback { get; set; }
    }
}
