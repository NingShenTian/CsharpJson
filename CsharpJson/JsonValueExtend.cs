using System;

namespace CsharpJson
{
    public partial class JsonValue
    {
        private class JsonBool:Base
        {
            private bool bvalue;
            public JsonBool(bool val)
            {
                this.bvalue = val;
            }
            public bool Bvalue
            {
                get;
                set;
            }
        }
        private class JsonInt:Base
        {
            private int ivalue;
            public JsonInt(int val)
            {
                this.ivalue=val;
            }
            public int Ivalue
            {
                get;
                set;
            }
        }
        private class JsonDouble :Base
        {
            private double dvalue;
            public JsonDouble(double val)
            {
                this.dvalue =val;
            }
            public double Dvalue
            {
                get;
                set;
            }
        }
        private class JsonUlang :Base
        {
            private ulong uvalue;
            public JsonUlang(ulong val)
            {
                this.uvalue=val;
            }
            public ulong Uvalue
            {
                get;
                set;
            }
        }
        private class JsonString :Base
        {
            private string svalue;
            public JsonString(string val)
            {
                this.svalue=val;
            }
            public string Svalue
            {
                get;
                set;
            }
        }
    }
}

