using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Exam.Models;
using Exam.Properties;

namespace Exam.Views
{
    internal sealed partial class ExamView : Form, IExamView
    {
        private int _currentProgress;
        private int _studentsAmount;
        public event EventHandler ExamStarted;

        public ExamView()
        {
            InitializeComponent();

            SizeChanged += OnFormSizeChanges;
            StartButton.Click += OnButtonStartClick;
        }

        private void Action(Action action, ISynchronizeInvoke control)
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

        public void AddStudentToList(Student student)
        {
            Action(() => resultsListView.Items.Add(
                new ListViewItem(new[] {$"{student.TicketNumber}", student.Name, ""})), resultsListView);
        }

        public void ShowStudentMarkAndUpdateProgress(Student student)
        {
            Action(() =>
            {
                if (student == null || student.Mark < 2 || student.Mark > 5)
                {
                    throw new ArgumentOutOfRangeException();
                }
                foreach (ListViewItem item in resultsListView.Items)
                {
                    if ((item != null) && (item.SubItems[0].Text == student.TicketNumber.ToString()))
                    {
                        item.SubItems[2].Text = student.Mark.ToString();
                    }
                }
            }, resultsListView);
            Action(ProgressBarStep, examProgressBar);
        }

        public void FinishExam()
        {
            Action(() =>
            {
                UpdateStartButtonState(StartButtonSize.Next);
            }, StartButton);
            MessageBox.Show(Resource.ExamFinished);
        }

        private void ResetProgress() => SetProgressBarMaxValue(_studentsAmount);

        private void ProgressBarStep()
        {
            progressBarLabel.Text = $"{++_currentProgress}/{_studentsAmount}";
            examProgressBar.PerformStep();
        }

        public void SetProgressBarMaxValue(int max)
        {
            _currentProgress = 0;
            _studentsAmount = max;
            examProgressBar.Value = 0;
            examProgressBar.Maximum = _studentsAmount;
            progressBarLabel.Text = $"0/{max}";
        }

        private void OnFormSizeChanges(object sender, EventArgs e) => Action(AddColumnsListView, resultsListView);

        private void OnButtonStartClick(object sender, EventArgs e)
        {
            ResetProgress();
            UpdateStartButtonState(StartButtonSize.InProgress);
            examProgressBar.Value = 0;
            resultsListView.Items.Clear();
            resultsListView.Refresh();
            ExamStarted?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateStartButtonState(StartButtonSize size)
        {
            switch (size)
            {
                case StartButtonSize.First:
                    StartButton.Enabled = true;
                    StartButton.Text = Resource.StartButtonStartExam;
                    break;
                case StartButtonSize.InProgress:
                    StartButton.Enabled = false;
                    StartButton.Text = Resource.StartButtonExamInProgress;
                    break;
                case StartButtonSize.Next:
                    StartButton.Enabled = true;
                    StartButton.Text = Resource.StartNextExam;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(size), size, null);
            }
            StartButton.Width = (int) size;
            StartButton.Location = new Point((ClientSize.Width - StartButton.Width)/2, 333);
        }

        private void AddColumnsListView()
        {
            var width = resultsListView.Size.Width;
            var numWidth = width/100*25;
            var nameWidth = width/100*45;
            var markWidth = width/100*30;

            if (resultsListView.Columns.Count == 0)
            {
                resultsListView.Columns.Add(Resource.TicketNumber, numWidth, HorizontalAlignment.Center);
                resultsListView.Columns.Add(Resource.StudentName, nameWidth, HorizontalAlignment.Center);
                resultsListView.Columns.Add(Resource.Mark, markWidth, HorizontalAlignment.Center);
            }
            else
            {
                resultsListView.Columns[0].Width = numWidth;
                resultsListView.Columns[1].Width = nameWidth;
                resultsListView.Columns[2].Width = markWidth;
            }
            resultsListView.Refresh();
        }

    }
}
