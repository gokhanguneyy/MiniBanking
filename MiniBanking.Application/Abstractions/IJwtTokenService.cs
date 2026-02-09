using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBanking.Application.Abstractions
{
    public interface IJwtTokenService
    {
        string GenerateToken(int userId, string email);
    }
}
