namespace FilmLibruary.Views
{
    sealed partial class FindFilmView
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
            this.FilmNameTextBox = new System.Windows.Forms.TextBox();
            this.FindFilmWindowNameLabel = new System.Windows.Forms.Label();
            this.FilmNameLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.YearFromLabel = new System.Windows.Forms.Label();
            this.YearToLabel = new System.Windows.Forms.Label();
            this.CountryLabel = new System.Windows.Forms.Label();
            this.CountryTextBox = new System.Windows.Forms.TextBox();
            this.ProducerLabel = new System.Windows.Forms.Label();
            this.ProducerTextBox = new System.Windows.Forms.TextBox();
            this.MainActorsLabel = new System.Windows.Forms.Label();
            this.MainActorsTextBox = new System.Windows.Forms.TextBox();
            this.FindButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.FindErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.FindHelpProvider = new System.Windows.Forms.HelpProvider();
            this.FindFilmInfoLabel = new System.Windows.Forms.Label();
            this.YearToTextBox = new FilmLibruary.Views.YearTextBox();
            this.YearFromTextBox = new FilmLibruary.Views.YearTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FindErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // FilmNameTextBox
            // 
            this.FilmNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindHelpProvider.SetHelpString(this.FilmNameTextBox, "Enter the film name. \'*\' and \'?\' is allowed for make regular expression");
            this.FilmNameTextBox.Location = new System.Drawing.Point(141, 71);
            this.FilmNameTextBox.Name = "FilmNameTextBox";
            this.FindHelpProvider.SetShowHelp(this.FilmNameTextBox, true);
            this.FilmNameTextBox.Size = new System.Drawing.Size(263, 20);
            this.FilmNameTextBox.TabIndex = 0;
            // 
            // FindFilmWindowNameLabel
            // 
            this.FindFilmWindowNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FindFilmWindowNameLabel.AutoSize = true;
            this.FindFilmWindowNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindFilmWindowNameLabel.Location = new System.Drawing.Point(164, 9);
            this.FindFilmWindowNameLabel.Name = "FindFilmWindowNameLabel";
            this.FindFilmWindowNameLabel.Size = new System.Drawing.Size(124, 20);
            this.FindFilmWindowNameLabel.TabIndex = 1;
            this.FindFilmWindowNameLabel.Text = "Find film window";
            // 
            // FilmNameLabel
            // 
            this.FilmNameLabel.AutoSize = true;
            this.FilmNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilmNameLabel.Location = new System.Drawing.Point(12, 71);
            this.FilmNameLabel.Name = "FilmNameLabel";
            this.FilmNameLabel.Size = new System.Drawing.Size(70, 16);
            this.FilmNameLabel.TabIndex = 2;
            this.FilmNameLabel.Text = "Film name";
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearLabel.Location = new System.Drawing.Point(12, 113);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(98, 16);
            this.YearLabel.TabIndex = 3;
            this.YearLabel.Text = "Released year";
            // 
            // YearFromLabel
            // 
            this.YearFromLabel.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YearFromLabel.AutoSize = true;
            this.YearFromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearFromLabel.Location = new System.Drawing.Point(139, 113);
            this.YearFromLabel.Name = "YearFromLabel";
            this.YearFromLabel.Size = new System.Drawing.Size(34, 16);
            this.YearFromLabel.TabIndex = 4;
            this.YearFromLabel.Text = "from";
            // 
            // YearToLabel
            // 
            this.YearToLabel.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YearToLabel.AutoSize = true;
            this.YearToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearToLabel.Location = new System.Drawing.Point(294, 113);
            this.YearToLabel.Name = "YearToLabel";
            this.YearToLabel.Size = new System.Drawing.Size(19, 16);
            this.YearToLabel.TabIndex = 6;
            this.YearToLabel.Text = "to";
            // 
            // CountryLabel
            // 
            this.CountryLabel.AutoSize = true;
            this.CountryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountryLabel.Location = new System.Drawing.Point(12, 150);
            this.CountryLabel.Name = "CountryLabel";
            this.CountryLabel.Size = new System.Drawing.Size(53, 16);
            this.CountryLabel.TabIndex = 8;
            this.CountryLabel.Text = "Country";
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindHelpProvider.SetHelpString(this.CountryTextBox, "Enter the country where firm was released. \'*\' and \'?\' is allowed for make regula" +
        "r expression");
            this.CountryTextBox.Location = new System.Drawing.Point(141, 146);
            this.CountryTextBox.Name = "CountryTextBox";
            this.FindHelpProvider.SetShowHelp(this.CountryTextBox, true);
            this.CountryTextBox.Size = new System.Drawing.Size(263, 20);
            this.CountryTextBox.TabIndex = 4;
            // 
            // ProducerLabel
            // 
            this.ProducerLabel.AutoSize = true;
            this.ProducerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProducerLabel.Location = new System.Drawing.Point(12, 190);
            this.ProducerLabel.Name = "ProducerLabel";
            this.ProducerLabel.Size = new System.Drawing.Size(63, 16);
            this.ProducerLabel.TabIndex = 10;
            this.ProducerLabel.Text = "Producer";
            // 
            // ProducerTextBox
            // 
            this.ProducerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindHelpProvider.SetHelpString(this.ProducerTextBox, "Enter the producer name. \'*\' and \'?\' is allowed for make regular expression");
            this.ProducerTextBox.Location = new System.Drawing.Point(141, 190);
            this.ProducerTextBox.Name = "ProducerTextBox";
            this.FindHelpProvider.SetShowHelp(this.ProducerTextBox, true);
            this.ProducerTextBox.Size = new System.Drawing.Size(263, 20);
            this.ProducerTextBox.TabIndex = 5;
            // 
            // MainActorsLabel
            // 
            this.MainActorsLabel.AutoSize = true;
            this.MainActorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainActorsLabel.Location = new System.Drawing.Point(15, 230);
            this.MainActorsLabel.Name = "MainActorsLabel";
            this.MainActorsLabel.Size = new System.Drawing.Size(78, 16);
            this.MainActorsLabel.TabIndex = 12;
            this.MainActorsLabel.Text = "Main Actors";
            // 
            // MainActorsTextBox
            // 
            this.MainActorsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FindHelpProvider.SetHelpString(this.MainActorsTextBox, "Enter main actors names. \'*\' and \'?\' is allowed for make regular expression");
            this.MainActorsTextBox.Location = new System.Drawing.Point(141, 226);
            this.MainActorsTextBox.Name = "MainActorsTextBox";
            this.FindHelpProvider.SetShowHelp(this.MainActorsTextBox, true);
            this.MainActorsTextBox.Size = new System.Drawing.Size(263, 20);
            this.MainActorsTextBox.TabIndex = 6;
            // 
            // FindButton
            // 
            this.FindButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FindButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindButton.Location = new System.Drawing.Point(312, 268);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(92, 31);
            this.FindButton.TabIndex = 7;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButtonClick);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(210, 268);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(92, 31);
            this.ClearButton.TabIndex = 15;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButtonClick);
            // 
            // FindErrorProvider
            // 
            this.FindErrorProvider.ContainerControl = this;
            // 
            // FindFilmInfoLabel
            // 
            this.FindFilmInfoLabel.AutoSize = true;
            this.FindFilmInfoLabel.Location = new System.Drawing.Point(12, 39);
            this.FindFilmInfoLabel.Name = "FindFilmInfoLabel";
            this.FindFilmInfoLabel.Size = new System.Drawing.Size(416, 13);
            this.FindFilmInfoLabel.TabIndex = 16;
            this.FindFilmInfoLabel.Text = "Please enter the textbox and find films. If you want to get a help for some field" +
    ", press F1";
            // 
            // YearToTextBox
            // 
            this.YearToTextBox.Location = new System.Drawing.Point(319, 113);
            this.YearToTextBox.Name = "YearToTextBox";
            this.YearToTextBox.Size = new System.Drawing.Size(85, 20);
            this.YearToTextBox.TabIndex = 3;
            // 
            // YearFromTextBox
            // 
            this.YearFromTextBox.Location = new System.Drawing.Point(179, 113);
            this.YearFromTextBox.Name = "YearFromTextBox";
            this.YearFromTextBox.Size = new System.Drawing.Size(85, 20);
            this.YearFromTextBox.TabIndex = 2;
            // 
            // FindFilmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 311);
            this.Controls.Add(this.YearToTextBox);
            this.Controls.Add(this.YearFromTextBox);
            this.Controls.Add(this.FindFilmInfoLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.MainActorsTextBox);
            this.Controls.Add(this.MainActorsLabel);
            this.Controls.Add(this.ProducerTextBox);
            this.Controls.Add(this.ProducerLabel);
            this.Controls.Add(this.CountryTextBox);
            this.Controls.Add(this.CountryLabel);
            this.Controls.Add(this.YearToLabel);
            this.Controls.Add(this.YearFromLabel);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.FilmNameLabel);
            this.Controls.Add(this.FindFilmWindowNameLabel);
            this.Controls.Add(this.FilmNameTextBox);
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimumSize = new System.Drawing.Size(455, 349);
            this.Name = "FindFilmView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find film";
            this.Load += new System.EventHandler(this.FindFilmViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.FindErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilmNameTextBox;
        private System.Windows.Forms.Label FindFilmWindowNameLabel;
        private System.Windows.Forms.Label FilmNameLabel;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label YearFromLabel;
        private System.Windows.Forms.Label YearToLabel;
        private System.Windows.Forms.Label CountryLabel;
        private System.Windows.Forms.TextBox CountryTextBox;
        private System.Windows.Forms.Label ProducerLabel;
        private System.Windows.Forms.TextBox ProducerTextBox;
        private System.Windows.Forms.Label MainActorsLabel;
        private System.Windows.Forms.TextBox MainActorsTextBox;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ErrorProvider FindErrorProvider;
        private System.Windows.Forms.HelpProvider FindHelpProvider;
        private System.Windows.Forms.Label FindFilmInfoLabel;
        private YearTextBox YearToTextBox;
        private YearTextBox YearFromTextBox;
    }
}