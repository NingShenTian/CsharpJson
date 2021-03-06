﻿//
// Program.cs
//
// Author:
//       ning <springrain1991@hotmail.com>
//
// Copyright (c) 2016 ning
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using CsharpJson;

namespace test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
            Console.ReadLine();
        }
        /// <summary>
        /// 测试数据添加和基本Json生成
        /// </summary>
        public static void Test1()
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
            arr.Add(null);
            JsonObject obj = new JsonObject();
            obj.Add("中国", "china");
            obj.Add("北京", true);
            obj.Add("上海", 123);
            obj.Add("NULL", null);
            obj.Add("childobj", child);
            obj.Add("arrayvalue", arr);
            JsonDocument doc = new JsonDocument();
            doc.Object = obj;
            string val = doc.ToJson();
            Console.WriteLine("Json：");
            Console.WriteLine(val);
            Console.WriteLine();
        }
        /// <summary>
        /// 测试Json解析
        /// </summary>
        public static void Test2()
        {
            string data = "{\"student\":[{\"name\":\"Jim\",\"age\":8},{\"\name\":\"Tom\",\"age\":10}]}";
            JsonDocument doc = JsonDocument.FromString(data);

            if (doc.IsObject())
            {
                JsonObject jsobj = doc.Object;
                foreach (string key in jsobj.Keys)
                {
                    switch (jsobj[key].Valuetype)
                    {
                        case JsonType.BOOL:
                            Console.WriteLine("key={0},value={1}", key, jsobj[key].ToBool());
                            break;
                        case JsonType.NUMBER:
                            Console.WriteLine("key={0},value={1}", key, jsobj[key].ToInt());
                            break;
                        case JsonType.STRING:
                            {
                                string ss = jsobj[key].ToString();
                                Console.WriteLine("key={0},value={1}", key, jsobj[key].ToString());
                                break;
                            }
                        case JsonType.ARRAY:
                            foreach (JsonValue v in jsobj[key].ToArray())
                            {
                                switch (v.Valuetype)
                                {
                                    case JsonType.BOOL:
                                        Console.WriteLine("key={0}", v.ToBool());
                                        break;
                                    case JsonType.NUMBER:
                                        Console.WriteLine("key={0}", v.ToInt());
                                        break;
                                    case JsonType.STRING:
                                        Console.WriteLine("key={0}", v.ToString());
                                        break;
                                }
                            }
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// 将一个Json字符串当作一个string数据，
        /// 测试对字符串中双引号的处理
        /// </summary>
        public static void Test3()
        {
            JsonObject obj = new JsonObject();
            obj.Add("test", "{\"student\":[{\"name\":\"Jim\",\"age\":8,\"goodboy\":true},{\"name\":\"Tom\",\"age\":10,\"goodboy\":false}]}");
            JsonDocument doc = new JsonDocument();
            doc.Object = obj;
            string val = doc.ToJson();
            Console.WriteLine("生成的Json字符串：");
            Console.WriteLine(val);

            JsonDocument d = JsonDocument.FromString(val);
            if (d.IsObject())
            {
                JsonObject jsobj = d.Object;
                foreach (string key in jsobj.Keys)
                {
                    switch (jsobj[key].Valuetype)
                    {
                        case JsonType.BOOL:
                            Console.WriteLine("key={0},value={1}", key, jsobj[key].ToBool());
                            break;
                        case JsonType.NUMBER:
                            Console.WriteLine("key={0},value={1}", key, jsobj[key].ToInt());
                            break;
                        case JsonType.STRING:
                            {
                                string ss = jsobj[key].ToString();
                                Console.WriteLine("key={0},value={1}", key, jsobj[key].ToString());
                                break;
                            }
                    }
                }
            }
        }
        /// <summary>
        /// 测试对\的处理
        /// </summary>
        public static void Test4()
        {
            JsonObject obj = new JsonObject();
            obj.Add("test", "\\hello\\");
            JsonDocument doc = new JsonDocument();
            doc.Object = obj;
            string val = doc.ToJson();
            Console.WriteLine("生成的Json字符串：");
            Console.WriteLine(val);
            JsonDocument d = JsonDocument.FromString(val);
            if (d.IsObject())
            {
                JsonObject jsobj = d.Object;
                foreach (string key in jsobj.Keys)
                {
                    switch (jsobj[key].Valuetype)
                    {
                        case JsonType.BOOL:
                            Console.WriteLine("key={0},value={1}", key, jsobj[key].ToBool());
                            break;
                        case JsonType.NUMBER:
                            Console.WriteLine("key={0},value={1}", key, jsobj[key].ToInt());
                            break;
                        case JsonType.STRING:
                            {
                                string ss = jsobj[key].ToString();
                                Console.WriteLine("key={0},value={1}", key, jsobj[key].ToString());
                                break;
                            }
                    }
                }
            }
        }
        /// <summary>
        /// 测试对数字类型的处理
        /// </summary>
        public static void Test5()
        {
            double a = 1.87E+02;
            JsonObject obj = new JsonObject();
            obj.Add("num1", 1.87E+02);
            obj.Add("num2", -10);
            obj.Add("num3", -0.2);
            obj.Add("num4", +1024.88);
            
            JsonDocument doc = new JsonDocument();
            doc.Object = obj;
            string val = doc.ToJson();
            Console.WriteLine("生成的Json字符串：");
            Console.WriteLine(val);
            string data = "{\"num1\":187E+0.2,\"num2\":-10,\"num3\":-0.2,\"num4\":+1024.88}";
            JsonDocument d =JsonDocument.FromString(data);
            if(d.IsObject())
            {
                JsonObject o= d.Object;

            }


        }
    }
}
