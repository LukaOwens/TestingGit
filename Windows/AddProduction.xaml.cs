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

namespace TechoLand.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProduction.xaml
    /// </summary>
    public partial class AddProduction : Window
    {
        //Production production;
        //Entities entities = new Entities();
        //List<Products> products;
        public AddProduction()
        {
            //InitializeComponent();
            //this.production = production;
            //products = entities.Products.ToList();
        }
        private void Products_Closed(object sender, EventArgs e)
        {
            
        }

        private void Add(object sender, RoutedEventArgs e)
        {/*
            try
            {
                if (string.IsNullOrEmpty(Title.Text) || string.IsNullOrEmpty(BuyCost.Text) || string.IsNullOrEmpty(SaleCost.Text) || string.IsNullOrEmpty(Count.Text) || string.IsNullOrEmpty(Type.Text) || string.IsNullOrEmpty(SupplierName.Text))
                {
                    MessageBox.Show("Вы не заполнили одно или несколько обязательных полей", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    int a;
                    string s = "";
                    int supplier = 0;
                    int type = 0;
                    switch (SupplierName.SelectedIndex)
                    {
                        case 0:
                            {
                                supplier = 1;
                                break;
                            }
                        case 1:
                            {
                                supplier = 2;
                                break;
                            }
                        case 2:
                            {
                                supplier = 3;
                                break;
                            }
                    }
                    switch (Type.SelectedIndex)
                    {
                        case 0:
                            {
                                type = 1;
                                break;
                            }
                        case 1:
                            {
                                type = 2;
                                break;
                            }
                        case 2:
                            {
                                type = 3;
                                break;
                            }
                    }
                    Random random = new Random();
                    for (int i = 0; i < 8; i++)
                    {
                        a = random.Next(1, 9);
                        s += a.ToString();
                        if (i > 6)
                        {
                            foreach (var prod in products)
                            {
                                if (prod.Article.Contains(s))
                                {
                                    s = "";
                                    i = 0;
                                }
                            }
                        }
                    }
                    string imagesours = "";
                    if(ImageSours.Text.Contains(".jpg") || ImageSours.Text.Contains(".png"))
                    {
                        imagesours = ImageSours.Text;
                    }
                    Products product = new Products
                    {
                        Article = "А" + s,
                        Title = Title.Text,
                        BuyCost = int.Parse(BuyCost.Text),
                        SaleCost = int.Parse(SaleCost.Text),
                        Count = int.Parse(Count.Text),
                        Image = imagesours,
                        SupplierID = supplier,
                        ProductType = type,
                        Unit = "шт.",
                        Decription = Description.Text
                    };
                    entities.Products.Add(product);
                    entities.SaveChanges();
                    production.SearchFilterSort();
                    this.Close();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Вы ввели неверный тип данных некоторых полях");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Changed(object sender, TextChangedEventArgs e)
        {
            int i = 0;
            if (string.IsNullOrWhiteSpace((sender as TextBox).Text) == false)
            {
                if (int.TryParse((sender as TextBox).Text, out i) == false)
                {
                    (sender as TextBox).Background = (Brush)(new BrushConverter().ConvertFrom("#4FFF0000"));
                }
                else
                {
                    (sender as TextBox).Background = Brushes.White;
                }
            }
            else
            {
                (sender as TextBox).Background = Brushes.White;
            }*/
        }
    }
}
