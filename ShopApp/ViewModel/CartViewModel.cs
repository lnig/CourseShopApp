using ShopApp.Repository;
using ShopApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace ShopApp.ViewModel
{
    public class CartViewModel
    {
        public string Title { get; } = "Cart";

        public ICommand RegisterCommand { get; }

        public CartViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register(object parameter)
        {
            MessageBox.Show("2");
        }

   

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
