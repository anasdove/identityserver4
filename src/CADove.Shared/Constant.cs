namespace CADove.Shared
{
    public static class Constant
    {
        public const string BASE_URI = "http://localhost:5005";
        public const string API_BASE_URI = "http://localhost:5006/api/";

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
    }
}
