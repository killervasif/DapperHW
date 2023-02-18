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
using System.Windows.Shapes;

namespace DapperHW.Windows
{  
    public partial class UpdateWindow : Window
    {
        public Product Product { get; set; }

        public UpdateWindow(Product product)
        {
            InitializeComponent();
            DataContext = this;

            Product = product;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Product.Name))
                builder.Append($"{nameof(Product.Name)} Cannot Be Empty\n");

            if (Product.Price <= 0)
                builder.Append($"{nameof(Product.Price)} Cannot be below or equal to 0\n");

            if (Product.Quantity < 0)
                builder.Append($"{nameof(Product.Quantity)} Cannot be below 0\n");

            if (builder.Length > 0)
            {
                MessageBox.Show(builder.ToString());
                return;
            }

            DialogResult = true;
        }
    }
}
