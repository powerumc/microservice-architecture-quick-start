using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Powerumc.RssFeeds.Extensions
{
    public static class ObjectExtension
    {
        private static readonly JsonSerializerSettings DefaultSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new JavaScriptDateTimeConverter()
            }
        };
        
        public static string ToJson(this object obj, JsonSerializerSettings settings = null)
        {
            return JsonConvert.SerializeObject(obj, settings ?? DefaultSettings);
        }

        public static T FromJson<T>(this string jsonStr, JsonSerializerSettings settings = null)
        {
			if(string.IsNullOrWhiteSpace(jsonStr))
				return default(T);

            return JsonConvert.DeserializeObject<T>(jsonStr, settings ?? DefaultSettings);
        }

		public static long ToTimeStamp(this DateTime dateTime)
		{
			return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
		}
    }
}