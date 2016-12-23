using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilmLibruary.Controller;
using FilmLibruary.CustomEventArgs;
using FilmLibruary.Model;
using FilmLibruary.Properties;
using FilmLibruary.Views.ViewEnums;

namespace FilmLibruary.Views
{
    internal partial class LibraryView : Form
    {
        private IFilmController _filmController;
        private FindFilmView _findFilmView = new FindFilmView();
        private readonly AboutView _aboutView = new AboutView();
        private readonly EditFilmView _editFilmView = new EditFilmView();
        private BindingList<FilmViewModel> _films = new BindingList<FilmViewModel>();

        private FilmViewModel _editedFilm;

        private ListSorter _sorter = new ListSorter();

        public LibraryView()
        {
            InitializeComponent();
            ChangeFormState(FilmLibruaryStates.DbNotOpen);
            FilmsGrid.AutoGenerateColumns = false;
            
            _findFilmView.SearchDescriptorCompleted += OnSearchDescriptorCompleted;
            _findFilmView.FormClosed += OnFindFormClosed;
            _editFilmView.EditFilmCompleted += OnEditFilmCompleted;
            _sorter.SortComplete += OnSortComplete;
        }

        private void OnExeptionHappened(object sender, EventArgs e)
        {
            Action(() =>
            {
                MessageBox.Show(Resources.CantOpenFile);
                ChangeFormState(FilmLibruaryStates.DbNotOpen);
            },this);
        }

        public void SetController(IFilmController controller)
        {
            _filmController = controller;
            _filmController.ExeptionHappened += OnExeptionHappened;
        }

        private void OpenDbClick(object sender, EventArgs e)
        {
            var openDbFileDialog = new OpenFileDialog
            {
                InitialDirectory = string.Empty,
                Filter = Resources.LibruaryViewOpenDbClickFileExtensions,
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openDbFileDialog.ShowDialog() != DialogResult.OK) return;
            
            ChangeFormState(FilmLibruaryStates.DbOpenStarted);
            var fileName = openDbFileDialog.FileName;

            _filmController.LoadComplete += OnFilmsLoaded;
            _filmController.StartFilmsLoad(fileName);
        }

        private void OnFilmsLoaded(object sender, EventArgs e)
        {
            Action(() =>
            { 
                _films = _filmController.GetFilmBindingList();
                FilmsGrid.DataSource = _films;
                ChangeFormState(FilmLibruaryStates.DbOpenEnded);
            }, this);
        }


        private void ExitClick(object sender, EventArgs e) => Close();

        private void EditFilmClick(object sender, EventArgs e)
        {
            var countSelectedRows = 0;
            DataGridViewRow selectedRow = null;
            foreach (var row in FilmsGrid.Rows.Cast<DataGridViewRow>().Where(row => row.Selected))
            {
                if (selectedRow == null)
                {
                    selectedRow = row;
                }
                countSelectedRows++;
            }

            if (countSelectedRows != 1)
            {
                MessageBox.Show(this, Resources.PleaseSelectOnlyOneRowForEdit);
            }
            else
            {
                var filmView = selectedRow?.DataBoundItem as FilmViewModel;
                if (filmView == null) return;
                _editedFilm = filmView;
                _editFilmView.EditedFilm = filmView;
                _editFilmView.ShowDialog(this);
            }
        }

        private void RemoveFilmsClick(object sender, EventArgs e)
        {
            var isRemoved = true;
            var countSelectedRows = 0;
            var idFilmsForDelete = new List<int>();
            var rowForRemove = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in FilmsGrid.Rows.Cast<DataGridViewRow>().Where(row => row.Selected))
            {
                rowForRemove.Add(row);
                var filmView = row.DataBoundItem as FilmViewModel;
                if (filmView == null) continue;
                idFilmsForDelete.Add(filmView.Id);
                countSelectedRows++;
                var filmName = filmView.Name;
                var mess = $"Do you want to remove '{filmName}'";
                if (MessageBox.Show(mess, Resources.RemoveFilms, MessageBoxButtons.YesNo) != DialogResult.No) continue;
                isRemoved = false;
                break;
            }

            if (isRemoved && (countSelectedRows > 0))
            {
                foreach (var row in rowForRemove)
                {
                    FilmsGrid.Rows.Remove(row);
                }
                _filmController.RemoveFilms(idFilmsForDelete);
            }
        }

        private void FindFilmClick(object sender, EventArgs e)
        {
            findFilmToolStripMenuItem.Checked = true;
            exitToolStripMenuItem.Enabled = false;

            ChangeFormState(FilmLibruaryStates.FindWindowOpen);

            if (_findFilmView.IsDisposed)
            {
                CreateFilmView();
            }
            if (_findFilmView.Visible)
            {
                _findFilmView.Hide();
            }
            _findFilmView.Show(this);
        }

        private void AboutClick(object sender, EventArgs e) => _aboutView.Show(this);

        private void LibruaryViewFormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Resources.DoYouWantToExit, Resources.FilmLibruary,
               MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void OnSearchDescriptorCompleted(object sender, EventArgs e)
        {
            var searchEventArgs = e as SearchDescriptorEventArgs;
            if (sender == null || searchEventArgs == null) return;

            ChangeFormState(FilmLibruaryStates.SearchStarted);
            _filmController.SearchComplete += OnSearchComplete;
            _filmController.StartFilmsSearch(searchEventArgs.SearchDescriptor);
        }

