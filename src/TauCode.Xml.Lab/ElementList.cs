using System;
using System.Collections;
using System.Collections.Generic;

namespace TauCode.Xml.Lab
{
    internal class ElementList : IList<IElement>
    {
        #region Fields

        private readonly List<IElement> _elements;
        private readonly ComplexElement _parent;

        #endregion

        #region Constructor

        internal ElementList(ComplexElement parent)
        {
            _parent = parent;
            _elements = new List<IElement>();
        }

        #endregion

        #region Internal


        internal void Add(IElement element, bool check)
        {
            if (check)
            {
                throw new NotImplementedException();
            }

            _elements.Add(element);
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator() => _elements.GetEnumerator();

        #endregion

        #region IEnumerable<IElement> Members

        public IEnumerator<IElement> GetEnumerator() => _elements.GetEnumerator();

        #endregion

        #region ICollection<IElement> Members

        public int Count => _elements.Count;

        public bool IsReadOnly => false;

        public void Add(IElement element) => this.Add(element, true);

        public void Clear() => _elements.Clear();

        public bool Contains(IElement element) => _elements.Contains(element);

        public void CopyTo(IElement[] array, int arrayIndex) => _elements.CopyTo(array, arrayIndex);

        public bool Remove(IElement element) => _elements.Remove(element);

        #endregion

        #region IList<IElement> Members

        public IElement this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int IndexOf(IElement element) => _elements.IndexOf(element);

        public void Insert(int index, IElement element)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index) => _elements.RemoveAt(index);

        #endregion
    }
}
