//
// JsonObject.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpJson
{
    public sealed class JsonObject : BaseType,IEnumerable
    {
        //默认字符串的平均最大长度
        //为了提高字符串的拼接性能，需要提前预估分配内存，避免StringBuild频繁申请内存
        private readonly int DEFAULT_MAX_LENGHT = 40;
        Dictionary<string,JsonValue> items;
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonObject"/> class.
        /// </summary>
        public JsonObject()
        {
            this.items = new Dictionary<string,JsonValue>();
        }
        /// <summary>
        /// Gets or sets the <see cref="CsharpJson.JsonObject"/> with the string key.
        /// </summary>
        /// <param name="key">Key.</param>
        public JsonValue this [string key]
        {
            get
            {
                if (this.items.ContainsKey(key))
                {
                    return items[key];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (items.ContainsKey(key))
                {
                    this.items[key] = value;
                }
                else
                {
                    this.items.Add(key, value);
                }
            }
        }
        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(string key, JsonValue value)
        {
            if (key == null)
            {
                throw new AggregateException();
            }
            if (this.items.ContainsKey(key))
            {
                this.items[key] = value;
            }
            else
            {
                this.items.Add(key, value);
            }
        }
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }
        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <value>The keys.</value>
        public ICollection<string> Keys
        {
            get
            {
                return this.items.Keys;
            }
        }
        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <value>The values.</value>
        public ICollection<JsonValue> Values
        {
            get
            {
                return this.items.Values;
            }
        }
        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            this.items.Clear();
        }
        /// <summary>
        /// if Containses the key return true otherwise return false.
        /// </summary>
        /// <returns><c>true</c>, if key was containsed, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        public bool ContainsKey(string key)
        {
            return this.items.ContainsKey(key);
        }
        /// <summary>
        /// Remove the item by specified key.
        /// </summary>
        /// <param name="key">Key.</param>
        public bool Remove(string key)
        {
            if (this.ContainsKey(key))
            {
                this.items.Remove(key);
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Tries the get value.
        /// </summary>
        /// <returns><c>true</c>, if get value was tryed, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public bool TryGetValue(string key, out JsonValue value)
        { 
            if (this.items.ContainsKey(key))
            {
                value = this.items[key];
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }
        /// <summary>
        /// To the json string.
        /// </summary>
        /// <returns>The json string.</returns>
        public override string ToJsonString()
        {
            StringBuilder str = new StringBuilder(this.items.Count * 2 * DEFAULT_MAX_LENGHT);
            str.Append("{");
            foreach (KeyValuePair<string,JsonValue>  item in items)
            {
                switch (item.Value.Valuetype)
                {
                    case ValueType.NULL:
                        str.AppendFormat("\"{0}\":{1},", item.Key,"null");
                        break;
                    case ValueType.BOOL:
                        str.AppendFormat("\"{0}\":{1},", item.Key, item.Value.ToJsonString());
                        break;
                    case ValueType.NUMBER:
                        str.AppendFormat("\"{0}\":{1},", item.Key, item.Value.ToDouble());
                        break;
                    case ValueType.STRING:
                        str.AppendFormat("\"{0}\":{1},", item.Key, item.Value.ToJsonString());
                        break;
                    case ValueType.ARRAY:
                        str.AppendFormat("\"{0}\":{1},", item.Key, item.Value.ToJsonString());
                        break;
                    case ValueType.OBJECT:
                        str.AppendFormat("\"{0}\":{1},",item.Key, item.Value.ToJsonString());
                        break;
                }
            }
            str.Replace(',', '}', str.Length-1, 1);
            return str.ToString();
        }
    }
}
