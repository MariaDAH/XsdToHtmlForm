using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Xml;
using System.ComponentModel;
using Infraestructure.CrossCutting.Enum;
using Domain.MainModule.XsdModel.Interfaces;


namespace Domain.MainModule.XsdModel.Entities
{
    /// <summary>
    /// Encapsulate information about elements attribute.
    /// </summary>
    /// <typeparam name="T">Type of attribute.</typeparam>
    [Serializable]
    public class XAttribute<T> : IXAttribute<T>
    {
        /// <summary>
        /// Attribute name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Attribute usage.
        /// </summary>
        public XAttributeUse Use { get; set; }



        /// <summary>
        /// Used when generating the Xml file.
        /// </summary>
        /// <returns></returns>
        public string GetStringXmlValue()
        {
            if (Value == null)
            {
                return string.Empty;
            }

            if (Value is DateTime)
            {
                return String.Format("{0:yyyy-MM-dd}", Value);
            }

            if (Value is Boolean) 
            {
                return Value.ToString().ToLower();
            }

            return Value.ToString();
        }

        /// <summary>
        /// Default value of an attribute.
        /// </summary>
        public T DefaultValue { get; private set; }

        public XAttribute(T defaultValue)
        {
            DefaultValue = defaultValue;
        }

        private T _value;

        /// <summary>
        /// Attribute value.
        /// </summary>
        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Value"));
            }
        }

        /// <summary>
        /// Property changed event.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString(Name, GetStringXmlValue());
        }
    }
}
