using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
/// <summary>Productions class who contains  each element(rightside and leftside. Rightside are elements of terminals or no terminals. Leftside  is the no  terminal element)</summary>
public class Production 
{
    /// <summary>The right side</summary>
    public  List <Element> rightSide = new List<Element>();
    /// <summary>The left side</summary>
    public  Element leftSide;

    /// <summary>The initial</summary>
    public bool initial=false;

    /// <summary>Initializes a new instance of the <see cref="Production" /> class.</summary>
    public Production () { }

    /// <summary>Initializes a new instance of the <see cref="Production" /> class.</summary>
    /// <param name="rightSide">The right side.</param>
    /// <param name="lefhSide">The lefh side.</param>
    public Production ( List<Element> rightSide , Element lefhSide )
    {
        this.rightSide = rightSide;
        this.leftSide = lefhSide;
    }
}
