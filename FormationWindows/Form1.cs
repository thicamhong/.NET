using FormationEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormationWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookRepository repo = new BookRepository();

            // On recupere le id entre dans le textBox1 
            int id = int.Parse(textBox1.Text);

            if (id != 0)
            {
                // Apd la, on fait un GetById pour avoir le book de cet id
                Book book = repo.GetById(id);

                if (book != null)
                {
                    textBox2.Text = book.Id.ToString();
                    textBox3.Text = book.Title;
                    textBox4.Text = book.Price.ToString();
                }
            }

        }


    }
}
