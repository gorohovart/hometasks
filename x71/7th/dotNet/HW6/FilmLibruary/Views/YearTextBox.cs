using System;
using System.Linq;
using System.Windows.Forms;
using FilmLibruary.Model;

namespace FilmLibruary.Views
{
    internal sealed class YearTextBox : UserControl
    {
        public TextBox InternalTextBox;
        private ErrorProvider yearErrorProvider;
        private System.ComponentModel.IContainer components;
        private const int _minYear = 1895;
        private readonly int maxYear = DateTime.Now.Year;
        private readonly char backSpace = (char) 8;

        public YearTextBox()
        {
            InitializeComponent();
        }
    
        public bool IsYearValid()
        {
            if (InternalTextBox.Text == string.Empty)
            {
                return true;
            }
            
            bool isDigits = InternalTextBox.Text.All(char.IsDigit);
            if (!isDigits) return false;

            int year = Convert.ToInt32(InternalTextBox.Text);
            var isValid = (year <= SearchDescriptor.MaxYear && year >= SearchDescriptor.MinYear);

            if (!isValid)
            {
                yearErrorProvider.SetError(this, string.Format("Year must be between {0} and {1}", _minYear, maxYear));
                Focus();
                return false;
            }
            else
            {
                yearErrorProvider.SetError(this, string.Empty);
                return true;
            }
        }

        private void YearTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender == null || e == null) return;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != backSpace
                || (InternalTextBox.Text.Length > SearchDescriptor.NumberOfDigitsInYear - 1) && e.KeyChar != backSpace)
            {
                e.Handled = true;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.InternalTextBox = new System.Windows.Forms.TextBox();
            this.yearErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.yearErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // InternalTextBox
            // 
            this.InternalTextBox.Location = new System.Drawing.Point(0, 0);
            this.InternalTextBox.Name = "InternalTextBox";
            this.InternalTextBox.Size = new System.Drawing.Size(83, 20);
            this.InternalTextBox.TabIndex = 0;
            this.InternalTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YearTextBoxKeyPress);
            // 
            // yearErrorProvider
            // 
            this.yearErrorProvider.ContainerControl = this;
            // 
            // YearTextBox
            // 
            this.Controls.Add(this.InternalTextBox);
            this.Name = "YearTextBox";
            this.Size = new System.Drawing.Size(84, 20);
            ((System.ComponentModel.ISupportInitialize)(this.yearErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
