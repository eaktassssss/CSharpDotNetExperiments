using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Attributes
{
    public class CacheService : ICacheService
    {
        private readonly string _RedisConnectionString= "localhost:6379";
        private readonly int _Database = 3;
        private readonly IDatabase _database;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public CacheService()
        {
            _connectionMultiplexer = Connect();
            _database = Database(_Database, connectionMultiplexer: _connectionMultiplexer);
        }

        public ConnectionMultiplexer Connect()
        {
            try
            {
                ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(_RedisConnectionString);
                return connectionMultiplexer;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
        public IDatabase Database(int db, IConnectionMultiplexer connectionMultiplexer)
        {
            IDatabase database = connectionMultiplexer.GetDatabase(db);
            return database;
        }
        public T GetCache<T>(string key)
        {


            RedisValue cacheData = _database.StringGet(key);
            if (!string.IsNullOrEmpty(cacheData))
                return JsonSerializer.Deserialize<T>(cacheData);
            else
                return default;
        }


    

        public void RemoveCache(string key)
        {

            var exist = _database.KeyExists(key);
            if (exist)
                _database.KeyDelete(key);
            else
                return;
        }
        public void SetCache<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expirtyTime = expirationTime.DateTime.Subtract(DateTime.Now);
            _database.StringSet(key, JsonSerializer.Serialize<T>(value), expirtyTime);
        }
    }
}
