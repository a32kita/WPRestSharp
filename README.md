# WPRestSharp
WPRestSharp is client library for utilize WordPress REST API. 
**Since it's a development version, there's a possibility that the specifications may change in the future.**

## Get started
WPRestSharp enables easy utilization of WordPress's REST API from .NET applications.

### Example 1: Retrieve the 5 latest posts with anonymous access
```csharp
using System;
using WPRestSharp;

class Program
{
    static async Task Main(string[] args)
    {
        // Step 1: Initialize the client
        var connInfo = new WPRestConnectionInfo()
            .SetBaseUrl("https://example.com/")
            .SetAnonymoys();
        var wpSv = await WPRestService.CreateAsync(connInfo);
        
        // Step 2: Retrieve posts
        var posts = await wpSv.Posts.GetAsync(new() { PerPage = 5, Order = WPRestQueryOrder.Asc });

        foreach (var p in posts)
        {
            Console.WriteLine("Title: {0}", p.Title);
        }
    }
}
```

### Example 2: Publish a post using Application Password
```csharp
using System;
using WPRestSharp;

class Program
{
    static async Task Main(string[] args)
    {
        // Step 1: Initialize the client
        var connInfo = new WPRestConnectionInfo()
            .SetBaseUrl("https://example.com/")
            .SetUser("admin.test")
            .SetApplicationPassword("xxxx xxxx xxxx xxxx xxxx xxxx");
        var wpSv = await WPRestService.CreateAsync(connInfo);

        // Step 2: Make a post
        var newPost = wpSv.Posts.PostAsync(new()
        {
            Status = WPRestStatus.Publish,
            Title = new WPRestRenderableText() { Raw = DateTime.Now + ": Test Article" },
            Content = new WPRestRenderableText() { Raw = "hello, world !!" },
            Categories = new WPRestCategoryId[] { 1 },
            CommentStatus = WPRestReactionStatus.Closed,
            PingStatus = WPRestReactionStatus.Open,
        });

        Console.WriteLine("Published at: {0}", newPost.Date);
    }
}
```
