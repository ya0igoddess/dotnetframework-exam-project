using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FarmView
{
    public static class GenericCollectionExtension
    {
       public static void AddAll<T>(this ObservableCollection<T> startingCollection, 
                                    IEnumerable<T> addingCollection)
        {
            foreach(T element in addingCollection)
            {
                startingCollection.Add(element);
            }
        }
    }
}
