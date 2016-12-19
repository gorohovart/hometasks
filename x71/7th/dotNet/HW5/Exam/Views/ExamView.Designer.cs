namespace Exam.Views
{
    partial class ExamView
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
            this.resultsListView = new System.Windows.Forms.ListView();
            this.StartButton = new System.Windows.Forms.Button();
            this.examProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // resultsListView
            // 
            this.resultsListView.Location = new System.Drawing.Point(3, 1);
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.Size = new System.Drawing.Size(308, 288);
            this.resultsListView.TabIndex = 0;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            this.resultsListView.View = System.Windows.Forms.View.Details;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(120, 324);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "button1";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // examProgressBar
            // 
            this.examProgressBar.Location = new System.Drawing.Point(3, 295);
            this.examProgressBar.Name = "examProgressBar";
            this.examProgressBar.Size = new System.Drawing.Size(308, 23);
            this.examProgressBar.TabIndex = 3;
            // 
            // ExamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 349);
            this.Controls.Add(this.examProgressBar);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.resultsListView);
            this.Name = "ExamView";
            this.Text = "ExamView";
            this.Load += new System.EventHandler(this.ExamView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

        }

        #endregion

        private System.Windows.Forms.ListView resultsListView;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ProgressBar examProgressBar;
    }
}