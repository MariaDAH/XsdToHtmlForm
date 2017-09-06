using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributedServices.MainModule.HTTP.View.ApplicationObjects
{
    public struct Locale
    {
        private string language;
        private string country;

        #region Properties

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        #endregion


        public Locale(string language, string country)
        {
            this.language = language;
            this.country = country;
        }
    }
}