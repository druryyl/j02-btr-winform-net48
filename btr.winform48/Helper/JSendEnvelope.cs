using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btr.winform48.Helper
{
    public class JSend<T>
    {
        public string Status { get; set; }
        public string Code { get; set; }
        public T Data { get; set; }
    }
}
