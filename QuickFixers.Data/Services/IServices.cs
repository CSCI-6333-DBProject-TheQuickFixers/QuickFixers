using QuickFixers.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Services
{
    public interface IServices
    {
        IEnumerable<ScheduledService> GetAll();
        ScheduledService Get(int id);

        IEnumerable<ScheduledService> GetAllPast();

        IEnumerable<ScheduledService> GetAllFuture();

    }
}
