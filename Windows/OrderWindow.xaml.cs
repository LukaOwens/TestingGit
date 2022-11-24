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
using System.IO;

namespace TechoLand.Windows
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public class Item
    {
        public Item(int id, string article, string title, int count, decimal cost)
        {
            Id = id;
            Article = article;
            Title = title;
            Count = count;
            Cost = cost;
        }
        public int Id { get; set; }
        public string Article { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public decimal Cost { get; set; }
    }
    public partial class OrderWindow : System.Windows.Window
    {
        TechnoDBContext db = new TechnoDBContext();
        Production production;
        List<Item> items = new List<Item>();
        Cart cart;
        int userid = 0;
        decimal amount = 0;
        string cheque = "";
        int count = 0;
        string title = "";
        decimal cost = 0;
        string name = "";
        string rep = "";
        public OrderWindow(List<Product> products, Production production, Cart cart, int userid)
        {
            this.cart = cart;
            this.userid = userid;
            this.production = production;
            int i = 0;
            foreach (var product in products)
            {
                i++;
                count = product.Count;
                title = product.Name;
                cost = product.Cost;
                items.Add(new Item(i, product.Article, product.Name, product.Count, product.Cost));
                amount += product.Cost * product.Count;
            }
            InitializeComponent();
            OrderTable.ItemsSource = items;
        }
        private void Products_Closed(object sender, EventArgs e)
        {
            cart.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            //List<Order> orders = entities.Order.ToList();
            //List<Buyers> buyers = entities.Buyers.ToList();
            //List<User> users = entities.User.ToList();
            //foreach (var user in users)
            //{
            //    if (user.UserID == userid)
            //    {
            //        rep = user.UserSurname + user.UserName.Remove(1) + "." + user.UserPatronymic.Remove(1) + ".";
            //    }
            //}
            //int buyerid = 0;
            //foreach (var buyer in buyers)
            //{
            //    if (buyer.RepID == userid)
            //    {
            //        buyerid = buyer.ID;
            //        name = buyer.Title;
            //    }
            //    if (userid == 10)
            //    {
            //        buyerid = 1;
            //        name = buyer.Title;
            //        break;
            //    }
            //}
            //FileInfo fileInfo = new FileInfo("C:\\Users\\ShiroEmpty\\source\\repos\\TechoLand\\Resources\\Pattern.docx");
            //List<string> keys = new List<string>()
            //{
            //    "<DAT>","<COUNT>","<REP>","<NAME>","<TITLE>","<COST>","<SUM>","<AMOUNT>","<NUM>"
            //};
            //Word.Application app = new Word.Application();
            //Object fileName = "C:\\Users\\ShiroEmpty\\source\\repos\\TechoLand\\Resources\\Pattern.doc";
            //Object missing = Type.Missing;
            //string num = (orders.Count + 1).ToString();
            //try
            //{
            //    app.Documents.Open(ref fileName);
            //    foreach (var key in keys)
            //    {
            //        switch (key)
            //        {
            //            case "<DAT>":
            //                {
            //                    Word.Find find = app.Selection.Find;
            //                    find.Text = key;
            //                    find.Replacement.Text = DateTime.Now.ToString();
            //                    Object wrap = Word.WdFindWrap.wdFindContinue;
            //                    Object replace = Word.WdReplace.wdReplaceAll;
            //                    find.Execute(FindText: Type.Missing,
            //                        MatchCase: false,
            //                        MatchWholeWord: false, 
            //                        MatchWildcards: false, 
            //                        MatchSoundsLike: missing, 
            //                        MatchAllWordForms: false, 
            //                        Forward: true, 
            //                        Wrap: wrap, 
            //                        Format: false, 
            //                        ReplaceWith: missing, 
            //                        Replace: replace);
            //                    break;
            //                }
            //            case "<COUNT>":
            //                {
            //                    Word.Find find = app.Selection.Find;
            //                    find.Text = key;
            //                    find.Replacement.Text = count.ToString();
            //                    Object wrap = Word.WdFindWrap.wdFindContinue;
            //                    Object replace = Word.WdReplace.wdReplaceAll;
            //                    find.Execute(FindText: Type.Missing,
            //                        MatchCase: false,
            //                        MatchWholeWord: false,
            //                        MatchWildcards: false,
            //                        MatchSoundsLike: missing,
            //                        MatchAllWordForms: false,
            //                        Forward: true,
            //                        Wrap: wrap,
            //                        Format: false,
            //                        ReplaceWith: missing,
            //                        Replace: replace);
            //                    break;
            //                }
            //            case "<REP>":
            //                {
            //                    Word.Find find = app.Selection.Find;
            //                    find.Text = key;
            //                    find.Replacement.Text = rep;
            //                    Object wrap = Word.WdFindWrap.wdFindContinue;
            //                    Object replace = Word.WdReplace.wdReplaceAll;
            //                    find.Execute(FindText: Type.Missing,
            //                        MatchCase: false,
            //                        MatchWholeWord: false,
            //                        MatchWildcards: false,
            //                        MatchSoundsLike: missing,
            //                        MatchAllWordForms: false,
            //                        Forward: true,
            //                        Wrap: wrap,
            //                        Format: false,
            //                        ReplaceWith: missing,
            //                        Replace: replace);
            //                    break;
            //                }
            //            case "<COST>":
            //                {
            //                    Word.Find find = app.Selection.Find;
            //                    find.Text = key;
            //                    find.Replacement.Text = cost.ToString();
            //                    Object wrap = Word.WdFindWrap.wdFindContinue;
            //                    Object replace = Word.WdReplace.wdReplaceAll;
            //                    find.Execute(FindText: Type.Missing,
            //                        MatchCase: false,
            //                        MatchWholeWord: false,
            //                        MatchWildcards: false,
            //                        MatchSoundsLike: missing,
            //                        MatchAllWordForms: false,
            //                        Forward: true,
            //                        Wrap: wrap,
            //                        Format: false,
            //                        ReplaceWith: missing,
            //                        Replace: replace);
            //                    break;
            //                }
            //            case "<AMOUNT>":
            //                {
            //                    Word.Find find = app.Selection.Find;
            //                    find.Text = key;
            //                    find.Replacement.Text = amount.ToString();
            //                    Object wrap = Word.WdFindWrap.wdFindContinue;
            //                    Object replace = Word.WdReplace.wdReplaceAll;
            //                    find.Execute(FindText: Type.Missing,
            //                        MatchCase: false,
            //                        MatchWholeWord: false,
            //                        MatchWildcards: false,
            //                        MatchSoundsLike: missing,
            //                        MatchAllWordForms: false,
            //                        Forward: true,
            //                        Wrap: wrap,
            //                        Format: false,
            //                        ReplaceWith: missing,
            //                        Replace: replace);
            //                    break;
            //                }
            //            case "<SUM>":
            //                {
            //                    Word.Find find = app.Selection.Find;
            //                    find.Text = key;
            //                    find.Replacement.Text = amount.ToString();
            //                    Object wrap = Word.WdFindWrap.wdFindContinue;
            //                    Object replace = Word.WdReplace.wdReplaceAll;
            //                    find.Execute(FindText: Type.Missing,
            //                        MatchCase: false,
            //                        MatchWholeWord: false,
            //                        MatchWildcards: false,
            //                        MatchSoundsLike: missing,
            //                        MatchAllWordForms: false,
            //                        Forward: true,
            //                        Wrap: wrap,
            //                        Format: false,
            //                        ReplaceWith: missing,
            //                        Replace: replace);
            //                    break;
            //                }
            //            case "<NAME>":
            //                {
            //                    Word.Find find = app.Selection.Find;
            //                    find.Text = key;
            //                    find.Replacement.Text = name;
            //                    Object wrap = Word.WdFindWrap.wdFindContinue;
            //                    Object replace = Word.WdReplace.wdReplaceAll;
            //                    find.Execute(FindText: Type.Missing,
            //                        MatchCase: false,
            //                        MatchWholeWord: false,
            //                        MatchWildcards: false,
            //                        MatchSoundsLike: missing,
            //                        MatchAllWordForms: false,
            //                        Forward: true,
            //                        Wrap: wrap,
            //                        Format: false,
            //                        ReplaceWith: missing,
            //                        Replace: replace);
            //                    break;
            //                }
            //            case "<TITLE>":
            //                {
            //                    Word.Find find = app.Selection.Find;
            //                    find.Text = key;
            //                    find.Replacement.Text = title;
            //                    Object wrap = Word.WdFindWrap.wdFindContinue;
            //                    Object replace = Word.WdReplace.wdReplaceAll;
            //                    find.Execute(FindText: Type.Missing,
            //                        MatchCase: false,
            //                        MatchWholeWord: false,
            //                        MatchWildcards: false,
            //                        MatchSoundsLike: missing,
            //                        MatchAllWordForms: false,
            //                        Forward: true,
            //                        Wrap: wrap,
            //                        Format: false,
            //                        ReplaceWith: missing,
            //                        Replace: replace);
            //                    break;
            //                }
            //            case "<NUM>":
            //                {
            //                    Word.Find find = app.Selection.Find;
            //                    find.Text = key;
            //                    find.Replacement.Text = num;
            //                    Object wrap = Word.WdFindWrap.wdFindContinue;
            //                    Object replace = Word.WdReplace.wdReplaceAll;
            //                    find.Execute(FindText: Type.Missing,
            //                        MatchCase: false,
            //                        MatchWholeWord: false,
            //                        MatchWildcards: false,
            //                        MatchSoundsLike: missing,
            //                        MatchAllWordForms: false,
            //                        Forward: true,
            //                        Wrap: wrap,
            //                        Format: false,
            //                        ReplaceWith: missing,
            //                        Replace: replace);
            //                    break;
                            //}
                    //}
                    
                //}
            //}
            //catch (Exception ex)
            //{
            //}
            //finally
            //{
            //    cheque = "C:\\Users\\ShiroEmpty\\source\\repos\\TechoLand\\Resources\\Акт Купли-продажи №" + num + ".doc";
            //    app.ActiveDocument.SaveAs2(cheque);
            //    app.ActiveDocument.Close();
            //    app.Quit();
            //    Order order = new Order
            //    {
            //        ID = orders.Count + 1,
            //        BuyerID = buyerid,
            //        Amount = amount,
            //        OrderStatus = 1,
            //        OrderDate = DateTime.Now,
            //        Cheque = ""
            //    };
            //    entities.Order.Add(order);
            //    entities.SaveChanges();
            //    production.SearchFilterSort();
            //    this.Close();
            //    cart.Close();
            //    production.Show();
            //}
        }
        
    }
}
