using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFilmDatabase.Views
{
    public partial class NewFilmView : Form
    {
        public NewFilmView()
        {
            InitializeComponent();
        }
        
        private void ChooseImageButton_Click(object sender, EventArgs e)
        {
            ChooseImageDialog.ShowDialog();
            pictureBox.ImageLocation = ChooseImageDialog.FileName;
        }
    }
}
