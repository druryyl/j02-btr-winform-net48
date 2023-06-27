using btr.winform48.Helper;
using System.Collections.Generic;

namespace btr.winform48.SharedForm
{
    public interface IDateBrowser<T>
    {
        IEnumerable<T> Browse(Periode periode);
    }
    public interface IStringBrowser<T>
    {
        IEnumerable<T> Browse(string keyword, string filter);
    }
}
