using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
/// <summary>
/// Kind of grammar S
/// </summary>
public class S
{
    /// <summary>The stack automat</summary>
    public  S_StackAutomat stackAutomat;
    /// <summary>The grammar</summary>
    public GenericGrammar grammar;

    /// <summary>Initializes a new instance of the <see cref="S" /> class.</summary>
    /// <param name="grammar">The grammar.</param>
    public S (GenericGrammar grammar)
    {
        this.grammar = grammar;
        
        stackAutomat = new S_StackAutomat (grammar);

    }
    /// <summary>Belongs the specified grammar.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns><para>true o false if the gramar belong to that grammar</para></para></returns>
    public static bool Belong ( GenericGrammar grammar ) => ( !FirstElementsAreTerminals ( grammar ) ||
                                                            !SameProductionDiffRightTerminal ( grammar ) ) 
                                                             ? false : true;

    /// <summary>Validates the row.</summary>
    /// <param name="inputRow">The input row.</param>
    /// <returns></returns>
    public bool ValidateRow ( string inputRow )
    {
        stackAutomat = new S_StackAutomat (grammar);

        foreach ( char input in inputRow )
        {
            if ( !stackAutomat.Transition ( input ) )
            {
                return false;
            }

        }

        return true;


    }



    #region Utilities methods
    /// <summary>Sames the production difference right terminal.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static bool SameProductionDiffRightTerminal ( GenericGrammar grammar ) => ( CompareRightFirstTerminal ( GetSameProductions ( grammar ).ToArray () ) ) ? true : false;

    public static bool CompareRightFirstTerminal ( Production [] sameProd ) {
        for ( int i = 0 ;i < sameProd.Length ;i++ )
        {
            for ( int j = 0 ;j < sameProd.Length ;j++ )
            {
                if ( i != j )
                {
                    if ( sameProd[i].leftSide.value.Equals(sameProd[j].leftSide.value) && sameProd [i].rightSide [0].value.Equals ( sameProd [j].rightSide [0].value ) )
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    /// <summary>Firsts the elements are terminals.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns><para>true o false</para></para></returns>
    public static bool FirstElementsAreTerminals ( GenericGrammar grammar )
    {
        
        
        foreach ( Production production in grammar.productions )
        {
            if ( ( production.rightSide [0].kind == Element.Kind.noTerminal ) || ( production.rightSide [0].kind == Element.Kind.nulo ) )
            {
                return false;
            }
        }

        return true;
    }
    /// <summary>Gets the same productions.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns>List of productions</returns>
    public static List<Production> GetSameProductions ( GenericGrammar grammar )
    {

        List<Production>sameProductions= new List<Production>();
        for ( int i = 0 ;i < grammar.productions.Count ;i++ )
        {
            for ( int j = 0 ;j < grammar.productions.Count ;j++ )
            {
                if ( i != j )
                {

                    if ( grammar.productions [i].leftSide.value.Equals ( grammar.productions [j].leftSide.value ) )
                    {
                        if ( !sameProductions.Contains ( grammar.productions [i] ) )
                        {
                            sameProductions.Add ( grammar.productions [i] );
                        }

                        if ( !sameProductions.Contains ( grammar.productions [j] ) )
                        {
                            sameProductions.Add ( grammar.productions [j] );
                        }
                    }
                }
            }
        }

        return sameProductions;
    }
    #endregion

}
