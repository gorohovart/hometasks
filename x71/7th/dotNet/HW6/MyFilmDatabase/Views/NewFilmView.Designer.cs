namespace MyFilmDatabase.Views
{
    partial class NewFilmView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.FilmNameValidatorTextBox = new MyFilmDatabase.CustomClasses.UserInputValidatorTextBox();
            this.FilmNameLabel = new System.Windows.Forms.Label();
            this.FilmYearLabel = new System.Windows.Forms.Label();
            this.FilmYearValidatorTextBox = new MyFilmDatabase.CustomClasses.UserInputValidatorTextBox();
            this.FilmCountryLabel = new System.Windows.Forms.Label();
            this.FilmCountryValidatorTextBox = new MyFilmDatabase.CustomClasses.UserInputValidatorTextBox();
            this.ChooseImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.ChooseImageButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(22, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(182, 240);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // FilmNameValidatorTextBox
            // 
            this.FilmNameValidatorTextBox.Location = new System.Drawing.Point(223, 28);
            this.FilmNameValidatorTextBox.Name = "FilmNameValidatorTextBox";
            this.FilmNameValidatorTextBox.Size = new System.Drawing.Size(167, 20);
            this.FilmNameValidatorTextBox.TabIndex = 1;
            // 
            // FilmNameLabel
            // 
            this.FilmNameLabel.AutoSize = true;
            this.FilmNameLabel.Location = new System.Drawing.Point(220, 12);
            this.FilmNameLabel.Name = "FilmNameLabel";
            this.FilmNameLabel.Size = new System.Drawing.Size(35, 13);
            this.FilmNameLabel.TabIndex = 2;
            this.FilmNameLabel.Text = "label1";
            // 
            // FilmYearLabel
            // 
            this.FilmYearLabel.AutoSize = true;
            this.FilmYearLabel.Location = new System.Drawing.Point(399, 12);
            this.FilmYearLabel.Name = "FilmYearLabel";
            this.FilmYearLabel.Size = new System.Drawing.Size(35, 13);
            this.FilmYearLabel.TabIndex = 4;
            this.FilmYearLabel.Text = "label2";
            // 
            // FilmYearValidatorTextBox
            // 
            this.FilmYearValidatorTextBox.Location = new System.Drawing.Point(402, 28);
            this.FilmYearValidatorTextBox.Name = "FilmYearValidatorTextBox";
            this.FilmYearValidatorTextBox.Size = new System.Drawing.Size(61, 20);
            this.FilmYearValidatorTextBox.TabIndex = 3;
            // 
            // FilmCountryLabel
            // 
            this.FilmCountryLabel.AutoSize = true;
            this.FilmCountryLabel.Location = new System.Drawing.Point(475, 12);
            this.FilmCountryLabel.Name = "FilmCountryLabel";
            this.FilmCountryLabel.Size = new System.Drawing.Size(35, 13);
            this.FilmCountryLabel.TabIndex = 6;
            this.FilmCountryLabel.Text = "label2";
            // 
            // FilmCountryValidatorTextBox
            // 
            this.FilmCountryValidatorTextBox.Location = new System.Drawing.Point(478, 28);
            this.FilmCountryValidatorTextBox.Name = "FilmCountryValidatorTextBox";
            this.FilmCountryValidatorTextBox.Size = new System.Drawing.Size(96, 20);
            this.FilmCountryValidatorTextBox.TabIndex = 5;
            // 
            // ChooseImageDialog
            // 
            this.ChooseImageDialog.FileName = "ChooseImageDialog";
            // 
            // ChooseImageButton
            // 
            this.ChooseImageButton.Location = new System.Drawing.Point(22, 258);
            this.ChooseImageButton.Name = "ChooseImageButton";
            this.ChooseImageButton.Size = new System.Drawing.Size(182, 34);
            this.ChooseImageButton.TabIndex = 7;
            this.ChooseImageButton.Text = "ChooseImageButton";
            this.ChooseImageButton.UseVisualStyleBackColor = true;
            this.ChooseImageButton.Click += new System.EventHandler(this.ChooseImageButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(223, 226);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(211, 66);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // NewFilmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 321);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ChooseImageButton);
            this.Controls.Add(this.FilmCountryLabel);
            this.Controls.Add(this.FilmCountryValidatorTextBox);
            this.Controls.Add(this.FilmYearLabel);
            this.Controls.Add(this.FilmYearValidatorTextBox);
            this.Controls.Add(this.FilmNameLabel);
            this.Controls.Add(this.FilmNameValidatorTextBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "NewFilmView";
            this.Text = "NewFilmView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private CustomClasses.UserInputValidatorTextBox FilmNameValidatorTextBox;
        private System.Windows.Forms.Label FilmNameLabel;
        private System.Windows.Forms.Label FilmYearLabel;
        private CustomClasses.UserInputValidatorTextBox FilmYearValidatorTextBox;
        private System.Windows.Forms.Label FilmCountryLabel;
        private CustomClasses.UserInputValidatorTextBox FilmCountryValidatorTextBox;
        private System.Windows.Forms.OpenFileDialog ChooseImageDialog;
        private System.Windows.Forms.Button ChooseImageButton;
        private System.Windows.Forms.Button SaveButton;
    }
}