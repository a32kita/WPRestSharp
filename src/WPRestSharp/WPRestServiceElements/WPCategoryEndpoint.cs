using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPRestSharp.WPRestServiceElements
{
    public class WPCategoryEndpoint : WPEndpointBase
    {
        internal WPCategoryEndpoint(HttpClient httpClient, WPRestConnectionInfo connectionInfo)
            : base(httpClient, connectionInfo)
        {
            // NOP
        }

        public async Task<IEnumerable<WPRestCategory>> GetAsync()
        {
            return await this.HttpGetAsync<WPVoidParameter, WPRestCategory[]>("categories", new WPVoidParameter());
        }
    }
}
