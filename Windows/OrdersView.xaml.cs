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

namespace TechoLand.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrdersView.xaml
    /// </summary>
    public class Items
    {
        public Items(int id, DateOnly orderdate, decimal amount, int userid)
        {
            Id = id;
            Amount = amount;
            Date = orderdate;
            UserID = userid;
        }
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public int UserID { get; set; }
    }

    public partial class OrdersView : Window
    {
        TechnoDBContext db = new TechnoDBContext();
        Production production;
        List<Items> items = new List<Items>();
        public OrdersView(Production production)
        {
            this.production = production;
            InitializeComponent();
            List<Order> orders = db.Orders.ToList();
            foreach (Order order in orders)
            {
                items.Add(new Items(order.OrderId, order.Date, order.Amount, order.UserId));

            }
            OrderTable.ItemsSource = items;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Closing_Win(object sender, EventArgs e)
        {
            production.Show();
        }

        private void DateSorting()
        {
            List<Order> orders = db.Orders.ToList();
            List<Order> orderdates = new List<Order>();
            if (InDate.SelectedDate <= ToDate.SelectedDate)
            {
                DateOnly indate = DateOnly.FromDateTime(InDate.SelectedDate.Value);
                DateOnly todate = DateOnly.FromDateTime(ToDate.SelectedDate.Value);
                OrderTable.ItemsSource = null;
                OrderTable.Items.Clear();
                items.Clear();
                orderdates = orders.Where(x => x.Date >= indate & x.Date <= todate).ToList();
            }
            else if (InDate.SelectedDate == null & ToDate.SelectedDate != null)
            {
                DateOnly todate = DateOnly.FromDateTime(ToDate.SelectedDate.Value);
                OrderTable.ItemsSource = null;
                OrderTable.Items.Clear();
                items.Clear();
                orderdates = orders.Where(x => x.Date <= todate).ToList();
            }
            else if (ToDate.SelectedDate == null & InDate.SelectedDate != null)
            {
                DateOnly indate = DateOnly.FromDateTime(InDate.SelectedDate.Value);
                OrderTable.ItemsSource = null;
                OrderTable.Items.Clear();
                items.Clear();
                orderdates = orders.Where(x => x.Date >= indate).ToList();
            }
            else
            {
                orderdates = orders;
            }
            foreach (Order order in orderdates)
            {
                items.Add(new Items(order.OrderId, order.Date, order.Amount, order.UserId));

            }
            OrderTable.ItemsSource = items;

        }

        private void Delete_Click(object sender, MouseButtonEventArgs e)
        {
            int orderid = ((Items)(OrderTable.SelectedValue)).Id;
            var result = MessageBox.Show("Вы точно хотите удалить этот заказ?", "Удаление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var delete = db.Orders.First(x => x.OrderId == orderid);
                db.Orders.Remove(delete);
                db.SaveChanges();
                production.SearchFilterSort();
                OrderTable.ItemsSource = null;
                OrderTable.Items.Clear();
                items.Clear();
                List<Order> orders = db.Orders.ToList();
                foreach (Order order in orders)
                {
                    items.Add(new Items(order.OrderId, order.Date, order.Amount, order.UserId));

                }
                OrderTable.ItemsSource = items;
            }
        }

        private void Date_Changed(object sender, SelectionChangedEventArgs e)
        {
            DateSorting();
        }


        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            string select = OrderTable.SelectedIndex.ToString();
            if(OrderTable.SelectedIndex != -1)
                MessageBox.Show(select);
        }

    }
}
