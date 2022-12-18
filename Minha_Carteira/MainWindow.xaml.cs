using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Minha_Carteira.Data;

namespace Minha_Carteira
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Context context;
        Entry newEntry = new();


        public MainWindow(Context context)
        {
            this.context = context;
            InitializeComponent();
            GetEntries();
            NewEntryGrid.DataContext = newEntry;
        }

        private void GetEntries()
        {
            EntryDataGrid.ItemsSource = context.Entries.ToList();
            var balance = context.Entries.Sum(Entry => Entry.Value);
            Balance.Text = "Saldo Atual: R$" + balance.ToString("0.00");

            if (balance > 0) BalanceBack.Background = new SolidColorBrush(Colors.LightGreen);
                else BalanceBack.Background = new SolidColorBrush(Colors.LightSalmon);
        }
        private void AddItem(object sender, RoutedEventArgs e)
        {
            if (Names.Text != "" && Date.SelectedDate != null && Value.Text != "0" && Value.Text != "" && Type.SelectedItem != null && (Expsense.IsChecked == true || Gain.IsChecked == true))
            {
                if (Expsense.IsChecked == true)
                {
                    newEntry.Value = newEntry.Value * (-1);
                }
               
                context.Entries.Add(newEntry);
                context.SaveChanges();

                GetEntries();

                Expsense.IsChecked = false;
                Gain.IsChecked = false;


                newEntry = new Entry();
                NewEntryGrid.DataContext = newEntry;

                
            }
            else MessageBox.Show("Preencha todos os campos obrigatórios");

            
        }

        public static bool IsValid(string str)
        {
            double i;
            return double.TryParse(str,out  i);
        }

        private void Value_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            var entries = context.Entries.ToList();

            var nameGrid = EntryDataGrid.SelectedItems[0];

            foreach(var entry in entries)
            {
                if(entry == nameGrid)
                {
                    context.Entries.Remove(entry);
                    context.SaveChanges();
                }
            }

            GetEntries();

        }

        private void AddType(object sender, RoutedEventArgs e)
        {
            var typeWindow = new NewTypeWindow(Type,CostType);
            typeWindow.Show();
            
        }

        private void DeleteType(object sender, RoutedEventArgs e)
        {
            var typeWindow = new DeleteTypeWindow(Type,CostType);
            typeWindow.Show();

        }


        private void CostType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            var entries = context.Entries.ToList();

            List<Entry> entriesType = new();

            double sum = 0.0;

            foreach (var entry in entries)
            {
                if (entry.Type == CostType.SelectedItem.ToString())
                {
                    entriesType.Add(entry);
                }
            }

            foreach (var entry in entriesType)
            {
                sum += entry.Value;
            }

            cost.Text = "R$ " + sum.ToString();
        }
    }
}
