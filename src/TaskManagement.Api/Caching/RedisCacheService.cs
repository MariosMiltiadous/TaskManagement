using StackExchange.Redis;
using System.Text.Json;

namespace TaskManagement.Api.Caching
{
    public class RedisCacheService
    {
        private readonly IDatabase _cache;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }

        public async Task SetCacheAsync(string key, object data, TimeSpan expiration)
        {
            var jsonData = JsonSerializer.Serialize(data);
            await _cache.StringSetAsync(key, jsonData, expiration);
        }

        public async Task<T?> GetCacheAsync<T>(string key)
        {
            var data = await _cache.StringGetAsync(key);
            return data.HasValue ? JsonSerializer.Deserialize<T>(data) : default;
        }
    }
}
