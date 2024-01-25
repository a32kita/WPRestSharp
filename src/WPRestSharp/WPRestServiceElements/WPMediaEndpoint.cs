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

        public async Task<IEnumerable<WPRestMedia>> GetAsync()
        {
            return await this.HttpGetAsync<WPVoidParameter, WPRestMedia[]>("media", new WPVoidParameter());
        }

        public async Task<WPRestMedia> GetAsync(WPRestMediaId id)
        {
            return await this.HttpGetAsync<WPVoidParameter, WPRestMedia>("media/" + id.ToString(), new WPVoidParameter());
        }

        public async Task<WPRestMedia> PostAsync(WPRestMediaFile mediaFile)
        {
            return await this.HttpPostFileAsync<WPRestMedia>("media", mediaFile);
        }
    }
}
