using btr.winform48.Helper;
using System.Collections.Generic;
using btr.nuna.Domain;
using System.Threading.Tasks;

namespace btr.winform48.SharedForm
{
    public interface IDateBrowser<T>
    {
        Task<IEnumerable<T>> Browse(Periode periode);
    }
    public interface IStringBrowser<T>
    {
        Task<IEnumerable<T>> Browse(string keyword, string filter);
    }
}
