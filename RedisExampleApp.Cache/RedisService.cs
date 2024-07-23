using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisExampleApp.Cache
{
    public class RedisService
    {
        private readonly ConnectionMultiplexer _connectionMultip;
        public RedisService(string url)
        {
            _connectionMultip = ConnectionMultiplexer.Connect("url");
        }
        public IDatabase GetDb(int dbIndex)
        {
            return _connectionMultip.GetDatabase(dbIndex);
        }
    }
}
