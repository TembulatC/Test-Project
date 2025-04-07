using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public record class CodeConfirmRequest
    {
        [Required]
        public int Code { get; set; } = 0;
    }
}
