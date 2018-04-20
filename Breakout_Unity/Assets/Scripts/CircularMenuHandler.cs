using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace MenuHandlers
{
    delegate void SetItemCB(Text txt);

    class CircularMenuHandler
    {
        public Text[] menuItems;

        CircularIterator current;

        SetItemCB SetSelected;
        SetItemCB SetDeselected;


        public CircularMenuHandler(Text[] items, Color curr, Color others)
        {
            menuItems = items;
            current = new CircularIterator(menuItems);


            SetSelected = x => { x.color = curr; };
            SetDeselected = x => { x.color = others; };

            SetSelected(current.get());

            CircularIterator copy = new CircularIterator(current);
            ++copy;

            for (int i = 1; i < menuItems.Length; ++i, ++copy)
            {
                SetDeselected(copy.get());
            }
        }


        public CircularMenuHandler(Text[] items, SetItemCB curr, SetItemCB others)
        {
            menuItems = items;
            current = new CircularIterator(menuItems);
            SetSelected = curr;
            SetDeselected = others;

            SetSelected(current.get());

            CircularIterator copy = new CircularIterator(current);
            ++copy;

            for (int i = 1; i < menuItems.Length; ++i, ++copy)
            {
                SetDeselected(copy.get());
            }
        }


        public CircularIterator Next()
        {
            return ++current;
        }


        public CircularIterator Prev()
        {
            return --current;
        }


        public void HighlightNext()
        {
            SetDeselected(current.get());
            ++current;
            SetSelected(current.get());
        }


        public void HighlightPrev()
        {
            SetDeselected(current.get());
            --current;
            SetSelected(current.get());
        }


        public int CurrentIndex() { return current.Index; }


        public class CircularIterator
        {
            int size;
            int index = 0;

            public int Index
            {
                get { return index; }
                private set { }
            }

            Text[] array;


            public CircularIterator(Text[] data)
            {
                size = data.Length;
                array = data;
            }


            public CircularIterator(CircularIterator other)
            {
                array = other.array;
                size = other.size;
                index = other.index;
            }


            static public CircularIterator operator ++(CircularIterator it)
            {
                ++it.index;
                it.index %= it.size;
                return it;
            }


            static public CircularIterator operator --(CircularIterator it)
            {
                --it.index;
                it.index = (it.index + it.size) % it.size;
                return it;
            }


            public Text get()
            {
				// Debug.Log ("INDEX: " + index);
                return array[index];
            }
        }
    }

}