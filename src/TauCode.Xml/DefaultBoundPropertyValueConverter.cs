using System;
using System.Reflection;

namespace TauCode.Xml
{
    public class DefaultBoundPropertyValueConverter : IBoundPropertyValueConverter
    {
        public virtual string ToStringValue(PropertyInfo property, object value)
        {
            if (value is string s)
            {
                return s;
            }

            if (value is bool b)
            {
                return b.ToString();
            }

            throw new NotImplementedException();
        }

        public virtual object FromStringValue(PropertyInfo property, string valueString)
        {
            throw new NotImplementedException();
        }
    }
}
