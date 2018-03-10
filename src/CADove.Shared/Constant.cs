using System;

namespace CADove.Shared
{
    public static class Constant
    {
        public const string BASE_URI = "http://localhost:5005";
        public const string API_BASE_URI = "http://localhost:5006/api/";

        public struct ApiResource
        {
            public const string NAME = "CADoveApi";
            public const string DISPLAY = "CA Dove API";
        }

        public struct Client
        {
            public const string CLIENT_ID = "CADoveClientId";
            public const string SECRET = "secret";
        }
    }
}
