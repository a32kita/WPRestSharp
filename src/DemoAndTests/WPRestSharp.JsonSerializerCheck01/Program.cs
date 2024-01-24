using System.Text.Json.Serialization;
using System.Text.Json;

namespace WPRestSharp.JsonSerializerCheck01
{
    public class MyClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        // JsonPropertyName属性を使用して、JSONでのプロパティ名を指定
        //[JsonPropertyName("custom_email")]
        public string CustomEmail { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // パスカルケースでクラスを作成
            var myObject = new MyClass
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                CustomEmail = "john.doe@example.com"
            };

            // オブジェクトをJSONにシリアライズ（スネークケース）
            string jsonString = JsonSerializer.Serialize(myObject, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower // スネークケースに変換
            });

            Console.WriteLine("Serialized JSON (Snake Case):");
            Console.WriteLine(jsonString);

            // JSONをオブジェクトにデシリアライズ
            MyClass deserializedObject = JsonSerializer.Deserialize<MyClass>(jsonString, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower // スネークケースから変換
            });

            Console.WriteLine("\nDeserialized Object:");
            Console.WriteLine($"First Name: {deserializedObject.FirstName}");
            Console.WriteLine($"Last Name: {deserializedObject.LastName}");
            Console.WriteLine($"Age: {deserializedObject.Age}");
            Console.WriteLine($"Custom Email: {deserializedObject.CustomEmail}");

            // ↑ ChatGPT より ↑

            Console.ReadKey();
        }
    }
}