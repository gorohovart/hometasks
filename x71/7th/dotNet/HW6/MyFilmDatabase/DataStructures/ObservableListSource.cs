using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Data.Entity;
using System.Linq;
using MyFilmDatabase.Models;

namespace MyFilmDatabase.DataStructures
{
    public sealed class ObservableListSource<T> : ObservableCollection<T>, IListSource
        where T : class
    {
        private IBindingList _bindingList;

        bool IListSource.ContainsListCollection { get { return false; } }

        IList IListSource.GetList()
        {
            return _bindingList ?? (_bindingList = this.ToBindingList());
        }

        public ObservableListSource<T> GetRange(int p0, int p1)
        {
            var result = new ObservableListSource<T>();
            for (int i = p0; i < p0 + p1; i++)
            {
                result.Add(this[i]);
            }
            return result;
        }
    }
}