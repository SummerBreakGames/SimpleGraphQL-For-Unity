using System;
using System.Text;
using System.Text.Json;
using JetBrains.Annotations;

namespace SimpleGraphQL
{
    [Serializable]
    public class Request
    {
        public string Query { get; set; }

        [CanBeNull]
        public string OperationName { get; set; }

        public object Variables { get; set; }

        public override string ToString()
        {
            return $"GraphQL Request:\n{this.ToJson(true)}";
        }
    }

    [PublicAPI]
    public static class RequestExtensions
    {
        private static JsonSerializerOptions defaultSerializerSettings = new()
            { };

        public static byte[] ToBytes(this Request request, JsonSerializerOptions serializerSettings = null)
        {
            return Encoding.UTF8.GetBytes(request.ToJson(false, serializerSettings));
        }

        public static string ToJson(this Request request, bool prettyPrint = false,
            JsonSerializerOptions serializerSettings = null)
        {
            if (serializerSettings == null)
            {
                serializerSettings = defaultSerializerSettings;
            }

            return JsonSerializer.Serialize(request, serializerSettings);
        }
    }
}