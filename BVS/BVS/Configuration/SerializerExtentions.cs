using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BVS.Configuration
{
    public static class SerializerExtentions
    {
        private static JsonSerializerSettings settings =>
            new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

        public static void SetComplex(this ISession session, string key, object obj)
        {
            session.SetString(key, JsonConvert.SerializeObject(obj, settings));
        }

        public static T GetComplex<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data, settings);
        }
    }
}
