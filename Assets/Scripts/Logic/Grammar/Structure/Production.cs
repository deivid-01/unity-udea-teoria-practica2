using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class Production 
{
   public  List <Element> rightSide = new List<Element>();
   public  Element leftSide;


    public Production () { }

    public Production ( List<Element> rightSide , Element lefhSide )
    {
        this.rightSide = rightSide;
        this.leftSide = lefhSide;
    }
}
