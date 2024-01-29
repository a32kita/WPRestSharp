using System.Net;
using System.Runtime.CompilerServices;

namespace WPRestSharp.CT001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("初期化中 ...");
            var connInfo = new WPRestConnectionInfo()
                .SetBaseUrl("http://localhost:8317/")
                .SetUser("admin.test")
                .SetApplicationPassword("0hF7 cDoh D2Ga 8n3r 8yjP Keh2")
                //.SetAnonymoys()
                ;
            var wpSv = WPRestService.CreateAsync(connInfo).Result;

#if TRUE
            Console.WriteLine("各種情報取得中 ...");
            var users = wpSv.Users.GetAsync().Result;
            var post = wpSv.Posts.GetAsync(67, new()).Result;
            var posts = wpSv.Posts.GetAsync(new() { PerPage = 5, Order = WPRestQueryOrder.Asc }).Result;
            var categories = wpSv.Categories.GetAsync().Result;
            var media = wpSv.Media.GetAsync(40, new()).Result;
            var mediaCol = wpSv.Media.GetAsync().Result;

            Console.WriteLine("ファイルのアップロード中 ...");
            var timeCodeStr = DateTime.Now.ToString("yyyyMMdd-HHmmss-fff");
            WPRestMedia newMedia = null;
            using (var httpClient = new HttpClient())
            using (var hres = httpClient.GetAsync("https://placehold.jp/3d4070/ffffff/600x300.png?text=" + Uri.EscapeDataString(timeCodeStr)).Result)
            using (var mediaFile = new WPRestMediaFile(hres.Content.ReadAsStream(), timeCodeStr + "-" + Guid.NewGuid().ToString().Split('-').Last() + ".png", "image/png"))
            {
                newMedia = wpSv.Media.PostAsync(mediaFile).Result;
            }

            var rndCategory = categories.ToArray()[new Random().Next(categories.Count() - 1) + 1];

            Console.WriteLine("記事投稿中 ...");
            var newPost = wpSv.Posts.PostAsync(new()
            {
                Status = WPRestStatus.Publish,
                Slug = DateTime.Now.ToString("yyyyMMdd-HHmmss-fff_") + Guid.NewGuid().ToString().Split('-').Last(),
                Title = new WPRestRenderableText() { Raw = DateTime.Now + ": テスト記事" },
                Content = new WPRestRenderableText() { Raw = "<h1>これは試験記事です</h1><p>段落段落段落段落段落段落段落段落<br/>2 行目！<br/></p><p>2 段落目段落段落段落段落段落段落段落</p>" },
                Categories = new WPRestCategoryId[]
                {
                    //new WPRestCategoryId() { Value = 0 },
                    rndCategory.Id
                },
                CommentStatus = WPRestReactionStatus.Closed,
                PingStatus = WPRestReactionStatus.Open,
            }).Result;
#endif

            //var targetPost = wpSv.Posts.GetAsync(new WPRestPostId() { Value = 1 }).Result;

            Console.WriteLine("完了");
            Console.ReadLine();
        }
    }
}