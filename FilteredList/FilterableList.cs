using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

namespace FilterableList
{
    /// <summary>
    /// A list which what enumerates only that elements,
    /// what satisy certain bool expression.
    /// 
    /// Enumerates all elements in list by default.
    /// </summary>
    /// <typeparam name="TItem">The type of objects in list</typeparam>
    class FilterableList<TItem> : IList<TItem>, INotifyCollectionChanged
    {
        private IList<TItem> filterableList;
        private Func<TItem, bool> filterFunc;

        public TItem this[int index] { get => filterableList[index]; set => filterableList[index] = value; }

        /// <summary>
        /// The function what used when filtering the collection.
        /// </summary>
        public Func<TItem, bool> FilterFunction
        {
            get { return filterFunc; }
            set
            {
                filterFunc = value;
                CollectionChanged?.Invoke(this,
                    new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace));
            }
        }

        public FilterableList(Func<TItem,bool> filterFunction = null)
        {
            this.filterableList = new List<TItem>();
            if (null == filterFunction)
            {
                filterFunc = t => true;
            }
            else
            {
                this.filterFunc = filterFunction;
            }
        }

        public int Count => filterableList.Count;

        public bool IsReadOnly => filterableList.IsReadOnly;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void Add(TItem item)
        {
            filterableList.Add(item);
            CollectionChanged.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }

        public void Clear()
        {
            filterableList.Clear();
            CollectionChanged.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(TItem item)
        {
            return filterableList.Contains(item);
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {
            filterableList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return (from item in filterableList
                    where true == filterFunc(item)
                    select item).GetEnumerator();
        }

        public int IndexOf(TItem item)
        {
            return filterableList.IndexOf(item);
        }

        public void Insert(int index, TItem item)
        {
            filterableList.Insert(index, item);
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }

        public bool Remove(TItem item)
        {
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            return filterableList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            CollectionChanged?.Invoke(this,
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            filterableList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
