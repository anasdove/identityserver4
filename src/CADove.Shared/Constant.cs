namespace CADove.Shared
{
    public static class Constant
    {
        public const string AUTH_BASE_URI = "http://localhost:5005";
        public const string API_BASE_URI = "http://localhost:5006/api/";

        public const string IDENTITY_SERVER = "IdentityServer";

        public struct ApiResource
        {
            public const string SCOPE_NAME = "CADoveApi";
            public const string DISPLAY = "CA Dove API";
        }

        public struct Client
        {
            public const string CLIENT_ID = "CADoveClientId";
            public const string SECRET = "secret";
        }

        public struct ClientGoogle
        {
            public const string CLIENT_ID = "708996912208-9m4dkjb5hscn7cjrn5u0r4tbgkbj1fko.apps.googleusercontent.com";
            public const string SECRET = "wdfPY6t8H8cecgjlxud__4Gh";
        }

        public struct CAUser
        {
            public const string SUBJECT = "SubjectChoirulAnas";
            public const string USERNAME = "ChoirulAnas";
            public const string PASSWORD = "ZXasqw12";
        }

        public struct AadilahUser
        {
            public const string SUBJECT = "SubjectAadilah";
            public const string USERNAME = "Aadilah";
            public const string PASSWORD = "ZXasqw12";
        }

        public struct AuthenticationScheme
        {
            public const string GOOGLE = "Google";
            public const string OPEN_ID_CONNECT = "demoidsrv";
        }
    }
}
