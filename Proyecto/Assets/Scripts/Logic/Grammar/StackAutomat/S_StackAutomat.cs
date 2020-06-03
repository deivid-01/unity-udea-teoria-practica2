using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Stack automat for S grammar
/// </summary>
public class S_StackAutomat 
{
    /// <summary>The stack</summary>
    Stack stack;
    /// <summary>The null symbol</summary>
    const char nullSymbol = '|';
    /// <summary>The grammar</summary>
    GenericGrammar grammar;

    /// <summary>Initializes a new instance of the <see cref="S_StackAutomat" /> class.</summary>
    /// <param name="grammar">The grammar.</param>
    public S_StackAutomat (GenericGrammar grammar) {

        this.grammar = grammar;

        stack = InitialConfiguration (grammar);
    }

    /// <summary>Initials the configuration.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public Stack InitialConfiguration (GenericGrammar grammar) {

        stack = new Stack ();
        stack.Push ( nullSymbol );
        stack.Push (grammar.productions[0].leftSide  );

        return stack;
    }


    /// <summary>Transitions the specified x.</summary>
    /// <param name="x">The x.</param>
    /// <returns></returns>
    public bool Transition ( char x ) {

        if ( IsPeek ( Element.Kind.noTerminal ) )
        {
            if ( !CheckProductionOf ( x ) )
            {
                return false;
            }
            
        }
        else if ( IsPeek ( Element.Kind.terminal ) )
        {
            if ( IsPeekEqualsTo ( x ) )
            {
                stack.Pop ();

            }
            else
            {
                return false;
            }
        }
        else if ( IsPeekNulSymbol () && x.Equals ( '¬' ) )
        {
            //GamEvent.instance.AcceptRow
            Debug.Log ( "Accept Row" );
        }
        else
        {
            Debug.Log ( "Reject Row" );

            //GamEvent.instance.RejectRow
            return false;

        }

        return true;

    }

    /// <summary>Checks the production of.</summary>
    /// <param name="x">The x.</param>
    /// <returns></returns>
    public bool CheckProductionOf ( char x )
    {
       
        List<Production>productions= GrammarTools.GetProductionsOf ( ( ( Element ) stack.Peek () ).value , grammar );
        
        if ( productions.Count == 0 )
        {
            //GamEvent.instance.RejectRow
            return false;
        }

        Production productioToCheck=GrammarTools.GetProductionWithValue(x,productions);
        if ( productioToCheck is null )
        {
            //GamEvent.instance.RejectRow
            return false;
        }

        else if ( productioToCheck.rightSide.Count == 1 )
        {
            stack.Pop ();
           
        }

        else
        {
            stack.Pop ();
            for ( int i = productioToCheck.rightSide.Count - 1 ;i >= 1 ;i-- )
            {
                stack.Push ( productioToCheck.rightSide [i] );
            }

            
        }
        return true;

    }


    /// <summary>Determines whether [is peek equals to] [the specified x].</summary>
    /// <param name="x">The x.</param>
    /// <returns>
    ///   <c>true</c> if [is peek equals to] [the specified x]; otherwise, <c>false</c>.</returns>
    public bool IsPeekEqualsTo ( char x ) => ( ( ( Element ) stack.Peek () ).value.Equals ( x ) ) ? true : false;



    /// <summary>Determines whether [is peek nul symbol].</summary>
    /// <returns>
    ///   <c>true</c> if [is peek nul symbol]; otherwise, <c>false</c>.</returns>
    public bool IsPeekNulSymbol ( ) => ( stack.Peek () is char) ? true : false;


    /// <summary>Determines whether the specified kind is peek.</summary>
    /// <param name="kind">The kind.</param>
    /// <returns>
    ///   <c>true</c> if the specified kind is peek; otherwise, <c>false</c>.</returns>
    public bool IsPeek ( Element.Kind kind  ) {

        if ( stack.Peek () is Element )
        {
            if ( ( ( Element ) stack.Peek () ).kind.Equals ( kind ) )
            {
                return true;
            }
            return false;
        }
        return false;
    }
}
