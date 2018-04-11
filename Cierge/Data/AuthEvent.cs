using System;

namespace Cierge.Data
{
    public class AuthEvent : AuthEvent<string>
    {

    }

    public class AuthEvent<TKey>
    {
        public string AuthEventId { get; set; }

        public TKey UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string ClientIPAddress { get; set; }

        public string ClientUserAgent { get; set; }

        public DateTimeOffset OccurrenceTime { get; set; }

        public AuthEventType Type { get; set; }

        public string Subject { get; set; }
    }

    public enum AuthEventType
    {
        Register,
        AddLogin,

        Login,

        EditUserInfo,

        RemoveLogin,
        //Delete
    }
}
