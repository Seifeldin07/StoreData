using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreService.Services.CashService
{
    public interface ICashService
    {
        Task SetCashResponseAsync(string key, object response, TimeSpan timeToLeave);
        Task<string> GetCashResponseAsync(string key);
    }
}
