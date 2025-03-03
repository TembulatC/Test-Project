using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IHasherRepository
    {
        string Generate(string passsword);
        bool Verify(string password, string hashedPassword);
    }
}
