using System;
using System.Collections.Generic;
using System.Collections;

namespace CsharpJson
{
    public class JsonArray :Base,IEnumerable
    {
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
            for(int i=0;i<arr.Count;++i)
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
            get { return this.arrylist.Count;}
        }
        /// <summary>
        /// Gets or sets the <see cref="CsharpJson.JsonArray"/> with the specified i.
        /// </summary>
        /// <param name="i">The index.</param>
        public JsonValue this[int i]
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
        /// <summary>
        /// Add the bool value.
        /// </summary>
        /// <param name="value">If set to <c>true</c> value.</param>
        public void Add(bool value)
        {
            JsonValue val = new JsonValue(value);
            this.arrylist.Add(val);
        }
        /// <summary>
        /// Add the int value.
        /// </summary>
        /// <param name="value">Value.</param>
        public void Add(int value)
        {
            JsonValue val = new JsonValue(value);
            this.arrylist.Add(val);
        }
        /// <summary>
        /// Add the double value.
        /// </summary>
        /// <param name="value">Value.</param>
        public void Add(double value)
        {
            JsonValue val = new JsonValue(value);
            this.arrylist.Add(val);
        }
        /// <summary>
        /// Add the ulong value.
        /// </summary>
        /// <param name="value">Value.</param>
        public void Add(ulong value)
        {
            JsonValue val = new JsonValue(value);
            this.arrylist.Add(val);
        }
        /// <summary>
        /// Add the string value.
        /// </summary>
        /// <param name="value">Value.</param>
        public void Add(string value)
        {
            JsonValue val = new JsonValue(value);
            this.arrylist.Add(val);
        }
        /// <summary>
        /// Add the JsonArray value.
        /// </summary>
        /// <param name="value">Value.</param>
        public void Add(JsonArray value)
        {
            JsonValue val = new JsonValue(value);
            this.arrylist.Add(val);
        }
        /// <summary>
        /// Add the JsonObject value.
        /// </summary>
        /// <param name="value">Value.</param>
        public void Add( JsonObject value)
        {
            JsonValue val = new JsonValue(value);
            this.arrylist.Add(val);
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
    }
}

