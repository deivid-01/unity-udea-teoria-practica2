using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>root grammar who contains each production</summary>
public class GenericGrammar 
{
    /// <summary>The productions</summary>
    public List<Production>productions= new List<Production>();

    /// <summary>Initializes a new instance of the <see cref="GenericGrammar" /> class.</summary>
    public GenericGrammar () { 
    
    }

    /// <summary>Initializes a new instance of the <see cref="GenericGrammar" /> class.</summary>
    /// <param name="productions">The productions.</param>
    public GenericGrammar ( List<Production> productions )
    {
        this.productions = productions;
    }
}
