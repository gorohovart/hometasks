using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using God.Atributes;
using God.Creatures;

namespace God.Enumerators
{
    internal sealed class CoupleAttributeEnumerator : IEnumerator<CoupleAttribute>, IEnumerable<CoupleAttribute>
    {
        private readonly CoupleAttribute[] _attributes;
        private int _index = -1;
        public IEnumerator<CoupleAttribute> GetEnumerator()
          => this;
        object IEnumerator.Current
          => Current;
        IEnumerator IEnumerable.GetEnumerator()
          => this;
        public CoupleAttribute Current
          => _attributes[_index];

        public CoupleAttributeEnumerator(Human human)
        {
            if (human == null)
                throw new ArgumentNullException();

            _attributes = (CoupleAttribute[])Attribute.GetCustomAttributes(human.GetType(), typeof(CoupleAttribute));
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_index == _attributes.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
          => _index = -1;
    }
}
