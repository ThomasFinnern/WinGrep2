using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;

namespace NetGrep
{
    /// <summary>
    /// Should keep an enumartor over lines. They may come from a file or a List<string>
    /// </summary>
    public class clsLineIEnumerable
    {
        IEnumerator<string> mLines;
        public IEnumerator<string> Lines
        {
            get { return mLines; }
            set { mLines = value; }
        }

        clsLineIEnumerable()
        {

        }

        clsLineIEnumerable(IEnumerator<string> InLines)
        {
            mLines = InLines;
        }
    }

    /*
    public class clsLineIEnumerable : IEnumerable
    {
        clsLineIEnumerable()
        {

        }

        public IEnumerator GetEnumerator()
        {
            return new clsLineIEnumerator(this);
        }

        // Inner class implements IEnumerator interface:
        private class clsLineIEnumerator : IEnumerator
        {
            private int position = -1;
            private clsLineIEnumerable t;

            public clsLineIEnumerator(clsLineIEnumerable t)
            {
                this.t = t;
            }

            // Declare the MoveNext method required by IEnumerator:
            public bool MoveNext()
            {
                //if (position < t.elements.Length - 1)
                //{
                //    position++;
                //    return true;
                //}
                //else
                {
                    return false;
                }
            }

            // Declare the Reset method required by IEnumerator:
            public void Reset()
            {
                position = -1;
            }

            // Declare the Current property required by IEnumerator:
            public object Current
            {
                get
                {
                    return ""; // t.elements[position];
                }
            }
        }

        /*
        IEnumerator<string> mLines;
        public IEnumerator<string> Lines
        {
            get {return mLines;}
            set {mLines = value;}
        }
        * /
    }
     */
}
