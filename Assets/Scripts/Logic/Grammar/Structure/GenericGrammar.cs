using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericGrammar 
{
    public List<Production>productions= new List<Production>();

    public GenericGrammar () { 
    
    }
    
    public GenericGrammar ( List<Production> productions )
    {
        this.productions = productions;
    }
}
