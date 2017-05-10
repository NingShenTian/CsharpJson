//
//  JsonValue.cs
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

namespace CsharpJson
{
    /// <summary>
    /// JsonValue type.
    /// </summary>
     public enum ValueType
    {
        NULL = 0x0,
        BOOL = 0x1,
        NUMBER = 0x2,
        STRING = 0x3,
        ARRAY = 0x4,
        OBJECT = 0x5,
        UNDEFINED = 0x80
    }
    /// <summary>
    /// Json value.
    /// </summary>
    public sealed class JsonValue
    {
        private BaseType value;
        private ValueType type;
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        public JsonValue()
        {
            type = ValueType.NULL;
            this.value = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">If set to <c>true</c> value.</param>
        public JsonValue(bool value)
        {
            type = ValueType.BOOL;
            this.value = new JsonBool(value);
        }
        public static implicit operator JsonValue(bool value)
        {
            return new JsonValue(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public JsonValue(int value)
        {
            type = ValueType.NUMBER;
            this.value = new JsonDouble(value);
        }
        public static implicit operator JsonValue(int value)
        {
            return new JsonValue(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public JsonValue(double value)
        {
            type = ValueType.NUMBER;
            this.value = new JsonDouble(value);
        }
        public static implicit operator JsonValue(double value)
        {
            return new JsonValue(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public JsonValue(string value)
        {
            type = ValueType.STRING;
            this.value = new JsonString(value);
        }
        public static implicit operator JsonValue(string value)
        {
            return new JsonValue(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public JsonValue(JsonArray value)
        {
            type = ValueType.ARRAY;
            this.value =value;
        }
        public static implicit operator JsonValue (JsonArray value)
        {
            return new JsonValue(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public JsonValue(JsonObject value)
        {
            type = ValueType.OBJECT;
            this.value=value;
        }
        public static implicit operator JsonValue (JsonObject value)
        {
            return new JsonValue(value);
        }
        /// <summary>
        /// Is null.
        /// </summary>
        /// <returns><c>true</c>, if null was ised, <c>false</c> otherwise.</returns>
        public bool isNull()
        {
            return type == ValueType.NULL;
        }
        /// <summary>
        /// Is bool.
        /// </summary>
        /// <returns><c>true</c>, if bool was ised, <c>false</c> otherwise.</returns>
        public bool isBool()
        {
            return type == ValueType.BOOL;
        }
        /// <summary>
        /// Is double.
        /// </summary>
        /// <returns><c>true</c>, if double was ised, <c>false</c> otherwise.</returns>
        public bool isNumber()
        {
            return type == ValueType.NUMBER;
        }
        /// <summary>
        /// Is string.
        /// </summary>
        /// <returns><c>true</c>, if string was ised, <c>false</c> otherwise.</returns>
        public bool isString()
        {
            return type == ValueType.STRING;
        }
        /// <summary>
        /// Ises array.
        /// </summary>
        /// <returns><c>true</c>, if array was ised, <c>false</c> otherwise.</returns>
        public bool isArray()
        {
            return type == ValueType.ARRAY;
        }
        /// <summary>
        /// Is object.
        /// </summary>
        /// <returns><c>true</c>, if object was ised, <c>false</c> otherwise.</returns>
        public bool isObject()
        {
            return type == ValueType.OBJECT;
        }
        /// <summary>
        /// Is undefined.
        /// </summary>
        /// <returns><c>true</c>, if undefined was ised, <c>false</c> otherwise.</returns>
        public bool isUndefined()
        {
            return type == ValueType.UNDEFINED;
        }
        /// <summary>
        /// Gets the Value Type.
        /// </summary>
        /// <value>The gettype.</value>
        public ValueType Valuetype
        {
            get { return this.type;}
        }
        /// <summary>
        /// To the bool.
        /// </summary>
        /// <returns><c>true</c>, if bool was toed, <c>false</c> otherwise.</returns>
        public bool ToBool()
        {
            if(!this.isBool())
            {
                throw new FormatException();
            }
            return ((JsonBool)this.value).Value;
        }
        /// <summary>
        /// To the int.
        /// </summary>
        /// <returns>The int.</returns>
        public int ToInt()
        {
            if (!this.isNumber())
            {
                throw new FormatException();
            }
            return (int)((JsonDouble)this.value).Value;
        }
        /// <summary>
        /// To the double.
        /// </summary>
        /// <returns>The double.</returns>
        public double ToDouble()
        {
            if (!this.isNumber())
            {
                throw new FormatException();
            }
            return ((JsonDouble)this.value).Value;
        }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="CsharpJson.JsonValue"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="CsharpJson.JsonValue"/>.</returns>
        public string ToJsonString()
        {
            return this.value.ToJsonString();
        }
        /// <summary>
        /// To the array.
        /// </summary>
        /// <returns>The array.</returns>
        public JsonArray ToArray()
        {
            if (!this.isArray())
            {
                throw new FormatException();
            }
            return (JsonArray)this.value;
        }
        /// <summary>
        /// To the object.
        /// </summary>
        /// <returns>The object.</returns>
        public JsonObject ToObject()
        {
            if (!this.isObject())
            {
                throw new FormatException();
            }
            return (JsonObject)this.value;
        }
        /// <summary>
        /// To the string.
        /// </summary>
        /// <returns>The string.</returns>
        public  string ToStr()
        {
            if (!this.isString())
            {
                throw new FormatException();
            }
            return ((JsonString)this.value).Value;
        }
    }
    /// <summary>
    /// Base type.
    /// </summary>
     public class BaseType
    {
        public BaseType()
        {
            //nothing
        }
        public virtual string ToJsonString()
        {
            return "";
        }
    }
    /// <summary>
    /// Json bool.
    /// </summary>
     sealed class JsonBool:BaseType
    {
        private bool value;
        public JsonBool(bool val)
        {
            this.value = val;
        }
        public bool Value
        {
            get{ return this.value;}
            set{this.value=value;}
        }
        public override string ToJsonString()
        {
            return value.ToString().ToLower();
        }
    }
    /// <summary>
    /// Json double.
    /// </summary>
    sealed class JsonDouble :BaseType
    {
        private double value;
        public JsonDouble(double val)
        {
            this.value =val;
        }
        public double Value
        {
            get{ return this.value;}
            set{this.value=value;}
        }
        public override string ToJsonString()
        {
            return value.ToString();
        }
    }
    /// <summary>
    /// Json string.
    /// </summary>
    sealed class JsonString :BaseType
    {
        private string value;
        public JsonString(string val)
        {
            this.value=val;
        }
        public string Value
        {
            get{ return this.value;}
            set{this.value=value;}
        }
        public override string ToJsonString()
        {
            return "\""+value+"\"";
        }
    }
}

