using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Domain.MainModule.XsdModel.Interfaces;
using Infraestructure.CrossCutting.Enum;

namespace PresentationLayer.MainModule.UI
{
    /// <summary>
    /// Validate given form.
    /// </summary>
    internal class FormValidation
    {
        private readonly ErrorProvider _errorProvider;

        internal FormValidation(ErrorProvider errorProvider)
        {
            _errorProvider = errorProvider;
        }

        /// <summary>
        /// Check if all given controls are valid.
        /// </summary>
        /// <param name="controls">Controls to validate.</param>
        /// <returns>True if all controls are valid, false if not.</returns>
        internal bool AreControlsValid(IEnumerable<Control> controls)
        {
            foreach (var control in controls)
            {
                ControlValidating(control, new CancelEventArgs());
                if (_errorProvider.GetError(control).Length > 0)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Validating event handler.
        /// </summary>
        /// <param name="sender">Control to validate.</param>
        /// <param name="e">Event data.</param>
        internal void ControlValidating(object sender, CancelEventArgs e)
        {
            var control = (Control)sender;

            if (control.Tag is IXAttribute)
            {
                if (((IXAttribute)control.Tag).Use == XAttributeUse.Required)
                {
                    if (control is TextBox)
                    {
                        if (string.IsNullOrEmpty(control.Text))
                        {
                            _errorProvider.SetError(control, "Required");
                        }
                        else
                        {
                            _errorProvider.SetError(control, string.Empty);
                        }
                    }
                }
            }
        }
    }
}
