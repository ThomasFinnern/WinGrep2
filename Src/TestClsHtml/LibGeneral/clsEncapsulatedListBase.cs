using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageManager
{
    /// <summary>
    /// Contans a list where single items may be taken/added/deleted .
    /// The access is strictly by index with checking for range of already added items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class clsEncapsulatedListBase <T> where T : ICloneable, new()
    {
        private List<T> Items = null;

        public clsEncapsulatedListBase()
        {
            Items = new List<T>();
        }

        public clsEncapsulatedListBase(List <T> NewArray)
        {
            Items = new List<T>();
            Items.AddRange(NewArray);
        }

        public clsEncapsulatedListBase <T> Clone()
        { 
            // return new clsEncapsulatedListBase <T> (Array); 
            /*
            clsEncapsulatedListBase<T> IsCopy = new clsEncapsulatedListBase<T>();
            foreach (T Item in Items)
            {
                IsCopy.Add((T) Item.Clone ());
            }

            return IsCopy;        
            */
        
            List<T> newList = new List<T>(Items);
            return new clsEncapsulatedListBase<T>(newList);
        }

        public T this[int Idx]
        {
            get 
            {
                //T Element = new T();
                T Element = default(T);
                if (Items.Count > Idx)
                    Element = Items[Idx];
                return Element;
            }
        
            set 
            {
                if (Items.Count > Idx)
                {
                    Items[Idx] = value;
                }
                else
                {
                    // a element will be added if the index points to last element + 1

                    if (Items.Count == Idx)
                    {
                        Items.Add(value);
                    }
                    else
                    { 
                    //todo: thro exception invalid range
                    
                    
                    }
                }

            }
        }

        void Add (T NewElement)
        {
             Items.Add(NewElement);
        }

        void Add (IEnumerable <T> NewElements)
        {
             Items.AddRange(NewElements);
        }

        void Remove(T DelElement)
        {
             Items.Remove (DelElement);
        }

        void RemoveAt(int Idx)
        {
             Items.RemoveAt (Idx);
        }
         
        // IEnumerable <T> t
        // ToDo: Implement Iterator
    }
}
