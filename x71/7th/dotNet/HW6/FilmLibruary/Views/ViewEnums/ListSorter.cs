using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using FilmLibruary.Model;

namespace FilmLibruary.Views.ViewEnums
{
    public class ListSorter
    {
        public BindingList<FilmViewModel> BindingList;
        public event EventHandler SortComplete;
        private SortType _yearSort = SortType.Ascending;
        private SortType _nameSort = SortType.Ascending;
        private SortType _countrySort = SortType.Ascending;

        public ListSorter()
        {

        }

        public void SortList(BindingList<FilmViewModel> _films, int columnIndex)
        {
            new Task(() =>
            {
                switch ((FilmViewFields) columnIndex)
                {
                    case FilmViewFields.Name:
                        if (_nameSort == SortType.Ascending)
                        {
                            BindingList = new BindingList<FilmViewModel>(_films.OrderByDescending(f => f.Name).ToList());
                            _nameSort = SortType.Descending;
                        }
                        else
                        {
                            BindingList = new BindingList<FilmViewModel>(_films.OrderBy(f => f.Name).ToList());
                            _nameSort = SortType.Ascending;
                        }
                        break;
                    case FilmViewFields.Year:
                        if (_yearSort == SortType.Ascending)
                        {
                            BindingList = new BindingList<FilmViewModel>(_films.OrderByDescending(f => f.Year).ToList());
                            _yearSort = SortType.Descending;
                        }
                        else
                        {
                            BindingList = new BindingList<FilmViewModel>(_films.OrderBy(f => f.Year).ToList());
                            _yearSort = SortType.Ascending;
                        }
                        break;
                    case FilmViewFields.Country:
                        if (_countrySort == SortType.Ascending)
                        {
                            BindingList = new BindingList<FilmViewModel>(_films.OrderByDescending(f => f.Country).ToList());
                            _countrySort = SortType.Descending;
                        }
                        else
                        {
                            BindingList = new BindingList<FilmViewModel>(_films.OrderBy(f => f.Country).ToList());
                            _countrySort = SortType.Ascending;
                        }
                        break;
                }

                SortComplete?.Invoke(this, EventArgs.Empty);
            }).Start();
        }
    }
}