        private void OnSearchComplete(object sender, EventArgs e)
        {
            Action(() =>
            {
                _films = _filmController.GetFilmBindingList();
                FilmsGrid.DataSource = _films;
                ChangeFormState(FilmLibruaryStates.SearchEnded);
            }, this);
        }

        private void OnEditFilmCompleted(object sender, EventArgs e)
        {
            var searchEventArgs = e as FilmEditDescriptorEventArgs;
            if (sender == null || searchEventArgs == null) return;

            _editedFilm.Year = searchEventArgs.EditedFilm.Year;
            _editedFilm.Producer = searchEventArgs.EditedFilm.Producer;
            _editedFilm.Name = searchEventArgs.EditedFilm.Name;

            _filmController.EditFilm(searchEventArgs.EditedFilm);
        }

        private void OnFindFormClosed(object sender, EventArgs e)
        {
            ChangeFormState(FilmLibruaryStates.FindWindowClosed);
        }

        private void FilmsGridColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sender == null || e == null || _films == null)
            {
                return;
            }

            _sorter.SortList(_films, e.ColumnIndex);
        }

        private void OnSortComplete(object sender, EventArgs eventArgs)
        {
            Action(() =>
            {
                _films = _sorter.BindingList;
                FilmsGrid.DataSource = _films;
            }, this);
        }
        
        private void CreateFilmView()
        {
            _findFilmView = new FindFilmView();
            _findFilmView.FormClosed += OnFindFormClosed;
            _findFilmView.SearchDescriptorCompleted += OnSearchDescriptorCompleted;
        }

        private void ChangeFormState(FilmLibruaryStates state)
        {
            switch (state)
            {
                case FilmLibruaryStates.DbNotOpen:
                    FormStateLabel.Text = Resources.FilmDBNotOpen;
                    exitToolStripMenuItem.Enabled = true;
                    openDBToolStripMenuItem.Enabled = true;
                    editFilmToolStripMenuItem.Enabled = false;
                    removeFilmToolStripMenuItem.Enabled = false;
                    findFilmToolStripMenuItem.Enabled = false;
                    findFilmToolStripMenuItem.Checked = false;
                    aboutToolStripMenuItem.Enabled = true;
                    break;
                case FilmLibruaryStates.DbOpenStarted:
                    FormStateLabel.Text = Resources.OpeningFilmDB;
                    exitToolStripMenuItem.Enabled = true;
                    openDBToolStripMenuItem.Enabled = false;
                    editFilmToolStripMenuItem.Enabled = false;
                    removeFilmToolStripMenuItem.Enabled = false;
                    findFilmToolStripMenuItem.Enabled = false;
                    findFilmToolStripMenuItem.Checked = false;
                    aboutToolStripMenuItem.Enabled = true;
                    break;
                case FilmLibruaryStates.DbOpenEnded:
                    FormStateLabel.Text = String.Format("Film DB was opened! {0} films was founded", FilmsGrid.Rows.Count);
                    exitToolStripMenuItem.Enabled = true;
                    openDBToolStripMenuItem.Enabled = true;
                    editFilmToolStripMenuItem.Enabled = true;
                    removeFilmToolStripMenuItem.Enabled = true;
                    findFilmToolStripMenuItem.Enabled = true;
                    findFilmToolStripMenuItem.Checked = false;
                    aboutToolStripMenuItem.Enabled = true;
                    break;
                case FilmLibruaryStates.FindWindowOpen:
                    exitToolStripMenuItem.Enabled = false;
                    openDBToolStripMenuItem.Enabled = true;
                    editFilmToolStripMenuItem.Enabled = true;
                    removeFilmToolStripMenuItem.Enabled = true;
                    findFilmToolStripMenuItem.Enabled = true;
                    findFilmToolStripMenuItem.Checked = true;
                    aboutToolStripMenuItem.Enabled = true;
                    break;
                case FilmLibruaryStates.FindWindowClosed:
                    exitToolStripMenuItem.Enabled = true;
                    openDBToolStripMenuItem.Enabled = true;
                    editFilmToolStripMenuItem.Enabled = true;
                    removeFilmToolStripMenuItem.Enabled = true;
                    findFilmToolStripMenuItem.Enabled = true;
                    findFilmToolStripMenuItem.Checked = false;
                    aboutToolStripMenuItem.Enabled = true;
                    break;
                case FilmLibruaryStates.SearchStarted:
                    FormStateLabel.Text = Resources.SearchWasStarted;
                    exitToolStripMenuItem.Enabled = true;
                    openDBToolStripMenuItem.Enabled = false;
                    editFilmToolStripMenuItem.Enabled = false;
                    removeFilmToolStripMenuItem.Enabled = false;
                    findFilmToolStripMenuItem.Enabled = true;
                    findFilmToolStripMenuItem.Checked = true;
                    aboutToolStripMenuItem.Enabled = true;
                    break;
                case FilmLibruaryStates.SearchEnded:
                    FormStateLabel.Text = String.Format("Search was ended! {0} films was founded", FilmsGrid.Rows.Count);
                    exitToolStripMenuItem.Enabled = true;
                    openDBToolStripMenuItem.Enabled = true;
                    editFilmToolStripMenuItem.Enabled = true;
                    removeFilmToolStripMenuItem.Enabled = true;
                    findFilmToolStripMenuItem.Enabled = true;
                    findFilmToolStripMenuItem.Checked = true;
                    aboutToolStripMenuItem.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state", state, null);
            }
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

    }
}
