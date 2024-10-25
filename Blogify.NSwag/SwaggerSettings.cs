namespace Blogify.NSwag
{
    public class SwaggerSettings
    {
        public string BaseUrl { get; set; } = "https://localhost:7777/swagger/docs";
        public List<ApiClientSettings> Apis { get; set; } =
        [
            new ApiClientSettings{Name ="Core", Versions = ["v1"] },
            new ApiClientSettings{Name ="Auth",Versions =  ["v1"] },
        ];

        public class ApiClientSettings
        {
            public string Name { get; set; }
            public List<string> Versions { get; set; }
        }

    }
}
