using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gnyang.samples.domain.Vo
{
    public class Contact
    {
        public EmailAddress? Email { get; set; }

        public required string Phone { get; set; }

    }
}
