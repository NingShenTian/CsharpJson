//
//  JsonPaser.cs
//
//  Author:
//       田小宁 <springrain1991@hotmail.com>
//
//  Copyright (c) 2017 田小宁
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using CsharpJson;
namespace CsharpJson
{
    public sealed class JsonPaser
	{
        private string jsonString="";
        public JsonPaser(string jsonstr)
		{
            this.jsonString = jsonstr;
		}
        public JsonPaser()
        {
            
        }
        public string JsonString
        {
            get;
        }
        public JsonValue Paser()
        {
            return null;
        }
        public JsonValue Paser(string jsonstr)
        {
            if(jsonstr==null||jsonstr.Length<2)
            {
                return null;   
            }
            int index = 0;
            if (jsonstr[0] == '{')
            {
                return  GetObject(ref index,jsonstr);
            }
            else if (jsonstr[0] == '[')
            {
                return  GetArray(ref index,jsonstr);
            }
            else
            {
                return "error json format !";
            }
        }
        //{"中国":"china","北京":true,"上海":123,"childobj":{"china":"hello","shanghai":123,"one":"abc","two":12,"three":44.9},"arrayvalue":[true,100,"你好","12",456,false,{"china":"hello","shanghai":123,"one":"abc","two":12,"three":44.9}]}
        private JsonValue GetObject(ref int index,string strjson)
        {
            index++;
            JsonObject obj=new JsonObject();
            string key = "";
            bool iskey = true;
            while(index<strjson.Length)
            {
                switch(strjson[index])
                {
                    case ':':
                        iskey = false;
                        index++;
                        break;
                    case ' ':
                        index++;
                        break;
                    case '"':
                        if(iskey)
                        {
                            key= GetString(ref index,strjson);
                        }
                        else
                        {
                            obj.Add(key,GetString(ref index,strjson));  
                        }
                        break;
                    case '{':
                        obj.Add(key,GetObject(ref index,strjson));
                            break;
                    case 't':
                    case 'f':
                        obj.Add(key,Getbool(ref index,strjson));
                        break;
                    case ',':
                        iskey = true;
                        key = "";
                        index++;
                        break;
                    case '[':
                        obj.Add(key,GetArray(ref index, strjson));
                        break;
                    case '}':
                        ++index;
                        return obj;
                    default :
                        obj.Add(key,Getnumber(ref index,strjson));
                        break;
                }
            }
            Console.WriteLine("get object null");
            return null;
        }
        private JsonValue GetArray(ref int index,string strjson)
        {
            index++;
            JsonArray array=new JsonArray();
            while(index<strjson.Length)
            {
                switch(strjson[index])
                {
                    case '"':
                        array.Add(GetString(ref index,strjson));
                        break;
                    case ' ':
                        ++index;
                        break;
                    case '{':
                        array.Add(GetObject(ref index,strjson));
                        break;
                    case 't':
                    case 'f':
                        array.Add(Getbool(ref index,strjson));
                        break;
                    case ',':
                        index++;
                        break;
                    case '[':
                        array.Add(GetArray(ref index, strjson));
                        break;
                    case ']':
                        ++index;
                        return array;
                    default :
                        array.Add(Getnumber(ref index,strjson));
                        break;
                }
            }
            Console.WriteLine("get array null");
            return null;
        }

        private string GetString(ref int index,string jsonstr)
        {
            string str="";
            index++;
            for(;index<jsonstr.Length;++index)
            {
                switch(jsonstr[index])
                {
                    case '"':
                        index++;
                        return str;
                    default:
                        str+=jsonstr[index];
                        break;
                }
            }
            Console.WriteLine("getstring null");
            return null;
        }

        private JsonValue Getbool(ref int index,string strjson)
        {
            string strbool = "";
            for(;index<strjson.Length;++index)
            {
                if (strjson[index] != ',')
                {
                    strbool += strjson[index];
                }
                else
                {
                    break;
                }
            }
            if (strbool == "true")
            {
                return new JsonValue(true);
            }
            else if (strbool == "false")
            {
                return new JsonValue(false);
            }
            else
            {
                Console.WriteLine("getbool null");
                return new JsonValue();
            }
        }
        private JsonValue Getnumber(ref int index,string strjson)
        {
            string strbool = "";
            for(;index<strjson.Length;++index)
            {
                if(strjson[index]!=','&&strjson[index]!='}'&&strjson[index]!=']')
                {
                    strbool += strjson[index];
                }
                else
                {
                    break;
                }
            }
            double value;
            bool b = double.TryParse(strbool,out value);
            if (b)
            {
                return value;   
            }
            else
            {
                Console.WriteLine("getnumber null");
                return new JsonValue();
            }
        }
	}
}
//{"中国":"china","北京":true,"上海":123,"childobj":{"china":"hello","shanghai":123,"one":"abc","two":12,"three":44.9},"arrayvalue":[true,100,"你好","12",456,false,{"china":"hello","shanghai":123,"one":"abc","two":12,"three":44.9}]}
