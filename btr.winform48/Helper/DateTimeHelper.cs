using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btr.winform48.Helper
{
    public static class DateTimeHelper
    {
        private const string YMD = "yyyy-MM-dd";
        private const string DMY = "dd-MM-yyyy";

        public static DateTime ToDate(this string stringTgl)
        {
            DateTime dummyDate;
            //  coba parsing sebagai DMY
            bool isValid = DateTime.TryParseExact(stringTgl, DMY,
                CultureInfo.InvariantCulture, DateTimeStyles.None,
                out dummyDate);

            //  jika tidak berhasil, parsing sebagai YMD
            if (!isValid)
            {
                isValid = DateTime.TryParseExact(stringTgl, YMD,
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out dummyDate);
            }

            if (isValid)
            {
                return dummyDate;
            }
            else
            {
                throw new InvalidOperationException("Invalid string date");
            }
        }
    }
}
