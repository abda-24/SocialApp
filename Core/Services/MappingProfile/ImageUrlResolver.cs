using Microsoft.Extensions.Configuration;

namespace Services.MappingProfile
{
    public class ImageUrlResolver
    {
        private readonly IConfiguration _configuration;

        public ImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                return string.Empty;

            var baseUrl = _configuration["Urls:BaseUrl"];

            if (string.IsNullOrWhiteSpace(baseUrl))
                return imageUrl; 

            return $"{baseUrl.TrimEnd('/')}/{imageUrl.TrimStart('/')}";
        }
    }
}
