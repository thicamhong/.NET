using FormationEF;
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

namespace FormationWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BookRepository repo = new BookRepository();

            // On recupere le id entre dans le textBox1 
            int id = int.Parse(textBox.Text);

            if (id != 0)
            {
                // Apd la, on fait un GetById pour avoir le book de cet id
                Book book = repo.GetById(id);

                if (book != null)
                {
                    textBox1.Text = book.Id.ToString();
                    textBox2.Text = book.Title;
                    textBox3.Text = book.Price.ToString();
                }

            }
        }
    }
}
