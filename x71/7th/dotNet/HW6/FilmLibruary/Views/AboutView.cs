using System;
using System.Drawing;
using System.Windows.Forms;

namespace FilmLibruary.Views
{
    internal partial class AboutView : Form
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void AboutViewLoad(object sender, EventArgs e)
        {
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }
    }
}
