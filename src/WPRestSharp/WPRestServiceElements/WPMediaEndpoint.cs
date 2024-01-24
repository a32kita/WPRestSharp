using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPRestSharp.WPRestServiceElements
{
    public class WPMediaEndpoint : WPEndpointBase
    {
        internal WPMediaEndpoint(HttpClient httpClient, WPRestConnectionInfo connectionInfo)
            : base(httpClient, connectionInfo)
        {
            // NOP
        }

        public async Task<WPRestMedia> PostAsync(WPRestMediaFile mediaFile)
        {
            return await this.HttpPostFileAsync<WPRestMedia>("media", mediaFile);
        }
    }
}
