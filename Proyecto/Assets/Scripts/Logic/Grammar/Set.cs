using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Set of next, firt, selection
/// </summary>
public class Set
{

    /// <summary>The index</summary>
    public int index;
    /// <summary>The name</summary>
    public char name;
    /// <summary>The values</summary>
    public List<char>values=new List<char>();
    /// <summary>The kind</summary>
    public Kind kind;
    /// <summary>Initializes a new instance of the <see cref="Set" /> class.</summary>
    public Set () { 
    
    }
    /// <summary>Initializes a new instance of the <see cref="Set" /> class.</summary>
    /// <param name="name">The name.</param>
    /// <param name="kind">The kind.</param>
    public Set ( char name  , Kind kind )
    {
        this.name = name;
     
        this.kind = kind;
    }

    /// <summary>Initializes a new instance of the <see cref="Set" /> class.</summary>
    /// <param name="index">The index.</param>
    /// <param name="name">The name.</param>
    /// <param name="kind">The kind.</param>
    public Set ( int index , char name,Kind kind )
    {
        this.index = index;
        this.name = name;
        this.kind = kind;
    }

    /// <summary>Initializes a new instance of the <see cref="Set" /> class.</summary>
    /// <param name="index">The index.</param>
    /// <param name="values">The values.</param>
    /// <param name="kind">The kind.</param>
    public Set ( int index , List<char> values , Kind kind )
    {
        this.index = index;
        this.values = values;
        this.kind = kind;
    }


    /// <summary>Initializes a new instance of the <see cref="Set" /> class.</summary>
    /// <param name="name">The name.</param>
    /// <param name="values">The values.</param>
    /// <param name="kind">The kind.</param>
    public Set ( char name , List<char> values , Kind kind )
    {
        this.name = name;
        this.values = values;
        this.kind = kind;
    }

    /// <summary><para>Kind of set</para></para></summary>
    public enum Kind
    {
        first,
        next,
        selection
    }
}
