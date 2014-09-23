using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace HostedPCI.Domain.Helpers
{
    public static class ObjectToDictionaryHelper
    {
        public static void ToDictionary(this object source, Dictionary<string, string> dictionary, string prefix = null)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var type = source.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var attribute = (DataMemberAttribute) property.GetCustomAttributes(typeof (DataMemberAttribute), false).SingleOrDefault();
                if (attribute == null) 
                    continue;

                object value = property.GetValue(source, null);
                    
                var custPrefix = !string.IsNullOrWhiteSpace(prefix) ? prefix + "." : "";
                var custPropertyName = !string.IsNullOrWhiteSpace(attribute.Name) ? attribute.Name : property.Name;
                var propertyName = custPrefix + custPropertyName;

                if (value == null)
                {
                    if (attribute.EmitDefaultValue)
                        dictionary.Add(propertyName, "null");

                    continue;
                }

                var valueType = value.GetType();

                if (valueType.IsArray)
                {
                    var array = value as IEnumerable;
                    if (array != null)
                    {
                        var elmType = valueType.GetElementType();
                        if (elmType.IsClass && elmType != typeof(string))
                        {
                            var index = 0;
                            foreach (object item in array)
                            {
                                var name = string.Format("{0}[{1}]", propertyName, index);
                                item.ToDictionary(dictionary, name);
                                index++;
                            }
                        }
                        else
                        {
                            var index = 0;
                            foreach (object item in array)
                            {
                                var name = string.Format("{0}[{1}]", propertyName, index);
                                dictionary.Add(name, item.ToString());
                                index++;
                            }
                        }
                    }
                }
                else if (valueType.IsClass && valueType != typeof (string))
                {
                    value.ToDictionary(dictionary, propertyName);
                }
                else
                {
                    dictionary.Add(propertyName, value.ToString());
                }
            }
        }
    }
}
