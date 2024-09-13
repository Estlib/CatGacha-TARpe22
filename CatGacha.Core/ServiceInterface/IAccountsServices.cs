using CatGacha.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatGacha.Core.ServiceInterface
{
    public interface IAccountsServices
    {
        Task<ApplicationUser> Register(ApplicationUserDto dto);
    }
}
