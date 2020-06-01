using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set
{

    public int index;
    public char name;
    public List<char>values=new List<char>();
    public Kind kind;
    public Set () { 
    
    }
    public Set ( char name  , Kind kind )
    {
        this.name = name;
     
        this.kind = kind;
    }

    public Set ( int index , char name,Kind kind )
    {
        this.index = index;
        this.name = name;
        this.kind = kind;
    }

    public Set ( int index , List<char> values , Kind kind )
    {
        this.index = index;
        this.values = values;
        this.kind = kind;
    }


    public Set ( char name , List<char> values , Kind kind )
    {
        this.name = name;
        this.values = values;
        this.kind = kind;
    }

    public enum Kind
    {
        first,
        next,
        selection
    }
}
