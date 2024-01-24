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

            Console.WriteLine("各種情報取得中 ...");
            var users = wpSv.Users.GetAsync().Result;
            var posts = wpSv.Posts.GetAsync().Result;
            var categories = wpSv.Categories.GetAsync().Result;

            var rndCategory = categories.ToArray()[new Random().Next(categories.Count() - 1) + 1];

            Console.WriteLine("記事投稿中 ...");
            var newPost = wpSv.Posts.PostAsync(new WPRestPost()
            {
                Status = "publish",
                Slug = DateTime.Now.ToString("yyyyMMdd-HHmmss-fff_") + Guid.NewGuid().ToString().Split('-').Last(),
                Title = new WPRenderableText() { Raw = DateTime.Now + ": テスト記事" },
                Content = new WPRenderableText() { Raw = "ほげえええええ" },
                Categories = new WPRestCategoryId[]
                {
                    //new WPRestCategoryId() { Value = 0 },
                    rndCategory.Id
                }
            }).Result;

            Console.WriteLine("完了");
            Console.ReadLine();
        }
    }
}