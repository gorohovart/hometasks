using System;
using System.Windows.Forms;

namespace MyFilmDatabase.CustomClasses
{
    public class UserInputValidatorTextBox : TextBox
    {
        public bool IsInputValid(Func<string, bool> inputValidator)
        {
            return inputValidator(this.Text);
        }
        
    }
}