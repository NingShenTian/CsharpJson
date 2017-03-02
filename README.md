C#编写的通用Json解析程序！
当前已经实现了序列化，反序列化正在实现还没提交。
##### 1.添加到工程中,两种方法：
　　1. 将JsonObject.cs、JsonArray.cs、JsonValue.cs、JsonPaser.cs 4个文件直接添加到你的项目中</br>
　　2. 将CsharpJson整个项目直接生成得到CsharpJson.dll通过引用的方式添加到项目中
##### 2.具体使用：
```C#
using CsharpJson;
namespace test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            JsonObject child = new JsonObject();
            child["china"] = "hello";
            child["shanghai"] = 123;
            child.Add("one", "abc");
            child.Add("two", 12);
            child.Add("three", 44.9);

            JsonArray arr = new JsonArray();
            arr[0] = true;
            arr[1] = 100;
            arr[2] = "你好";
            arr.Add("12");
            arr.Add(456);
            arr.Add(false);
            arr.Add(child);

            JsonObject obj = new JsonObject();
            obj.Add("中国", "china");
            obj.Add("北京", true);
            obj.Add("上海", 123);
            obj.Add("childobj", child);
            obj.Add("arrayvalue", arr);

            Console.WriteLine("生成的Json字符串：");
            Console.WriteLine(obj.ToJsonString());
        }
    }
}
```
执行结果：
```
生成的Json字符串：
{
    "中国": "china",
    "北京": true,
    "上海": 123,
    "childobj": {
        "china": "hello",
        "shanghai": 123,
        "one": "abc",
        "two": 12,
        "three": 44.9
    },
    "arrayvalue": [
        true,
        100,
        "你好",
        "12",
        456,
        false,
        {
            "china": "hello",
            "shanghai": 123,
            "one": "abc",
            "two": 12,
            "three": 44.9
        }
    ]
}
```
