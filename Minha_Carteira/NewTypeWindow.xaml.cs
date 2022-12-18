using Minha_Carteira.Data;
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

namespace Minha_Carteira
{
    /// <summary>
    /// Lógica interna para NewTypeWindow.xaml
    /// </summary>
    public partial class NewTypeWindow : Window
    {
        public ComboBox comboBox;
        public ComboBox costBox;
        public NewTypeWindow(ComboBox comboBox, ComboBox costBox)
        {
            this.comboBox = comboBox;
            this.costBox = costBox;
            InitializeComponent();
        }

        private void TypeButton_Click(object sender, RoutedEventArgs e)
        {
            comboBox.Items.Add(NewType.Text);
            costBox.Items.Add(NewType.Text);
            this.Close();
        }
    }
}
