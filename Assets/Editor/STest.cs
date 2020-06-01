using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class STest
{

    [Test]
    public void IdentifyTest ()
    {
        //ARRANGE: All preconditions and inputs
        GenericGrammar genericGrammar=new GenericGrammar();

        #region Define grammar

        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );

        production2.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production3.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production3.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production3.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );
        production3.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );

        production4.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );

        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        #endregion
        //ACT on the method under test
        var result=S.Belong ( genericGrammar );

        //ASSERT occurrence of expected results

        Assert.That ( result , Is.EqualTo ( true ) );
    }

}
