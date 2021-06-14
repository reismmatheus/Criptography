using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cryptography.Repositories.Model
{
    public class CriptographyCard
    {
        public int Id { get; set; }
        [Required]
        public string UserDocument { get; set; }
        [Required]
        public string CreditCardToken { get; set; }
        public string Value { get; set; }
    }
}
