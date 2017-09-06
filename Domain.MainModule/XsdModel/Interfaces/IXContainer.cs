using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Domain.MainModule.XsdModel.Entities;

namespace Domain.MainModule.XsdModel.Interfaces
{
   
    public interface IXContainer : IXmlSerializable
    {
        /// <summary>
        /// Reference to the parent container.
        /// </summary>
        XContainer ParentContainer { get; set; }

        /// <summary>
        /// Name of the container.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Container attributes.
        /// </summary>
        List<IXAttribute> Attributes { get; set; }

        /// <summary>
        /// Child containers.
        /// </summary>
        List<XContainer> Containers { get; set; }

        /// <summary>
        /// Container elements.
        /// </summary>
        List<XElement> Elements { get; set; }

        /// <summary>
        /// MinOccurs
        /// </summary>
        decimal MinOccurs { get; set; }

        /// <summary>
        /// MaxOccurs
        /// </summary>
        decimal MaxOccurs { get; set; }

        /// <summary>
        /// Container value.
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Container id.
        /// </summary>
        int Id { get; set; }
    }
}
