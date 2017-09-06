using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.MainModule.XsdModel.Entities;
using PresentationLayer.MainModule.UI;
using System.Windows.Forms;

namespace PresentationLayer.MainModule.Test.UITest
{
    [TestClass]
    public class ControlFactoryTest
    {
        [TestMethod]
        public void GetLabelForXElement()
        {
            //asign
            XElement xElement = new XElement();
            xElement.Name = "xElement";
            var controlFactory = new ControlFactory();

            //action
            var control = controlFactory.GetLabel(xElement);

            //assert
            Assert.IsNotNull(control);
            Assert.AreEqual(control.Name, xElement.Name + "Label");
        }

        [TestMethod]
        public void GetLabelForXAttribute()
        {
            //asign
            var xElement = new XAttribute<string>("test");
            xElement.Name = "XAttribute";
            var controlFactory = new ControlFactory();

            //action
            var control = controlFactory.GetLabel(xElement);

            //assert
            Assert.IsNotNull(control);
            Assert.AreEqual(control.Name, xElement.Name + "Label");
        }
    }
}
