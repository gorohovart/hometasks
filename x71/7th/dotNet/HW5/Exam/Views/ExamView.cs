using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam.Views
{
    internal partial class ExamView : Form, IExamView
    {
        public event EventHandler ExamStarted;
        public void AddStudentName(Student student)
        {
            resultsListView.Items.Add(new ListViewItem(new[] { resultsListView.Items.Count.ToString(), student.Name, "" }));
        }

        private void InvokeIfRequired(Action action, Control control)
        {
            if (control.InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }
        public void ShowStudentMarkAndUpdateProgress(Student student)
        {
            if (student == null || student.Mark < 2 || student.Mark > 5)
            {
                throw new ArgumentOutOfRangeException();
            }
            foreach (ListViewItem item in resultsListView.Items)
            {
                if ((item != null) && (item.SubItems[1].Name == student.Name))
                {
                    item.SubItems[2].Name = student.Mark.ToString();
                }
            }
            examProgressBar.PerformStep();
        }

        public void FinishExam()
        {
            StartButton.Enabled = true;
        }

        public void SetProgressBarMaxValue(int max)
        {
            examProgressBar.Maximum = max;
        }

        public ExamView()
        {
            InitializeComponent();
            AddColumnsListView();
            this.SizeChanged += OnFormSizeChanges;
            StartButton.Click += OnButtonStartClick;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OnFormSizeChanges(object sender, EventArgs e)
        {
            AddColumnsListView();
        }
        private void OnButtonStartClick(object sender, EventArgs e)
        {
            StartButton.Enabled = false;
            examProgressBar.Value = 0;
            resultsListView.Items.Clear();
            resultsListView.Refresh();
            ExamStarted?.Invoke(this, EventArgs.Empty);
        }
        
        private void AddColumnsListView()
        {
            var width = resultsListView.Size.Width;
            var numWidth = width / 10 * 2 -1;
            var nameWidth = width / 10 * 6 - 1;
            var markWidth = width / 10 * 2 - 1;

            if (resultsListView.Columns.Count == 0)
            {
                resultsListView.Columns.Add("#", numWidth, HorizontalAlignment.Center);
                resultsListView.Columns.Add("Имя студента", nameWidth, HorizontalAlignment.Center);
                resultsListView.Columns.Add("Оценка", markWidth, HorizontalAlignment.Center);
            }
            else
            {
                resultsListView.Columns[0].Width = numWidth;
                resultsListView.Columns[1].Width = nameWidth;
                resultsListView.Columns[2].Width = markWidth;
            }
            resultsListView.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ExamView_Load(object sender, EventArgs e)
        {

        }
    }
}
