using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


class CircularMenuHandler
{
    public Text[] menuItems;

    CircularIterator current;
    Color colorCurr;
    Color colorOthers;


    public CircularMenuHandler(Text[] items, Color curr, Color others)
    {
        menuItems = items;
        current = new CircularIterator(menuItems);
        colorCurr = curr;
        colorOthers = others;

        SetCurrentCol(current.get());

        CircularIterator copy = new CircularIterator(current);
        ++copy;

        for (int i = 1; i < menuItems.Length; ++i, ++copy)
        {
            SetOthersCol(copy.get());
        }
    }


    void SetCurrentCol(Text txt)
    {
        txt.color = colorCurr;
    }


    void SetOthersCol(Text txt)
    {
        txt.color = colorOthers;
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
        SetOthersCol(current.get());
        ++current;
        SetCurrentCol(current.get());
    }


    public void HighlightPrev()
    {
        SetOthersCol(current.get());
        --current;
        SetCurrentCol(current.get());
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
        

        static public CircularIterator operator++(CircularIterator it)
        {
            ++it.index;
            it.index %= it.size;
            return it;
        }


        static public CircularIterator operator--(CircularIterator it)
        {
            --it.index;
            it.index = (it.index + it.size) % it.size;
            return it;
        }


        public Text get()
        {
            return array[index];
        }
    }
}

