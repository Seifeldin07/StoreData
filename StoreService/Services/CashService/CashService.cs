using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreService.Services.CashService
{
    public class CashService : ICashService
    {
        private readonly IDatabase _database;

        public CashService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();

        }
        public async Task<string> GetCashResponseAsync(string key)
        {
            var cashedResponse = await _database.StringGetAsync(key);
            if (cashedResponse.IsNull)
                return null;
            return cashedResponse.ToString();
        }

        public async Task SetCashResponseAsync(string key, object response, TimeSpan timeToLeave)
        {
            if (response == null)
                return;
          

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var serilaizedResponse = JsonSerializer.Serialize(response, options);
            await _database.StringSetAsync(key, serilaizedResponse, timeToLeave);
        }




    }
}
