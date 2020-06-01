using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element 
{
    public Kind kind;
    public char value;
    public int index;

    public Element ( Kind kind , char value )
    {
        this.kind = kind;
        this.value = value;
    }

    public Element ( Kind kind , char value , int index )
    {
        this.kind = kind;
        this.value = value;
        this.index = index;
    }

    public enum Kind { 
        terminal,
        noTerminal,
            nulo

    }

   
}
