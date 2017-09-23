
基于C#的通用Json解析库！</br>
GitHub:https://github.com/NingShenTian/CsharpJson   
码云：https://git.oschina.net/xiaoguozhier/CsharpJson   
##### 1.说明：
　　1. 将JsonObject.cs、JsonArray.cs、JsonValue.cs、JsonDocument.cs 4个文件直接添加到你的项目中使用   
　　2. 或将CsharpJson整个项目直接生成得到CsharpJson.dll通过引用的方式添加到项目中使用   
　　3. 本Json库支持所有的C#版本包括Linux MonoDevelop，事实上该项目是在Ubuntu Linux上用MonoDevelop和WIndows下VS交替完成的。
##### 2.具体使用：
生成Json：
``` cs
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
            obj.Add("NULL",null);
            obj.Add("childobj", child);
            obj.Add("arrayvalue", arr);
            JsonDocument doc=new JsonDocument();
            doc.Object=obj;
            string val = doc.ToJson();
            Console.WriteLine("生成的Json字符串：");
            Console.WriteLine(val);
        }
    }
}
```
执行结果：
``` json
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
解析Josn：
``` cs
string data = "{\"中国\": \"china\",\"北京\": true,\"上海\": 123}";
JsonDocument doc = JsonDocument.FromString(data);
if(doc.IsObject())
{
    JsonObject jsobj = doc.Object;
    foreach(string key in jsobj.Keys)
    {
        switch(jsobj[key].Valuetype)
        {
            case JsonType.BOOL:
                Console.WriteLine("key={0},value={1}",key,jsobj[key].ToBool());
                break;
            case JsonType.NUMBER:
                Console.WriteLine("key={0},value={1}",key,jsobj[key].ToInt());
                break;
            case JsonType.STRING:
                Console.WriteLine("key={0},value={1}",key,jsobj[key].ToString());
                break;
        }
    }
}
```
