using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Services.Repositories.Basic
{
   public  interface IRepositories<T>
    {
        T GetElement( string[] args );
        bool AddElement( T element);
        bool FindElement( string[] args );
    }
}
