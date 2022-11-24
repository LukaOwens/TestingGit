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
using TechoLand.Windows;
using TechoLand.UserControls;

namespace TechoLand.Windows
{
    /// <summary>
    /// Логика взаимодействия для Production.xaml
    /// </summary>
    public partial class Production : Window
    {
        TechnoDBContext db = new TechnoDBContext();
        AvtorizationWindow avtorizationwindow;
        int userid;
        int role;
        public Production(int role, int userid, string name, AvtorizationWindow avtorizationwindow)
        {
            InitializeComponent();
            this.role = role;
            this.userid = userid;
            List<Supplier> suppliers = db.Suppliers.ToList();
            Filter.SelectedIndex = 0;
            Sorting.SelectedIndex = 0;
            foreach (Supplier supplier in suppliers)
            {
                Filter.Items.Add(new TextBlock().Text = supplier.Name);
            }
            this.avtorizationwindow = avtorizationwindow;
            UserName.Text += " " + name;
            switch (role)
            {
                case 3:
                    {
                        UserRole.Text += "Работник";
                        break;
                    }

                case 2:
                    {
                        UserRole.Text += "Менеджер";
                        AddProduct.IsEnabled = true;
                        AddProduct.Visibility = Visibility.Visible;
                        break;
                    }

                case 1:
                    {
                        UserRole.Text += "Администратор";
                        AddProduct.IsEnabled = true;
                        AddProduct.Visibility = Visibility.Visible;
                        Cart.Content = "Посмотреть заказы";
                        break;
                    }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Products_Closed(object sender, EventArgs e)
        {
            avtorizationwindow.Show();
        }

        private void Win_Load(object sender, RoutedEventArgs e)
        {
            Products.Items.Clear();
            if (role == 4)
                Cart.Content = "Посмотреть заказы";
            int count = 0;
            List<Product> products = db.Products.ToList();
            foreach (Product product in products)
            {
                Products.Items.Add(new Separator());
                Products.Items.Add(new ProductControl(product, this, role));
                count++;
            }
            Count.Text = count.ToString() + "/" + products.Count.ToString();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchFilterSort();
        }
        public void SearchFilterSort()
        {
            Products.Items.Clear();
            int count = 0;
            List<Product> products = db.Products.ToList();
            List<Product> searched = products.Where(x => x.Name.ToLower().Contains(Search.Text.ToLower())).ToList();
            List<Supplier> suppliers = db.Suppliers.ToList();
            List<Product> sorted = new List<Product>();
            switch (Sorting.SelectedIndex)
            {
                case 0:
                    {
                        sorted = searched;
                        break;
                    }
                case 1:
                    {
                        sorted = searched.OrderBy(x => x.Cost).ToList();
                        break;
                    }
                case 2:
                    {
                        sorted = searched.OrderByDescending(x => x.Cost).ToList();
                        break;
                    }
            }
            if (Filter.SelectedIndex == 0)
            {
                foreach (Product product in sorted)
                {
                    Products.Items.Add(new Separator());
                    Products.Items.Add(new ProductControl(product, this,role));
                    count++;
                }
            }
            else
            {
                foreach (Product product in sorted)
                {
                    bool filter = false;
                    foreach (Supplier suppleir in suppliers)
                    {
                        if (suppleir.Name == Filter.SelectedItem.ToString())
                        {
                            if (suppleir.SupplierId == product.SupplierId)
                            {
                                filter = true;
                            }
                        }
                    }
                    if (filter)
                    {
                        Products.Items.Add(new Separator());
                        Products.Items.Add(new ProductControl(product, this, role));
                        count++;
                    }
                }
            }
            if (Products.Items.Count == 0)
            {
                TextBlock text = new TextBlock();
                text.Text = "Нет записей";
                text.TextAlignment = TextAlignment.Center;
                Products.Items.Add(text);
            }
            Count.Text = count.ToString() + "/" + products.Count.ToString();
        }

        private void Sorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchFilterSort();
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchFilterSort();
        }

        private void AddProd(object sender, RoutedEventArgs e)
        {
            //    AddProduction add = new AddProduction(this);
            //    add.Show();
            //    this.Hide();
        }

        private void CartOpen(object sender, RoutedEventArgs e)
        {
            if (role == 1)
            {
                OrdersView orders = new OrdersView(this);
                orders.Show();
                this.Hide();
            }
            else
            {
                Cart cart = new Cart(this, product, userid);
                cart.Show();
                this.Hide();
            }
        }
        List<Product> product = new List<Product>();
        public void AddProductToCart(string article)
        {
            bool notcontain = true;
            List<Product> products = db.Products.ToList();
            foreach (var prod in product)
            {
                if (prod.Article.Contains(article))
                {
                    prod.Count++;
                    notcontain = false;
                }
            }
            if (notcontain)
            {
                List<Product> items = new List<Product>();
                items = products.Where(p => p.Article == article).ToList();
                foreach (var item in items)
                {
                    item.Count = 1;
                }
                product.AddRange(items);
            }
        }
        public void ClearCart()
        {
            product.Clear();
        }
    }
}
