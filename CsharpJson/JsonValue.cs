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
        DOUBLE = 0x2,
        STRING = 0x3,
        ARRAY = 0x4,
        OBJECT = 0x5,
        ULONG = 0x6,
        INT =0x07,
        UNDEFINED = 0x80
    }
    /// <summary>
    /// Json value.
    /// </summary>
    public partial class JsonValue
    {
        private Base value;
        private ValueType type;
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        public JsonValue()
        {
            type = ValueType.NULL;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public JsonValue(int value)
        {
            type = ValueType.INT;
            this.value = new JsonDouble(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public JsonValue(double value)
        {
            type = ValueType.DOUBLE;
            this.value = new JsonDouble(value);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public JsonValue(ulong value)
        {
            type = ValueType.ULONG;
            this.value = new JsonUlang(value);
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
        /// <summary>
        /// Initializes a new instance of the <see cref="CsharpJson.JsonValue"/> class.
        /// </summary>
        /// <param name="value">Value.</param>
        public JsonValue(JsonArray value)
        {
            type = ValueType.ARRAY;
            this.value =value;
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
        /// Is int.
        /// </summary>
        /// <returns><c>true</c>, if int was ised, <c>false</c> otherwise.</returns>
        public bool isInt()
        {
            return type == ValueType.INT;
        }
        /// <summary>
        /// Is double.
        /// </summary>
        /// <returns><c>true</c>, if double was ised, <c>false</c> otherwise.</returns>
        public bool isDouble()
        {
            return type == ValueType.DOUBLE;
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
        /// Is ulong.
        /// </summary>
        /// <returns><c>true</c>, if ulong was ised, <c>false</c> otherwise.</returns>
        public bool isUlong()
        {
            return type == ValueType.ULONG;
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
        /// Gets the gettype.
        /// </summary>
        /// <value>The gettype.</value>
        public ValueType Gettype
        {
            get ;
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
            return ((JsonBool)this.value).Bvalue;
        }
        /// <summary>
        /// To the int.
        /// </summary>
        /// <returns>The int.</returns>
        public int ToInt()
        {
            if (!this.isInt())
            {
                throw new FormatException();
            }
            return ((JsonInt)this.value).Ivalue;
        }
        /// <summary>
        /// To the double.
        /// </summary>
        /// <returns>The double.</returns>
        public double ToDouble()
        {
            if (!this.isDouble())
            {
                throw new FormatException();
            }
            return ((JsonDouble)this.value).Dvalue;
        }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="CsharpJson.JsonValue"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="CsharpJson.JsonValue"/>.</returns>
        public string ToStrings()
        {
            if (!this.isString())
            {
                throw new FormatException();
            }
            return ((JsonString)this.value).Svalue;
        }
        /// <summary>
        /// To the ulong.
        /// </summary>
        /// <returns>The ulong.</returns>
        public ulong ToUlong()
        {
            if (!this.isUlong())
            {
                throw new FormatException();
            }
            return ((JsonUlang)this.value).Uvalue;
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
            return ((JsonArray)this.value);
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
            return ((JsonObject)this.value);
        }
    }
}

