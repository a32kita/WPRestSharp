using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPRestSharp.WPRestServiceElements
{
    public class WPUserEndpoint : WPEndpointBase
    {
        internal WPUserEndpoint(HttpClient httpClient, WPRestConnectionInfo connectionInfo)
            : base(httpClient, connectionInfo)
        {
            // NOP
        }

        public async Task<IEnumerable<WPRestUser>> GetAsync()
        {
            return await this.HttpGetAsync<WPVoidParameter, WPRestUser[]>("users", new WPVoidParameter());
        }
    }
}
