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
    /// Lógica interna para DeleteTypeWindow.xaml
    /// </summary>
    public partial class DeleteTypeWindow : Window
    {
        public ComboBox comboBox;
        public ComboBox costBox;
        public DeleteTypeWindow(ComboBox comboBox, ComboBox costBox)
        {
            this.comboBox = comboBox;
            this.costBox = costBox;
            InitializeComponent();
        }

        private void TypeButton_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].ToString() == DeletedType.Text)
                {
                    comboBox.Items.RemoveAt(i);
                    costBox.Items.RemoveAt(i);
                }
            }
            this.Close();
            
        }
    }
}
