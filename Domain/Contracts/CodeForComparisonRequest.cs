using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public record class CodeForComparisonRequest
    {
        public int codeForComparison { get; set; } = 0;
    }
}
