using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Domain.Contract
{
    public interface IStoreContextInitializer
    {
        Task InitializeAsync();
        Task SeedAsync();
    }
}
