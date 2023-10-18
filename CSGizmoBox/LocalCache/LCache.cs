using System.Data.SqlTypes;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace CSGizmoBox.LocalCache
{
    public class LCache
    {

        private static Dictionary<object, Content> _storage = new Dictionary<object, Content>();

    
        public static void Add(object key, object value, long ttlSeconds = 999999)
        {
            long _ttl = ttlSeconds;
            if (ttlSeconds != 999999)
            {
                var ttlDateTime = DateTime.Now.AddSeconds(ttlSeconds);
                long timestamp = ((DateTimeOffset)ttlDateTime).ToUnixTimeSeconds();

                _ttl = timestamp;
            }


            _storage[key] = new Content()
            {
                _value = value,
                ttl = _ttl
            };

        }


        public static object? Get(object key, object defaultValue = null, bool addIfNotFound = false, long ttlSeconds = 999999)
        {
            if (_storage.Keys.Contains(key))
            {
                Content _content = _storage[key];

                if (_content.ttl == 999999)
                {
                    return _content._value;
                }
                else
                {
                    long _now = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
                    if (_now > _content.ttl)
                    {
                        LCache.Remove(key);
                        return defaultValue;
                    }
                    else { 
                        return _content._value;
                    }
                }
            }
            else 
            { 
                if (addIfNotFound)
                {
                    LCache.Add(key, defaultValue, ttlSeconds);
                }
                return defaultValue;
            }
        }




        public static void Remove(object key)
        {
            _storage.Remove(key);
        }





        public static string Dump()
        {
            return JsonSerializer.Serialize(_storage);
        }




    }
}
