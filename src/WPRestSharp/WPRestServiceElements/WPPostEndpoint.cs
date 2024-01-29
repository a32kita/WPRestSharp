using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPRestSharp.WPRestServiceElements
{
    public class WPPostEndpoint : WPEndpointBase
    {
        internal WPPostEndpoint(HttpClient httpClient, WPRestConnectionInfo connectionInfo)
            : base(httpClient, connectionInfo)
        {
            // NOP
        }

        public async Task<IEnumerable<WPRestPost>> GetAsync()
        {
            return await this.HttpGetAsync<WPVoidParameter, WPRestPost[]>("posts", EmptyDictionary, new WPVoidParameter());
        }

        public async Task<IEnumerable<WPRestPost>> GetAsync(WPRestPostQueryParameter parameter)
        {
            return await this.HttpGetAsync<WPVoidParameter, WPRestPost[]>("posts", parameter.ToDictionary(), new WPVoidParameter());
        }

        public async Task<WPRestPost> GetAsync(WPRestPostId id, WPRestPostQueryParameter parameter)
        {
            return await this.HttpGetAsync<WPVoidParameter, WPRestPost>("posts/" + id.ToString(), parameter.ToDictionary(), new WPVoidParameter());
        }

        public async Task<WPRestPost> PostAsync(WPRestPost post)
        {
            return await this.HttpPostAsync<WPRestPost, WPRestPost>("posts", EmptyDictionary, post);
        }
    }
}
