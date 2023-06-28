using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btr.winform48.Helper
{
    public interface IGetDataService<T>
    {
        T Execute(string key);
    }
}
