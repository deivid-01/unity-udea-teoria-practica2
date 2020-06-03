using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Element is terminal or no terminal
/// </summary>
public class Element 
{
    /// <summary>The kind</summary>
    public Kind kind;
    /// <summary>The value</summary>
    public char value;
    /// <summary>The index</summary>
    public int index;

    /// <summary>Initializes a new instance of the <see cref="Element" /> class.</summary>
    /// <param name="kind">The kind.</param>
    /// <param name="value">The value.</param>
    public Element ( Kind kind , char value )
    {
        this.kind = kind;
        this.value = value;
    }

    /// <summary>Initializes a new instance of the <see cref="Element" /> class.</summary>
    /// <param name="kind">The kind.</param>
    /// <param name="value">The value.</param>
    /// <param name="index">The index.</param>
    public Element ( Kind kind , char value , int index )
    {
        this.kind = kind;
        this.value = value;
        this.index = index;
    }

    /// <summary><para>Kind of element</para></para></summary>
    public enum Kind { 
        terminal,
        noTerminal,
            nulo

    }

   
}
