using System;
using FilmLibruary.Model;

namespace FilmLibruary.CustomEventArgs
{
    internal class SearchDescriptorEventArgs : EventArgs
    {
        public SearchDescriptor SearchDescriptor { get; private set; }

        public SearchDescriptorEventArgs(SearchDescriptor searchDescriptor)
        {
            SearchDescriptor = searchDescriptor;
        }
    }
}
