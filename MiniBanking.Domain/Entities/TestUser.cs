using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBanking.Domain.Entities
{
    public class TestUser : BaseEntity
    {
        public string Email { get; set; } 
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
