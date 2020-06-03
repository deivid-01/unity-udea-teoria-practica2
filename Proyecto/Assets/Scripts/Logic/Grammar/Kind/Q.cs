using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  Kind of grammar Q
/// </summary>
public class Q
{
    /// <summary>The stack automat</summary>
    public Q_StackAutomat stackAutomat;
    /// <summary>The grammar</summary>
    public GenericGrammar grammar;

    /// <summary>Initializes a new instance of the <see cref="Q" /> class.</summary>
    /// <param name="grammar">The grammar.</param>
    public Q (GenericGrammar grammar)
    {
        this.grammar = grammar;
        //Cond
        stackAutomat = new Q_StackAutomat ( grammar );
    }
    /// <summary>Belongs the specified grammar.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns>true o false</returns>
    public static bool Belong ( GenericGrammar grammar ) => ( !FirstElementsAreTerminals ( grammar ) || 
                                                            !SameProductionDiffRightTerminal ( grammar ) || 
                                                            !IsDisjointSelectionSet ( grammar ) ) ? 
                                                            false : true;

    /// <summary>  Validates the row.</summary>
    /// <param name="inputRow">The input row.</param>
    /// <returns></returns>
    public bool ValidateRow ( string inputRow )
    {
        stackAutomat = new Q_StackAutomat ( grammar );


        foreach ( char input in inputRow )
        {
            if (! stackAutomat.Transition ( input ) )
            {
                return false;
            }
        }

        return true;
    }





    #region Utilities 
    /// <summary>Determines whether [is disjoint selection set] [the specified grammar].</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns>
    ///   <c>true</c> if [is disjoint selection set] [the specified grammar]; otherwise, <c>false</c>.</returns>
    public static bool IsDisjointSelectionSet ( GenericGrammar grammar )
    {
        List<Production>nameOfSameProductions=GetSameProductions(grammar);

        foreach ( Production nameOfProduction in nameOfSameProductions )
        {
            List<Production>sameProductions= GetProductionsOf(nameOfProduction.leftSide.value, grammar);

            if ( !IsDisjointProductions ( sameProductions,grammar ) )
                return false;
        }
        
        
        return true;
    }

    /// <summary>Determines whether [is disjoint productions] [the specified same productions].</summary>
    /// <param name="sameProductions">The same productions.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns>
    ///   <c>true</c> if [is disjoint productions] [the specified same productions]; otherwise, <c>false</c>.</returns>
    private static bool IsDisjointProductions ( List<Production> sameProductions, GenericGrammar grammar )
    {

        for ( int i = 0 ;i < sameProductions.Count ;i++ )
        {
            List<char>selectionSet=GrammarTools.GetSeleccionSetOfProduction(new List<char>(), sameProductions[i].leftSide.index,grammar);

            for ( int j = 0 ;j < sameProductions.Count ;j++ )
            {
                if ( i != j )
                {
                    List<char>selectionSetToCompare=GrammarTools.GetSeleccionSetOfProduction(new List<char>(),sameProductions[j].leftSide.index,grammar);

                    if ( ListAreEqual ( selectionSet , selectionSetToCompare )){
                        return false;
                    }
                    
                }
            }
        }

        return true;

           
        
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
    /// <summary>Firsts the elements are terminals.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static bool FirstElementsAreTerminals ( GenericGrammar grammar )
    {
        foreach ( Production production in grammar.productions )
        {
            if ( ( production.rightSide [0].kind == Element.Kind.noTerminal )  )
            {
                return false;
            }
        }

        return true;
    }


    /// <summary>Sames the production difference right terminal.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static bool SameProductionDiffRightTerminal ( GenericGrammar grammar ) => ( CompareRightFirstTerminal ( GetSameProductions ( grammar ).ToArray () ) ) ? true : false;


    /// <summary>Compares the right first terminal.</summary>
    /// <param name="sameProd">The same product.</param>
    /// <returns></returns>
    public static bool CompareRightFirstTerminal ( Production [] sameProd )
    {
        for ( int i = 0 ;i < sameProd.Length ;i++ )
        {
            for ( int j = 0 ;j < sameProd.Length ;j++ )
            {
                if ( i != j )
                {
                    if ( sameProd [i].leftSide.value.Equals ( sameProd [j].leftSide.value ) && sameProd [i].rightSide [0].value.Equals ( sameProd [j].rightSide [0].value ) )
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
    /// <returns>List of same productions</returns>
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
                        if(!ListContains(sameProductions,grammar.productions[i]))
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


    /// <summary>Gets the productions of.</summary>
    /// <param name="name">The name.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Production> GetProductionsOf ( char name , GenericGrammar grammar) {
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

    #endregion
}
