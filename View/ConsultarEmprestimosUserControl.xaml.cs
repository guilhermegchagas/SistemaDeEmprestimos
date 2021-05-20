using SistemaDeEmprestimos.ViewModel;
using System.Windows.Controls;

namespace SistemaDeEmprestimos.View
{
    public partial class ConsultarEmprestimosUserControl : UserControl
    {
        protected ConsultarEmprestimosViewModel ViewModel
        {
            get { return (ConsultarEmprestimosViewModel)DataContext; }
        }

        public ConsultarEmprestimosUserControl()
        {
            InitializeComponent();
        }
    }
}
