using System;
using System.Drawing;
using System.Windows.Forms;
using FilmLibruary.CustomEventArgs;
using FilmLibruary.Model;

namespace FilmLibruary.Views
{
    internal partial class EditFilmView : Form
    {
        private char backSpace = (char)8;
        public event EventHandler EditFilmCompleted;
        private readonly FieldValidator.FieldValidator _validator = new FieldValidator.FieldValidator();
        public FilmViewModel EditedFilm { get; set; }

        public EditFilmView()
        {
            InitializeComponent();
        }

        private void InitTextBoxes()
        {
            ProducerTextBox.Text = EditedFilm.Producer;
            editYearTextBox.InternalTextBox.Text = EditedFilm.Year.ToString();
            FilmNameTextBox.Text = EditedFilm.Name;
        }

        #region EventsHandlers
        private void EditFilmViewLoad(object sender, EventArgs e)
        {
            if (sender == null || e == null) return;
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);
            InitTextBoxes();
        }

        private void SaveFilmButtonClick(object sender, EventArgs e)
        {
            if (sender == null || e == null) return;
            var isValid = ValidateForm();
            if (!isValid)
            {
                return;
            }

            var editedFilmDescriptor = new FilmEditDescriptor
            {
                Producer = ProducerTextBox.Text,
                Year = editYearTextBox.InternalTextBox.Text == string.Empty ? 0 : Convert.ToInt32(editYearTextBox.InternalTextBox.Text),
                Name = FilmNameTextBox.Text,
                FilmId = EditedFilm.Id
            };

            EditFilmCompleted?.Invoke(this, new FilmEditDescriptorEventArgs(editedFilmDescriptor));
            Close();
        }
        #endregion

        #region Validation
        private bool ValidateForm()
        {
            bool isValid = true;
            if (!_validator.IsStringValid(FilmNameTextBox.Text))
            {
                EditFilmErrorProvider.SetError(FilmNameTextBox, "Wrong chars");
                FilmNameTextBox.Focus();
                isValid = false;
            }
            if (!editYearTextBox.IsYearValid())
            {
                isValid = false;
            }
            if (!_validator.IsStringValid(ProducerTextBox.Text))
            {
                EditFilmErrorProvider.SetError(ProducerTextBox, "Incorrect year");
                ProducerTextBox.Focus();
                isValid = false;
            }
            else
            {
                EditFilmErrorProvider.SetError(FilmNameTextBox, String.Empty);
            }
            return isValid;
        }
        #endregion
    }
}
