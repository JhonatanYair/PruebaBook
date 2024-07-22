namespace FrontendBook.Common
{
    public static class SharedUtils
    {
        public static string urlEndpoint = UrlDefined();

        private static string UrlDefined()
        {
            string ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string urlReturn;

            if (ASPNETCORE_ENVIRONMENT == "Development")
            {
                urlReturn = "http://localhost:5093/api";
            }
            else
            {
                urlReturn = "http://apibook:8080/api";

            }
            return urlReturn;
        }

    }
}
