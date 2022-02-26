using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.AdventureWorksLT.Model.Models
{
    public partial class Customer
    {
        [NotMapped]
        public string FullName { get
            {
                var resultado = string.Empty;
                if (this.Title != null)
                {
                    resultado = this.Title;
                }
                resultado += this.FirstName;
                if (this.MiddleName != null)
                {
                    resultado += " " + this.MiddleName;
                }
                resultado += " " + this.LastName;
                if (this.Suffix != null)
                {
                    resultado += " " + this.Suffix;
                }
                return resultado;
            } 
            set { } 
        }

        [NotMapped]
        public string EmailDomain { 
            get { 
                var resultado = string.Empty;
                if (! string.IsNullOrEmpty(this.EmailAddress))
                {
                    var posicionArroba = this.EmailAddress.IndexOf('@');
                    resultado = this.EmailAddress.Substring(posicionArroba + 1);
                }
                return resultado;
            } 
            set { } 
        }
    }
}
