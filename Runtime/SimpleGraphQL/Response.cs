using JetBrains.Annotations;
using UnityEngine.Scripting;

namespace SimpleGraphQL
{
    [PublicAPI]
    [Preserve]
    public class Response<T>
    {
        public T Data { get; set; }

        [CanBeNull]
        public Error[] Errors { get; set; }

        [Preserve] // Ensures it survives code-stripping
        public Response()
        {
        }
    }

    [PublicAPI]
    [Preserve]
    public class Error
    {
        public string Message { get; set; }

        [CanBeNull]
        public Location[] Locations { get; set; }

        [CanBeNull]
        public Extensions Extensions { get; set; }

        [CanBeNull]
        public object[] Path { get; set; } // Path objects can be either integers or strings

        [Preserve] // Ensures it survives code-stripping
        public Error()
        {
        }
    }

    [PublicAPI]
    [Preserve]
    public class Extensions
    {
        public string Code { get; set; }

        [Preserve] // Ensures it survives code-stripping
        public Extensions()
        {
        }
    }

    [PublicAPI]
    [Preserve]
    public class Location
    {
        public int Line { get; set; }

        public int Column { get; set; }

        [Preserve] // Ensures it survives code-stripping
        public Location()
        {
        }
    }
}