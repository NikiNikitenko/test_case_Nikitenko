using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace test_case_Nikitenko.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        readonly string urlProfile;

        public HtmlLoader(iParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}";
            urlProfile = $"{settings.ProfileUrl}{settings.ProfilePrefix}";
        }

        public async Task<string> GetSourceByPageId (int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }

        public async Task<string> GetSourceProfileByPageId(string id)
        {
            var currentUrl = urlProfile.Replace("{CurrentId}", id);
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
