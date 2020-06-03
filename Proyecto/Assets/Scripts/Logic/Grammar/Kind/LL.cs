using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>Kind of grammar LL(1)</summary>
public class LL
{
    /// <summary>The stack automat</summary>
    public LL_StackAutomat stackAutomat;
    /// <summary>The grammar</summary>
    public GenericGrammar grammar;
    /// <summary>Initializes a new instance of the <see cref="LL" /> class.</summary>
    /// <param name="grammar">The grammar.</param>
    public LL (GenericGrammar grammar)
    {
        this.grammar = grammar;
        
        stackAutomat = new LL_StackAutomat ( grammar );
    }

    /// <summary>Belongs the specified grammar.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static bool Belong ( GenericGrammar grammar ) => (!CheckRightSide(grammar) || !IsDisjointSelectionSet ( grammar ) ) ? false : true;



    /// <summary>Validates the row.</summary>
    /// <param name="inputRow">The input row.</param>
    /// <returns></returns>
    public bool ValidateRow ( string inputRow )
    {
        stackAutomat = new LL_StackAutomat ( grammar );


        foreach ( char input in inputRow )
        {
            if ( !stackAutomat.Transition ( input ) )
            {
                return false;
            }
        }

        return true;
    }



    /// <summary>Checks the right side.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static bool CheckRightSide ( GenericGrammar grammar )
    {

        List<Production>nameOfSameProductions=GetSameProductions(grammar);
        foreach ( Production nameOfProduction in nameOfSameProductions )
        {
            List<Production>sameProductions= GetProductions(nameOfProduction.leftSide.value, grammar);

            if ( !VerificationRightSide ( sameProductions , grammar ) )
                return false;
        }

        return true;

    }

    /// <summary>Verifications the right side.</summary>
    /// <param name="sameProductions">The same productions.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    private static bool VerificationRightSide ( List<Production> sameProductions , GenericGrammar grammar )
    {
        for ( int i = 0 ;i < sameProductions.Count ;i++ )
        {
            Production production = ( Production ) grammar.productions [i];
            if ( production.rightSide [0].kind.Equals ( Element.Kind.terminal ) )
            {
                for ( int j = 0 ;j < sameProductions.Count ;j++ )
                {
                Production production2 = ( Production ) grammar.productions [j];

                    if ( i != j )
                    {
                        if ( production2.rightSide [0].kind.Equals ( Element.Kind.terminal ) )
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

    //Build grammmar




    /// <summary>Determines whether [is disjoint selection set] [the specified grammar].</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns>
    ///   <c>true</c> if [is disjoint selection set] [the specified grammar]; otherwise, <c>false</c>.</returns>
    public static bool IsDisjointSelectionSet ( GenericGrammar grammar )
    {
        List<Production>nameOfSameProductions=GetSameProductions(grammar);

        foreach ( Production nameOfProduction in nameOfSameProductions )
        {
            List<Production>sameProductions= GetProductions(nameOfProduction.leftSide.value, grammar);

            if ( !IsDisjointProductions ( sameProductions , grammar ) )
                return false;
        }


        return true;
    }

    /// <summary>Determines whether [is disjoint productions] [the specified same productions].</summary>
    /// <param name="sameProductions">The same productions.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns>
    ///   <c>true</c> if [is disjoint productions] [the specified same productions]; otherwise, <c>false</c>.</returns>
    private static bool IsDisjointProductions ( List<Production> sameProductions , GenericGrammar grammar )
    {

        for ( int i = 0 ;i < sameProductions.Count ;i++ )
        {
            List<char>selectionSet=GrammarTools.GetSeleccionSetOfProduction(new List<char>(), sameProductions[i].leftSide.index,grammar);

            for ( int j = 0 ;j < sameProductions.Count ;j++ )
            {
                if ( i != j )
                {
                    List<char>selectionSetToCompare=GrammarTools.GetSeleccionSetOfProduction(new List<char>(),sameProductions[j].leftSide.index,grammar);

                    if ( ListAreEqual ( selectionSet , selectionSetToCompare ) )
                    {
                        return false;
                    }

                }
            }
        }

        return true;

    }

    /// <summary>Gets the same productions.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
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
                        if ( !ListContains ( sameProductions , grammar.productions [i] ) )
                        {
                            sameProductions.Add ( grammar.productions [i] );
                        }

                        if ( !ListContains ( sameProductions , grammar.productions [j] ) )

                        {
                            sameProductions.Add ( grammar.productions [j] );
                        }
                    }
                }
            }
        }

        return sameProductions;
    }

    /// <summary>Lists the contains.</summary>
    /// <param name="productions">The productions.</param>
    /// <param name="production">The production.</param>
    /// <returns></returns>
    public static bool ListContains ( List<Production> productions , Production production )
    {
        foreach ( Production pro in productions )
        {
            if ( pro.leftSide.value.Equals ( production.leftSide.value ) )
            {
                return true;
            }
        }

        return false;
    }


    /// <summary>Gets the productions.</summary>
    /// <param name="name">The name.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Production> GetProductions ( char name , GenericGrammar grammar )
    {
        List<Production>productions=new List<Production>();

        foreach ( Production production in grammar.productions )
        {
            if ( production.leftSide.value.Equals ( name ) )
            {
                productions.Add ( production );
            }
        }


        return productions;
    }

    /// <summary>Lists the are equal.</summary>
    /// <param name="selectionSet">The selection set.</param>
    /// <param name="selectionSetToCompare">The selection set to compare.</param>
    /// <returns></returns>
    private static bool ListAreEqual ( List<char> selectionSet , List<char> selectionSetToCompare )
    {

        foreach ( char value in selectionSetToCompare )
        {
            if ( !( selectionSet.Contains ( value ) ) )
            {
                return false;
            }
        }


        return true;
    }



}
