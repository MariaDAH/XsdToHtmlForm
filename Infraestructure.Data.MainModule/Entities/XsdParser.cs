using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestructure.Data.MainModule.Interfaces;
using Domain.MainModule.XsdModel;
using Domain.MainModule.XsdModel.Entities;
using Infraestructure.CrossCutting.Enum;
using System.Xml.Schema;
using Domain.MainModule.XsdModel.Interfaces;
using System.Collections;

namespace Infraestructure.Data.MainModule.Entities
{
    /// <summary>
    /// Used for Xsd file parsing.
    /// </summary>
    public class XsdParser : IXsdParser
    {
        private XContainer _xFormRoot; //element request
        private XContainer _lastContainer;
        public string rootElementInput;

        /// <summary>
        /// Get XForm from given Xsd file.
        /// </summary>
        /// <param name="fileName">Path to Xsd file.</param>
        /// <returns></returns>
        public XForm ParseXsdFile(string fileName, Option option)
        {

            _xFormRoot = null;
            _lastContainer = null;

            var xmlSchema = LoadXmlSchema(fileName);


            foreach (XmlSchemaElement element in xmlSchema.Elements.Values)
            {
                if ((element.ElementSchemaType is XmlSchemaSimpleType) == false)//is not simplexType
                {
                    if (element.Name.Equals(rootElementInput)) //if element is the node root "request"
                    {
                        BuildXForm(element, null, option);
                    }
                }
            }
            var xForm = new XForm();
            xForm.Root = _xFormRoot; // set the root container
            return xForm;


        }

        /// <summary>
        /// Loads given Xsd file into XmlSchema.
        /// </summary>
        /// <param name="fileName">Path to Xsd file.</param>
        /// <returns>XmlSchema from given file.</returns>
        private XmlSchema LoadXmlSchema(string fileName)
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.ValidationEventHandler += SchemaValidationHandler;
            schemaSet.Add("http://www.w3.org/2001/XMLSchema", fileName);
            schemaSet.Compile();
            return schemaSet.Schemas().Cast<XmlSchema>().FirstOrDefault();
        }



        /// <summary>
        /// Build new XForm from XmlSchema.
        /// </summary>
        /// <param name="xmlSchemaElement">Current XmlSchemaElement.</param>
        /// <param name="parent">Parent XContainer to keep parent reference.</param>
        private void BuildXForm(XmlSchemaElement xmlSchemaElement, XContainer parent, Option option)
        {
            //Create a new container
            var container = new XContainer();

            //Sets the maxOccurs or minOccurs for the container 
            container.MaxOccurs = xmlSchemaElement.MaxOccurs;
            container.MinOccurs = xmlSchemaElement.MinOccurs;

            //Check the parent element is a groupBase
            if (xmlSchemaElement.Parent is XmlSchemaGroupBase)//is sequence or choice
            {
                var xmlSchemaGroupBase = ((XmlSchemaGroupBase)xmlSchemaElement.Parent);

                if (!string.IsNullOrEmpty(xmlSchemaGroupBase.MaxOccursString))
                {
                    container.MaxOccurs = ((XmlSchemaGroupBase)xmlSchemaElement.Parent).MaxOccurs;
                    container.MinOccurs = ((XmlSchemaGroupBase)xmlSchemaElement.Parent).MinOccurs;
                }
            }


            if (!xmlSchemaElement.RefName.IsEmpty)
            {
                if (xmlSchemaElement.Parent is XmlSchemaComplexType)
                {
                    container.ParentContainer = _lastContainer.Containers.LastOrDefault();
                }
                else
                {
                    container.ParentContainer = parent;
                    container.Name = xmlSchemaElement.RefName.Name;
                    container.Id = 1;
                }
            }
            else
            {
                container.ParentContainer = parent;
                container.Name = xmlSchemaElement.Name;
                container.Id = 1;
            }


            var complexType = xmlSchemaElement.ElementSchemaType as XmlSchemaComplexType;
            var simpleType = xmlSchemaElement.ElementSchemaType as XmlSchemaSimpleType;


            if (simpleType != null)
            {
                var element = new XElement();
                element.Name = xmlSchemaElement.Name;
                _lastContainer.Elements.Add(element);

                //TODO IMPLEMENT ANOTHER RESTRICTION FACETS LIKE enumeration, maxExclusive, pattern, etc.
            }

            if (complexType != null)
            {
                // If the complex type has any attributes, get an enumerator 
                // and write each attribute name to the container.
                if (complexType.AttributeUses.Count > 0)
                {
                    IDictionaryEnumerator enumerator = complexType.AttributeUses.GetEnumerator();

                    while (enumerator.MoveNext())
                    {
                        var attribute = (XmlSchemaAttribute)enumerator.Value;
                        var xAttribute = GetXAttribute(attribute);
                        container.Attributes.Add(xAttribute);
                    }
                }

                //Set the root container for the form
                if (_xFormRoot == null)
                {
                    _xFormRoot = container;
                }
                else
                {
                    _lastContainer.Containers.Add(container);
                }


                //xs:all, xs:choice, xs:sequence
                if (complexType.ContentTypeParticle is XmlSchemaGroupBase)
                {
                    if (complexType.ContentTypeParticle.GetType().Equals(typeof(XmlSchemaChoice)))
                    {
                        var baseChoice = complexType.ContentTypeParticle as XmlSchemaChoice;
                        var list = baseChoice.Items;
                        var parseOption = setParseOption(option);
                        var choice = baseChoice.Items[parseOption] as XmlSchemaElement;
                        _lastContainer = container;
                        BuildXForm(choice, container, option);
                    }
                    else
                    {
                        var baseParticle = complexType.ContentTypeParticle as XmlSchemaGroupBase;
                        foreach (XmlSchemaElement subParticle in baseParticle.Items)
                        {
                            _lastContainer = container;
                            BuildXForm(subParticle, container, option);

                        }
                    }
                }
                else
                {
                    //TODO IMPLEMENT ANOTHER XmlSchemaContentType 

                    if (complexType.ContentType == XmlSchemaContentType.TextOnly)
                    {
                        container.Value = string.Empty;
                    }
                }
            }

            _lastContainer = null;
        }

