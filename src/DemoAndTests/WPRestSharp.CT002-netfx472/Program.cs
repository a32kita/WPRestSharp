using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPRestSharp.CT002_netfx472
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("初期化中 ...");
            var connInfo = new WPRestConnectionInfo()
                .SetBaseUrl("http://localhost:8317/")
                .SetAnonymoys();
            var wpSv = WPRestService.CreateAsync(connInfo).Result;

            Console.WriteLine("各種情報取得中 ...");
            var users = wpSv.Users.GetAsync().Result;
            Console.WriteLine(String.Join(", ", users.Select(item => item.Slug)));

            Console.ReadLine();
        }
    }
}
