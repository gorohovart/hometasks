namespace FilmLibruary.Views
{
    partial class EditFilmView
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
            this.components = new System.ComponentModel.Container();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.FilmNameLabel = new System.Windows.Forms.Label();
            this.FilmYearLabel = new System.Windows.Forms.Label();
            this.ProducerLabel = new System.Windows.Forms.Label();
            this.FilmNameTextBox = new System.Windows.Forms.TextBox();
            this.ProducerTextBox = new System.Windows.Forms.TextBox();
            this.SaveFilmButton = new System.Windows.Forms.Button();
            this.EditFilmErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.editYearTextBox = new FilmLibruary.Views.YearTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.EditFilmErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelInfo
            // 
            this.LabelInfo.AutoSize = true;
            this.LabelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelInfo.Location = new System.Drawing.Point(148, 9);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(65, 20);
            this.LabelInfo.TabIndex = 0;
            this.LabelInfo.Text = "Edit film";
            // 
            // FilmNameLabel
            // 
            this.FilmNameLabel.AutoSize = true;
            this.FilmNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilmNameLabel.Location = new System.Drawing.Point(12, 62);
            this.FilmNameLabel.Name = "FilmNameLabel";
            this.FilmNameLabel.Size = new System.Drawing.Size(70, 16);
            this.FilmNameLabel.TabIndex = 1;
            this.FilmNameLabel.Text = "Film name";
            // 
            // FilmYearLabel
            // 
            this.FilmYearLabel.AutoSize = true;
            this.FilmYearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilmYearLabel.Location = new System.Drawing.Point(13, 114);
            this.FilmYearLabel.Name = "FilmYearLabel";
            this.FilmYearLabel.Size = new System.Drawing.Size(63, 16);
            this.FilmYearLabel.TabIndex = 2;
            this.FilmYearLabel.Text = "Film year";
            // 
            // ProducerLabel
            // 
            this.ProducerLabel.AutoSize = true;
            this.ProducerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProducerLabel.Location = new System.Drawing.Point(12, 161);
            this.ProducerLabel.Name = "ProducerLabel";
            this.ProducerLabel.Size = new System.Drawing.Size(63, 16);
            this.ProducerLabel.TabIndex = 3;
            this.ProducerLabel.Text = "Producer";
            // 
            // FilmNameTextBox
            // 
            this.FilmNameTextBox.Location = new System.Drawing.Point(113, 62);
            this.FilmNameTextBox.Name = "FilmNameTextBox";
            this.FilmNameTextBox.Size = new System.Drawing.Size(239, 20);
            this.FilmNameTextBox.TabIndex = 4;
            // 
            // ProducerTextBox
            // 
            this.ProducerTextBox.Location = new System.Drawing.Point(113, 157);
            this.ProducerTextBox.Name = "ProducerTextBox";
            this.ProducerTextBox.Size = new System.Drawing.Size(175, 20);
            this.ProducerTextBox.TabIndex = 6;
            // 
            // SaveFilmButton
            // 
            this.SaveFilmButton.Location = new System.Drawing.Point(277, 194);
            this.SaveFilmButton.Name = "SaveFilmButton";
            this.SaveFilmButton.Size = new System.Drawing.Size(75, 23);
            this.SaveFilmButton.TabIndex = 7;
            this.SaveFilmButton.Text = "Save";
            this.SaveFilmButton.UseVisualStyleBackColor = true;
            this.SaveFilmButton.Click += new System.EventHandler(this.SaveFilmButtonClick);
            // 
            // EditFilmErrorProvider
            // 
            this.EditFilmErrorProvider.ContainerControl = this;
            // 
            // editYearTextBox
            // 
            this.editYearTextBox.Location = new System.Drawing.Point(113, 114);
            this.editYearTextBox.Name = "editYearTextBox";
            this.editYearTextBox.Size = new System.Drawing.Size(125, 27);
            this.editYearTextBox.TabIndex = 8;
            // 
            // EditFilmView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(381, 237);
            this.Controls.Add(this.editYearTextBox);
            this.Controls.Add(this.SaveFilmButton);
            this.Controls.Add(this.ProducerTextBox);
            this.Controls.Add(this.FilmNameTextBox);
            this.Controls.Add(this.ProducerLabel);
            this.Controls.Add(this.FilmYearLabel);
            this.Controls.Add(this.FilmNameLabel);
            this.Controls.Add(this.LabelInfo);
            this.MaximumSize = new System.Drawing.Size(397, 275);
            this.MinimumSize = new System.Drawing.Size(397, 275);
            this.Name = "EditFilmView";
            this.Text = "Edit film";
            this.Load += new System.EventHandler(this.EditFilmViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.EditFilmErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.Label FilmNameLabel;
        private System.Windows.Forms.Label FilmYearLabel;
        private System.Windows.Forms.Label ProducerLabel;
        private System.Windows.Forms.TextBox FilmNameTextBox;
        private System.Windows.Forms.TextBox ProducerTextBox;
        private System.Windows.Forms.Button SaveFilmButton;
        private System.Windows.Forms.ErrorProvider EditFilmErrorProvider;
        private YearTextBox editYearTextBox;
    }
}