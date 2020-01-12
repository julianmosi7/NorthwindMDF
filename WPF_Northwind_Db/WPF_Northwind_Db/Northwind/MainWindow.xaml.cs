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
using ClassLibrary;

namespace Northwind
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }
        NorthwindContext db;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new NorthwindContext();
            Title = db.Categories.Count().ToString();
            db.Suppliers
                .OrderBy(x => x.CompanyName)
                .ToList()
                .ForEach(x => listBox.Items.Add(x));

            db.Employees
                .OrderBy(x => x.LastName)
                .ToList()
                .ForEach(x => listBox1.Items.Add(x));

        }


        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Suppliers sp = e.AddedItems[0] as Suppliers;
            db.Products
                .Where(x => x.Suppliers.SupplierID.Equals(sp.SupplierID))
                .ToList()
                .ForEach(x => dataGrid.Items.Add(x));
        }
    }
}
