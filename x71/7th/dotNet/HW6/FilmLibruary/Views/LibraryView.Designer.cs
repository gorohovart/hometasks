namespace FilmLibruary.Views
{
    partial class LibraryView
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilmsGrid = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PictureColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProducerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainActorsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormStateLabel = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilmsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(923, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDBToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDBToolStripMenuItem
            // 
            this.openDBToolStripMenuItem.Name = "openDBToolStripMenuItem";
            this.openDBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openDBToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.openDBToolStripMenuItem.Text = "Open DB";
            this.openDBToolStripMenuItem.Click += new System.EventHandler(this.OpenDbClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editFilmToolStripMenuItem,
            this.removeFilmToolStripMenuItem,
            this.findFilmToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editFilmToolStripMenuItem
            // 
            this.editFilmToolStripMenuItem.Name = "editFilmToolStripMenuItem";
            this.editFilmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editFilmToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.editFilmToolStripMenuItem.Text = "Edit film";
            this.editFilmToolStripMenuItem.Click += new System.EventHandler(this.EditFilmClick);
            // 
            // removeFilmToolStripMenuItem
            // 
            this.removeFilmToolStripMenuItem.Name = "removeFilmToolStripMenuItem";
            this.removeFilmToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeFilmToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.removeFilmToolStripMenuItem.Text = "Remove film";
            this.removeFilmToolStripMenuItem.Click += new System.EventHandler(this.RemoveFilmsClick);
            // 
            // findFilmToolStripMenuItem
            // 
            this.findFilmToolStripMenuItem.Name = "findFilmToolStripMenuItem";
            this.findFilmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findFilmToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.findFilmToolStripMenuItem.Text = "Find film";
            this.findFilmToolStripMenuItem.Click += new System.EventHandler(this.FindFilmClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutClick);
            // 
            // FilmsGrid
            // 
            this.FilmsGrid.AllowUserToAddRows = false;
            this.FilmsGrid.AllowUserToDeleteRows = false;
            this.FilmsGrid.AllowUserToResizeColumns = false;
            this.FilmsGrid.AllowUserToResizeRows = false;
            this.FilmsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FilmsGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FilmsGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FilmsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FilmsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilmsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.PictureColumn,
            this.NameColumn,
            this.YearColumn,
            this.CountryColumn,
            this.ProducerColumn,
            this.MainActorsColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FilmsGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.FilmsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.FilmsGrid.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FilmsGrid.Location = new System.Drawing.Point(0, 48);
            this.FilmsGrid.Name = "FilmsGrid";
            this.FilmsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FilmsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.FilmsGrid.RowHeadersVisible = false;
            this.FilmsGrid.RowHeadersWidth = 4;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.FilmsGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.FilmsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FilmsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FilmsGrid.Size = new System.Drawing.Size(923, 622);
            this.FilmsGrid.TabIndex = 1;
            this.FilmsGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FilmsGridColumnHeaderMouseClick);
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "Id";
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.IdColumn.Visible = false;
            // 
            // PictureColumn
            // 
            this.PictureColumn.DataPropertyName = "Picture";
            this.PictureColumn.HeaderText = "Picture";
            this.PictureColumn.Name = "PictureColumn";
            this.PictureColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // NameColumn
            // 
            this.NameColumn.DataPropertyName = "Name";
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // YearColumn
            // 
            this.YearColumn.DataPropertyName = "Year";
            this.YearColumn.HeaderText = "Year";
            this.YearColumn.Name = "YearColumn";
            // 
            // CountryColumn
            // 
            this.CountryColumn.DataPropertyName = "Country";
            this.CountryColumn.HeaderText = "Country";
            this.CountryColumn.Name = "CountryColumn";
            // 
            // ProducerColumn
            // 
            this.ProducerColumn.DataPropertyName = "Producer";
            this.ProducerColumn.HeaderText = "Producer";
            this.ProducerColumn.Name = "ProducerColumn";
            this.ProducerColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MainActorsColumn
            // 
            this.MainActorsColumn.DataPropertyName = "Actors";
            this.MainActorsColumn.HeaderText = "Actors";
            this.MainActorsColumn.Name = "MainActorsColumn";
            this.MainActorsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FormStateLabel
            // 
            this.FormStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormStateLabel.Location = new System.Drawing.Point(252, 24);
            this.FormStateLabel.Name = "FormStateLabel";
            this.FormStateLabel.Size = new System.Drawing.Size(400, 21);
            this.FormStateLabel.TabIndex = 2;
            this.FormStateLabel.Text = "База фильмов не выбрана";
            this.FormStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LibruaryView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(923, 672);
            this.Controls.Add(this.FormStateLabel);
            this.Controls.Add(this.FilmsGrid);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MaximumSize = new System.Drawing.Size(939, 710);
            this.MinimumSize = new System.Drawing.Size(939, 710);
            this.Name = "LibruaryView";
            this.Text = "Film libruary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LibruaryViewFormClosing);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilmsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editFilmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFilmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findFilmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView FilmsGrid;
        private System.Windows.Forms.Label FormStateLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewImageColumn PictureColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProducerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainActorsColumn;
    }
}

