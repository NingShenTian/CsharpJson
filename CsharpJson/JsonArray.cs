//
// JsonArray.cs
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
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CsharpJson
{
    public sealed class JsonArray :BaseType,IEnumerable
    {
        //默认情况下字符串的平均最大长度,这里预估20个字符
        private readonly int DEFAULT_MAX_LENGHT = 40;
        List<JsonValue> arrylist;
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonArray"/> class.
        /// </summary>
        public JsonArray()
        {
            arrylist = new List<JsonValue>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonArray"/> class.
        /// </summary>
        /// <param name="arr">Arr.</param>
        public JsonArray(JsonArray arr)
        {
            for (int i = 0; i < arr.Count; ++i)
            {
                this.arrylist.Add(arr[i]);
            }
        }
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return this.arrylist.Count; }
        }
        /// <summary>
        /// Gets or sets the <see cref="CsharpJson.JsonArray"/> with the specified i.
        /// </summary>
        /// <param name="i">The index.</param>
        public JsonValue this [int i]
        {
            get
            {
                if (i >= this.arrylist.Count)
                {
                    return null;
                }
                else
                {
                    return this.arrylist[i];
                }
            }
            set
            {
                this.arrylist.Add(value);
            }
        }
        public void Add(int[]values)
        {
            for (int i = 0; i < values.Length; ++i)
            {
                JsonValue val = new JsonValue(values[i]);
                this.arrylist.Add(val);
            }
        }
        public void Add(double[]values)
        {
            for (int i = 0; i < values.Length; ++i)
            {
                JsonValue val = new JsonValue(values[i]);
                this.arrylist.Add(val);
            }
        }
        public void Add(string[]values)
        {
            for (int i = 0; i < values.Length; ++i)
            {
                JsonValue val = new JsonValue(values[i]);
                this.arrylist.Add(val);
            }
        }
        public void Add(List<string> strlist)
        {
            foreach(string iter in strlist)
            {
                this.arrylist.Add(iter);
            }
        }
        /// <summary>
        /// Add the JsonValue value.
        /// </summary>
        /// <param name="value">Value.</param>
        public void Add(JsonValue value)
        {
            this.arrylist.Add(value);
        }
        /// <summary>
        /// if Contains the JsonValue item return true otherwise false.
        /// </summary>
        /// <param name="item">Item.</param>
        public bool Contains(JsonValue item)
        {
            return this.arrylist.Contains(item);
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.arrylist.GetEnumerator();
        }
        /// <summary>
        /// paser json array to string.
        /// </summary>
        /// <returns>The json string.</returns>
        public override string ToJsonString()
        {
            StringBuilder str = new StringBuilder(this.arrylist.Count * DEFAULT_MAX_LENGHT);
            str.Append("[");
            foreach (JsonValue  item in this.arrylist)
            {
                switch (item.Valuetype)
                {
                    case ValueType.NULL:
                        str.AppendFormat("{0},","null");
                        break;
                    case ValueType.BOOL:
                        str.AppendFormat("{0},", item.ToJsonString());
                        break;
                    case ValueType.NUMBER:
                        str.AppendFormat("{0},", item.ToDouble());
                        break;
                    case ValueType.STRING:
                        str.AppendFormat("{0},", item.ToJsonString());
                        break;
                    case ValueType.ARRAY:
                        str.AppendFormat("{0},", item.ToJsonString());
                        break;
                    case ValueType.OBJECT:
                        str.AppendFormat("{0},", item.ToJsonString());
                        break;
                }
            }
            str.Replace(',', ']', str.Length-1, 1);
            return str.ToString();
        }
    }
}

