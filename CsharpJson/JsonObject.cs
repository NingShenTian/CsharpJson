using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CsharpJson
{
    public class JsonObject : Base,IEnumerable
    {
        Dictionary<string,JsonValue> items;
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonObject"/> class.
        /// </summary>
        public JsonObject()
        {
            this.items=new Dictionary<string,JsonValue>();
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
        /// <param name="value">If set to <c>true</c> value.</param>
        public void Add(string key,bool value)
        {
            JsonValue val = new JsonValue(value);
            this.Add(key, val);
        }
        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(string key,int value)
        {
            JsonValue val = new JsonValue(value);
            this.Add(key,val);
        }
        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(string key,double value)
        {
            JsonValue val=new JsonValue(value);
            this.Add(key,val);
        }
        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(string key,ulong value )
        {
            JsonValue val = new JsonValue(value);
            this.Add(key, val);
        }
        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(string key,string value)
        {
            JsonValue val = new JsonValue(value);
            this.Add(key, val);
        }
        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(string key, JsonArray value)
        {
            JsonValue val = new JsonValue(value);
            this.Add(key, val);
        }
        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(string key,JsonObject value)
        {
            JsonValue val = new JsonValue(value);
            this.Add(key, val);
        }
        /// <summary>
        /// Add the specified key and value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public void Add(string key, JsonValue value)
        {
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
        /// if Containses the key return true otherwise false.
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
    }
}
