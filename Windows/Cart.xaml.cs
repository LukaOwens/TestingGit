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
using TechoLand.UserControls;
using TechoLand.Windows;

namespace TechoLand.Windows
{
    /// <summary>
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        Production production;
        TechnoDBContext db = new TechnoDBContext();
        List<Product> products;
        int userid;
        public Cart(Production production, List<Product> products, int userid)
        {
            InitializeComponent();
            this.production = production;
            this.products = products;
            this.userid = userid;
        }

        private void Win_Load(object sender, RoutedEventArgs e)
        {
            InsertToCart();
        }

        private void Products_Closed(object sender, EventArgs e)
        {
            production.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow order = new OrderWindow(products, production, this, userid);
            order.Show();
            this.Visibility = Visibility.Collapsed;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Products.Items.Clear();
            production.ClearCart();
            PlaceOrder.IsEnabled = false;
            Count.Text = "Товаров в корзине: 0";
        }
        private void InsertToCart()
        {
            int count = 0;
            decimal price = 0;
            if (products.Count <= 0)
            {
                PlaceOrder.IsEnabled = false;
            }
            else if (products.Count >= 1)
            {
                PlaceOrder.IsEnabled = true;
            }
            foreach (Product product in products)
            {
                count += product.Count;
                price += product.Cost * product.Count;
                Products.Items.Add(new ProductControl(product));
            }
            Count.Text += count.ToString();
            Amount.Text += price.ToString();
        }
    }
}
