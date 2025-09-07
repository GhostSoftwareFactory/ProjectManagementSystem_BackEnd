

using ProjectManagementAPI.Config;
using StackExchange.Redis;
using System.Text.Json;

namespace ProjectManagementAPI.Infra
{
    public class RedisService
    {
        private readonly IDatabase _db;
        private string? connectionString = SettingConfiguration.GetSectionValue("Db", "RedisDb");

        public RedisService()
        {
            if(connectionString != null)
            {
                var redis = ConnectionMultiplexer.Connect(connectionString);
                _db = redis.GetDatabase();
            }

            throw new Exception("redis connection string not found");
        }

        // Save value with TTL (expiration)
        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            string json = JsonSerializer.Serialize(value);
            await _db.StringSetAsync(key, json, expiry);
        }

        // Save value without expiration
        public async Task SetPermanentAsync<T>(string key, T value)
        {
            string json = JsonSerializer.Serialize(value);
            await _db.StringSetAsync(key, json); // Sem expiry = permanece na memória
        }

        // Get a value
        public async Task<T?> GetAsync<T>(string key)
        {
            var json = await _db.StringGetAsync(key);
            if (json.IsNullOrEmpty) return default;
            return JsonSerializer.Deserialize<T>(json!);
        }

        // Set value
        public async Task RemoveAsync(string key)
        {
            await _db.KeyDeleteAsync(key);
        }
    }
}
