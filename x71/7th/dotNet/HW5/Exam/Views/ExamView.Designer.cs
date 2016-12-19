using System.Drawing;
using System.Windows.Forms;

namespace Exam.Views
{
    sealed partial class ExamView
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
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resultsListView
            // 
            this.resultsListView.Location = new System.Drawing.Point(3, 1);
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.Size = new System.Drawing.Size(308, 288);
            this.resultsListView.TabIndex = 1;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            this.resultsListView.View = System.Windows.Forms.View.Details;
            // 
            // StartButton
            //
           
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "button1";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // examProgressBar
            // 
            this.examProgressBar.Location = new System.Drawing.Point(3, 295);
            this.examProgressBar.Name = "examProgressBar";
            this.examProgressBar.Size = new System.Drawing.Size(308, 32);
            this.examProgressBar.Step = 1;
            this.examProgressBar.TabIndex = 3;
            // 
            // label1
            // 
            progressBarLabel.AutoSize = false;
            progressBarLabel.Width = 20;
            progressBarLabel.TextAlign = ContentAlignment.MiddleCenter;
            progressBarLabel.Location = new Point((ClientSize.Width - progressBarLabel.Width) / 2, 305);
            this.progressBarLabel.Name = "progressBarLabel";
            this.progressBarLabel.Size = new System.Drawing.Size(35, 13);
            this.progressBarLabel.TabIndex = 4;
            this.progressBarLabel.BackColor = Color.Transparent;


            AddColumnsListView();
            UpdateStartButtonState(StartButtonSize.First);
            // 
            // ExamView
            // 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 368);
            this.Controls.Add(this.progressBarLabel);
            this.Controls.Add(this.examProgressBar);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.resultsListView);
            this.MaximizeBox = false;
            this.Name = "ExamView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExamView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView resultsListView;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ProgressBar examProgressBar;
        private System.Windows.Forms.Label progressBarLabel;
    }
}