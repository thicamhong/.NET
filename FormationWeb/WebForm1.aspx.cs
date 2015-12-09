using FormationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormationWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BookRepository repo = new BookRepository();

            // On recupere le id entre dans le textBox1 
            int id = int.Parse(TextBox1.Text);

            if (id != 0)
            {
                // Apd la, on fait un GetById pour avoir le book de cet id
                Book book = repo.GetById(id);

                if (book != null)
                {
                    TextBox2.Text = book.Id.ToString();
                    TextBox3.Text = book.Title;
                    TextBox4.Text = book.Price.ToString();
                }
            }
        }
    }
}