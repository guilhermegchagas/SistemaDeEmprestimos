﻿using SistemaDeEmprestimos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaDeEmprestimos.View
{
    public partial class PagamentoEmprestimosUserControl : UserControl
    {
        protected PagamentoEmprestimosViewModel ViewModel
        {
            get { return (PagamentoEmprestimosViewModel)DataContext; }
        }

        public PagamentoEmprestimosUserControl()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SenhaCredor = passwordBox.SecurePassword;
        }
    }
}
