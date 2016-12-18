using System;
using System.Linq;

namespace God.Creatures
{
    public sealed class Book : IHasName
    {
        public string Name { get; }

        public Book(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            Name = name;
        }

        public override string ToString()
        {
            return $"{GetType().ToString().Split('.').Last()} {Name}";
        }
    }
}
