using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApiDemo.Models
{
    class UpdateContactRequest
    {
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
