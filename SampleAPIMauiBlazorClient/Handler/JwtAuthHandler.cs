using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPIMauiBlazorClient.Handler
{
    public class JwtAuthHandler : DelegatingHandler
    {

        public JwtAuthHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await SecureStorage.Default.GetAsync("authToken");

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }
            catch (Exception ex)
            {
                var e = ex.Message;
                throw;
            }
            

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