        /// <summary>
        /// Handler for errors during XmlSchema validation.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="args">Event data.</param>
        private void SchemaValidationHandler(object sender, ValidationEventArgs args)
        {
            throw new XmlSchemaValidationException(args.Message, args.Exception);
        }

        /// <summary>
        /// Provides correct IXAttribute depending on XmlTypeCode.
        /// </summary>
        /// <param name="attribute">Given XmlSchemaAttribute to process.</param>
        /// <returns>Coresponding IXAttribute.</returns>
        private IXAttribute GetXAttribute(XmlSchemaAttribute attribute)
        {
            IXAttribute xAttribute;
            var xmlTypeCode = attribute.AttributeSchemaType.TypeCode;

            var restriction = attribute.AttributeSchemaType.Content as XmlSchemaSimpleTypeRestriction;

            //resolve restrictions for simple type (enumeration)
            if (restriction != null && restriction.Facets.Count > 0)
            {
                var xStringRestrictionAttribute = new XEnumerationAttribute<string>(attribute.DefaultValue);
                foreach (var enumerationFacet in restriction.Facets.OfType<XmlSchemaEnumerationFacet>())
                {
                    xStringRestrictionAttribute.Enumeration.Add(enumerationFacet.Value);
                }

                //IS ENUMERATION
                if (xStringRestrictionAttribute.Enumeration.Any())
                {
                    xStringRestrictionAttribute.Name = attribute.Name;
                    xStringRestrictionAttribute.Use = (XAttributeUse)attribute.Use;
                    xStringRestrictionAttribute.Value = attribute.DefaultValue;
                    if (xStringRestrictionAttribute.Use == XAttributeUse.None)
                    {
                        xStringRestrictionAttribute.Use = XAttributeUse.Optional;//set default value defined here http://www.w3schools.com/schema/el_attribute.asp
                    }
                    return xStringRestrictionAttribute;
                }
            }


            switch (xmlTypeCode)
            {
                case XmlTypeCode.String:
                    xAttribute = new XAttribute<string>(attribute.DefaultValue);
                    ((XAttribute<string>)xAttribute).Value = attribute.DefaultValue;
                    break;

                case XmlTypeCode.Boolean:
                    bool booleanDefaultValue = false;
                    if (!string.IsNullOrEmpty(attribute.DefaultValue))
                        booleanDefaultValue = bool.Parse(attribute.DefaultValue);
                    xAttribute = new XAttribute<bool>(booleanDefaultValue);
                    ((XAttribute<bool>)xAttribute).Value = booleanDefaultValue;
                    break;

                case XmlTypeCode.Date:
                    var defaultValue = new DateTime();
                    if (!string.IsNullOrEmpty(attribute.DefaultValue))
                    {
                        defaultValue = DateTime.Parse(attribute.DefaultValue);
                    }
                    xAttribute = new XAttribute<DateTime>(defaultValue);
                    ((XAttribute<DateTime>)xAttribute).Value = defaultValue;
                    break;

                case XmlTypeCode.Integer:
                    var defaultValueInteger = 0;
                    if (!string.IsNullOrEmpty(attribute.DefaultValue))
                    {
                        defaultValueInteger = int.Parse(attribute.DefaultValue);
                    }

                    xAttribute = new XAttribute<int>(defaultValueInteger);
                    ((XAttribute<int>)xAttribute).Value = defaultValueInteger;
                    break;

                case XmlTypeCode.Int:
                    var defaultValueInt = 0;
                    if (!string.IsNullOrEmpty(attribute.DefaultValue))
                    {
                        defaultValueInt = int.Parse(attribute.DefaultValue);
                    }
                    xAttribute = new XAttribute<int>(defaultValueInt);
                    ((XAttribute<int>)xAttribute).Value = defaultValueInt;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Unknown XmlTypeCode.");
            }

            xAttribute.Name = attribute.Name;
            xAttribute.Use = (XAttributeUse)attribute.Use;
            if (xAttribute.Use == XAttributeUse.None)
            {
                //set default value defined here http://www.w3schools.com/schema/el_attribute.asp
                xAttribute.Use = XAttributeUse.Optional;
            }

            return xAttribute;
        }

        public int setParseOption(Option option)
        {
            switch (option)
            {
                case Option.Estimate:
                    return 0;

                case Option.Milestones:
                    return 1;

                case Option.EstimateList:
                    return 2;

                case Option.PartQuery:
                    return 3;

                default:
                    throw new ArgumentNullException();
            }
        }
    }
}
