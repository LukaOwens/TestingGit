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
using TechoLand.Windows;

namespace TechoLand.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        TechnoDBContext db = new TechnoDBContext();
        Product product = new Product();
        Production production;
        public ProductControl(Product product)
        {
            InitializeComponent();
            
            Context.IsEnabled = false;
            Context.Visibility = Visibility.Collapsed;
            this.product = product;
            List<Supplier> suppliers = db.Suppliers.ToList();
            List<Type> types = db.Types.ToList();
            string suppliername = "Поставщик: ";
            string typename = "";
            ProductName.Text = product.Name;
            Description.Text = product.Description;
            SaleCost.Text = "Цена: " + product.Cost.ToString();
            foreach (Supplier supplier in suppliers)
            {
                if (product.SupplierId == supplier.SupplierId)
                {
                    suppliername += supplier.Name;
                    break;
                }
            }
            foreach (Type type in types)
            {
                if (product.TypeId == type.TypeId)
                {
                    typename = type.Name;
                    break;
                }
            }
            Type.Text = typename;
            Supplier.Text = suppliername;
            if (string.IsNullOrEmpty(product.Image) == false)
                Photo.Source = new BitmapImage(new Uri("/UserControls/" + product.Image, UriKind.Relative));
            else
                Photo.Source = new BitmapImage(new Uri("/UserControls/Picture.png", UriKind.Relative));
            Count.Text = "Кол-во " + product.Count.ToString() + "шт.";
        }
        public ProductControl(Product product,Production production, int role)
        {
            InitializeComponent();
            if (role == 1)
            {
                DeleteMenu.IsEnabled = true;
                DeleteMenu.Visibility = Visibility.Visible;
            }
            this.production = production;
            this.product = product;
            List<Supplier> suppliers = db.Suppliers.ToList();
            List<Type> types = db.Types.ToList();
            string suppliername = "Поставщик: ";
            string typename = "";
            ProductName.Text = product.Name;
            Description.Text = product.Description;
            SaleCost.Text = "Цена: " + product.Cost.ToString();
            foreach (Supplier supplier in suppliers)
            {
                if (product.SupplierId == supplier.SupplierId)
                {
                    suppliername += supplier.Name;
                    break;
                }
            }
            foreach (Type type in types)
            {
                if (product.TypeId == type.TypeId)
                {
                    typename = type.Name;
                    break;
                }
            }
            Type.Text = typename;
            Supplier.Text = suppliername;
            if (string.IsNullOrEmpty(product.Image) == false)
                Photo.Source = new BitmapImage(new Uri("/UserControls/" + product.Image, UriKind.Relative));
            else
                Photo.Source = new BitmapImage(new Uri("/UserControls/Picture.png", UriKind.Relative));
            Count.Text = "Кол-во на складе " + product.Count.ToString() + "шт.";
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить этот товар?", "Удаление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var delete = db.Products.First(x => x.Article == product.Article);
                db.Products.Remove(delete);
                db.SaveChanges();
                production.SearchFilterSort();
            }
        }

        private void AddToCart(object sender, RoutedEventArgs e)
        {
            production.AddProductToCart(product.Article);
        }
    }
}
