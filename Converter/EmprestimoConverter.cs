using SistemaDeEmprestimos.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SistemaDeEmprestimos.Converter
{
    public class EmprestimoConverter : IValueConverter
    {
        private IFormatProvider _cultura = new System.Globalization.CultureInfo("pt-BR");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if(value is DateTime)
                {
                    return ((DateTime)value).ToString("dd/MM/yyyy");
                }
                else if(value is double)
                {
                    return ((double)value).ToString("C", _cultura);
                }
                else if (value is Usuario)
                {
                    return (value as Usuario).Nome;
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }  
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
