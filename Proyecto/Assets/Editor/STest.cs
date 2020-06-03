using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
/// <summary>
/// Test for S grammar operations
/// </summary>
public class STest
{

    [Test]
    public void BelongTest ()
    {
        //ARRANGE: All preconditions and inputs
        GenericGrammar genericGrammar=new GenericGrammar();
        #region Define grammar1
        /*

        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();
        Production production5 = new Production();
        Production production6 = new Production();
        Production production7 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'A' , 1 );
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'A' , 2 );
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'B' , 3 );
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'B' , 4 );
        production5.leftSide = new Element ( Element.Kind.noTerminal , 'C' , 5 );
        production6.leftSide = new Element ( Element.Kind.noTerminal , 'C' , 6 );
        production7.leftSide = new Element ( Element.Kind.noTerminal , 'C' , 7 );




        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );

        production3.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production3.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );

        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production4.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );

        production6.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );
        production6.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );


        production7.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );


        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        genericGrammar.productions.Add ( production5 );
        genericGrammar.productions.Add ( production6 );
        genericGrammar.productions.Add ( production7 );
        */
        #endregion
        #region Define grammar 2
        
        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'C' );

        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production3.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production3.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );
        production3.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );

        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );

        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        
        #endregion
        #region Define grammar3
        /*

        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();
        Production production5 = new Production();
        Production production6 = new Production();
        Production production7 = new Production();
        Production production8 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'A' , 1 );
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'A' , 2 );
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'B' , 3 );
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'B' , 4 );
        production5.leftSide = new Element ( Element.Kind.noTerminal , 'D' , 5 );
        production6.leftSide = new Element ( Element.Kind.noTerminal , 'D' , 6 );
        production7.leftSide = new Element ( Element.Kind.noTerminal , 'E' , 7 );
        production8.leftSide = new Element ( Element.Kind.noTerminal , 'E' , 8 );



        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'E' ) );

        production3.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production3.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'A' ) );
        production3.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );

        production4.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );


        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );
        production5.rightSide.Add ( new Element ( Element.Kind.terminal , 'c' ) );

        production6.rightSide.Add ( new Element ( Element.Kind.nulo , '¬' ) );


        production7.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );

        production8.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );
        production8.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'D' ) );


        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );
        genericGrammar.productions.Add ( production5 );
        genericGrammar.productions.Add ( production6 );
        genericGrammar.productions.Add ( production7 );
        genericGrammar.productions.Add ( production8 );
        */
        #endregion


        //ACT on the method under test
        var result=S.Belong ( genericGrammar );

        //ASSERT occurrence of expected results

        Assert.That ( result , Is.EqualTo ( true ) );
    }
   [Test]
    public void ValidateRowTest ()
    {
        GenericGrammar genericGrammar = new GenericGrammar();

        #region Define grammar 2

        Production production1 = new Production();
        Production production2 = new Production();
        Production production3 = new Production();
        Production production4 = new Production();

        production1.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production2.leftSide = new Element ( Element.Kind.noTerminal , 'B' );
        production3.leftSide = new Element ( Element.Kind.noTerminal , 'C' );
        production4.leftSide = new Element ( Element.Kind.noTerminal , 'C' );

        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );
        production1.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );

        production2.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );
        production2.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'B' ) );

        production3.rightSide.Add ( new Element ( Element.Kind.terminal , 'b' ) );
        production3.rightSide.Add ( new Element ( Element.Kind.noTerminal , 'C' ) );
        production3.rightSide.Add ( new Element ( Element.Kind.terminal , 'd' ) );

        production4.rightSide.Add ( new Element ( Element.Kind.terminal , 'a' ) );

        genericGrammar.productions.Add ( production1 );
        genericGrammar.productions.Add ( production2 );
        genericGrammar.productions.Add ( production3 );
        genericGrammar.productions.Add ( production4 );

        #endregion
        string row="abbadd¬";

        S grammarS= new S(genericGrammar);
        var result= grammarS.ValidateRow ( row );

        Assert.That ( result , Is.EqualTo ( true ) );
    }
}
