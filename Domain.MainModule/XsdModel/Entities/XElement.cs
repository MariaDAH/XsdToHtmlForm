﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MainModule.XsdModel.Interfaces;
using System.Xml.Schema;
using System.Xml;

namespace Domain.MainModule.XsdModel.Entities
{
    /// <summary>
    /// Encapsulate data for an element.
    /// </summary>
    [Serializable]
    public class XElement : IXElement
    {
        /// <summary>
        /// Element name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Element value.
        /// </summary>
        public string Value { get; set; }

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
            writer.WriteStartElement(Name);
            writer.WriteString(Value);
            writer.WriteEndElement();
        }
    }
}
