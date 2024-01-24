using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPRestSharp.WPRestServiceElements;

namespace WPRestSharp
{
    public class WPRestService : IDisposable
    {
        private bool _isDisposed;
        private HttpClient _httpClient;


        public WPUserEndpoint Users
        {
            get;
            private set;
        }

        public WPPostEndpoint Posts
        {
            get;
            private set;
        }

        public WPCategoryEndpoint Categories
        {
            get;
            private set;
        }

        public WPMediaEndpoint Media
        {
            get;
            private set;
        }


        private WPRestService()
        {
            this._isDisposed = false;
            this._httpClient = new HttpClient();
        }

        private async Task _initialize(WPRestConnectionInfo connectionInfo)
        {
            await Task.Delay(10);

            this.Users = new WPUserEndpoint(this._httpClient, connectionInfo);
            this.Posts = new WPPostEndpoint(this._httpClient, connectionInfo);
            this.Categories = new WPCategoryEndpoint(this._httpClient, connectionInfo);
            this.Media = new WPMediaEndpoint(this._httpClient, connectionInfo);
        }



        private void _checkDisposed()
        {
            if (this._isDisposed)
                throw new ObjectDisposedException(this.GetType().FullName);
        }


        public void Dispose()
        {
            if (this._isDisposed)
                return;

            this._isDisposed = true;
        }


        public static async Task<WPRestService> CreateAsync(WPRestConnectionInfo connectionInfo)
        {
            if (connectionInfo.IsValid() == false)
                throw new InvalidOperationException();

            var wpRestService = new WPRestService();
            await wpRestService._initialize(connectionInfo);

            return wpRestService;
        }
    }
}
