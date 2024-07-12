using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aaa
{
    internal interface IABMC<T> : IID
    {
        void Modify (T data);
        void Add (T data);
        void Erase (T data);
        T Find (T data);
    }
}