using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
/// <summary>
/// Methods for grammar operations
/// </summary>
public class GrammarTools
{
    // Start is called before the first frame update
    #region Main methods
    /// <summary>Gets the anullable no terminals.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Element> GetAnullableNoTerminals ( GenericGrammar grammar )
    {

        List<Element>nAnullables=new List<Element>();

        foreach ( var production in grammar.productions )
        {
            if ( IsAnullableProduction ( production , grammar ) )
            {
                nAnullables.Add ( production.leftSide );
            }
        }

        return nAnullables;
    }



    /// <summary>Gets the annullable productions.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<int> GetAnnullableProductions ( GenericGrammar grammar )
    {
        List<int>anullableProductionsIndex=new List<int>();

        for ( int i = 0 ;i < grammar.productions.Count ;i++ )
        {
            if ( IsAnullableProduction ( grammar.productions [i] , grammar ) )
            {
                anullableProductionsIndex.Add ( i + 1 );
            }
        }
        return anullableProductionsIndex;
    }

    /// <summary>Gets the first no terminals.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Set> GetFirstNoTerminals ( GenericGrammar grammar )
    {
        List <Set> setFirstNoTerminals = GetSetOfNoTerminals ( grammar );

        foreach ( Set set in setFirstNoTerminals )
        {
            set.values.AddRange ( GetFirstOfNoTerminal ( new List<char> () , set.name , grammar ) );
        }

        return setFirstNoTerminals;
    }

    /// <summary>Gets the first producctions.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Set> GetFirstProducctions ( GenericGrammar grammar )
    {
        List<Set>setFirstProducction = new List<Set>();
        setFirstProducction = GetSetOfProductions ( grammar );
        foreach ( Set set in setFirstProducction )
        {
            set.values.AddRange ( GetFirstOfProduction ( new List<char> () , set.index , grammar ) );
        }

        return setFirstProducction;
    }

    /// <summary>Gets the next of no terminals.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Set> GetNextOfNoTerminals ( GenericGrammar grammar )
    {
        List<Set>setNextProduction = new List<Set>();
        setNextProduction = GetSetOfNoTerminals ( grammar );
        foreach ( Set set in setNextProduction )
        {
            set.values.AddRange ( GetNextOfNoTerminal ( new List<char> () , new List<char> () , set.name , grammar ) );
        }

        return setNextProduction;
    }
    /// <summary>Gets the seleccion set of productions.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Set> GetSeleccionSetOfProductions ( GenericGrammar grammar )
    {
        List<Set> setSelection = new List<Set>();
        setSelection = GetSetOfProductions ( grammar );

        foreach ( Set set in setSelection )
        {
            set.values.AddRange ( GetSeleccionSetOfProduction ( new List<char> () , set.index , grammar ) );
        }
        return setSelection;
    }

    #endregion

    #region Utilities GetAnullableNoTerminals
    /// <summary>Determines whether [is anullable production] [the specified production].</summary>
    /// <param name="production">The production.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns>
    ///   <c>true</c> if [is anullable production] [the specified production]; otherwise, <c>false</c>.</returns>
    public static bool IsAnullableProduction ( Production production , GenericGrammar grammar )
    {
        foreach ( var element in production.rightSide )
        {
            if ( element.kind.Equals ( Element.Kind.nulo ) )
            {
                return true;
            }
            else if ( element.kind.Equals ( Element.Kind.noTerminal ) )
            {
                if ( !IsLeftSideOfProductionANullable ( element , grammar ) )
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        return true;
    }

    /// <summary>Determines whether [is left side of production a nullable] [the specified element].</summary>
    /// <param name="element">The element.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns>
    ///   <c>true</c> if [is left side of production a nullable] [the specified element]; otherwise, <c>false</c>.</returns>
    public static bool IsLeftSideOfProductionANullable ( Element element , GenericGrammar grammar )
    {
        foreach ( var production in grammar.productions )
        {
            if ( production.leftSide.value.Equals ( element.value ) && production.leftSide.kind.Equals ( element.kind ) )
            {
                if ( production.rightSide [0].kind.Equals ( Element.Kind.nulo ) )
                {
                    return true;
                }
                else if ( production.rightSide [0].kind.Equals ( Element.Kind.noTerminal ) )
                {
                    return IsAnullableProduction ( production , grammar );
                }
            }
        }

        return false;
    }
    #endregion

    #region Utilities GetFirstNoTerminals

    /// <summary>Gets the set of no terminals.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Set> GetSetOfNoTerminals ( GenericGrammar grammar )
    {
        List<Set>setOfNoTerminals = new List<Set>();

        //Search noterminal in grammar.produdctions
        foreach ( Production production in grammar.productions )
        {
            if ( !ListContains ( setOfNoTerminals.ToArray () , production.leftSide ) )
            {
                setOfNoTerminals.Add ( new Set ( production.leftSide.value , Set.Kind.first ) );
            }
        }

        return setOfNoTerminals;
    }

    /// <summary>Gets the first of no terminal.</summary>
    /// <param name="values">The values.</param>
    /// <param name="noTerminalValue">The no terminal value.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<char> GetFirstOfNoTerminal ( List<char> values , char noTerminalValue , GenericGrammar grammar )
    {

        foreach ( Production production in grammar.productions )
        {
            if ( noTerminalValue.Equals ( production.leftSide.value ) )
            {
                foreach ( Element element in production.rightSide )
                {
                    if ( element.kind.Equals ( Element.Kind.terminal ) )
                    {
                        if ( !values.Contains ( element.value ) )
                        {
                            values.Add ( element.value );
                        }

                        break;
                    }
                    else if ( element.kind.Equals ( Element.Kind.noTerminal ) )
                    {
                        values.Intersect ( GetFirstOfNoTerminal ( values , element.value , grammar ) ).Any ();
                    }


                }
            }
        }

        return values;

    }

    /// <summary>Lists the contains.</summary>
    /// <param name="set">The set.</param>
    /// <param name="element">The element.</param>
    /// <returns></returns>
    public static bool ListContains ( Set [] set , Element element )
    {

        foreach ( Set item in set )
        {
            if ( item.name.Equals ( element.value ) )
            {
                return true;
            }
        }
        return false;
    }


    #endregion

    #region Utilities GetFirstProducctions
    /// <summary>Gets the set of productions.</summary>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Set> GetSetOfProductions ( GenericGrammar grammar )
    {

        List<Set>setOfProductions=new List<Set>();

        for ( int i = 0 ;i < grammar.productions.Count ;i++ )
        {
            setOfProductions.Add ( new Set ( grammar.productions [i].leftSide.index , grammar.productions [i].leftSide.value , Set.Kind.first ) );
        }

        return setOfProductions;
    }

    /// <summary>Gets the first of production.</summary>
    /// <param name="values">The values.</param>
    /// <param name="index">The index.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    private static List<char> GetFirstOfProduction ( List<char> values , int index , GenericGrammar grammar )
    {

        foreach ( Element element in grammar.productions [index - 1].rightSide )
        {
            if ( element.kind.Equals ( Element.Kind.terminal ) )
            {
                if ( !values.Contains ( element.value ) )
                {
                    values.Add ( element.value );
                    break;
                }
            }
            else if ( element.kind.Equals ( Element.Kind.noTerminal ) )
            {
                values.Intersect ( GetFirstOfNoTerminal ( values , element.value , grammar ) ).Any ();
            }

        }
        return values;
    }


    #endregion

    #region GetNextOfNoTerminals

    /// <summary>Gets the next of no terminal.</summary>
    /// <param name="visited">The visited.</param>
    /// <param name="values">The values.</param>
    /// <param name="nameNoTerminal">The name no terminal.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<char> GetNextOfNoTerminal ( List<char> visited , List<char> values , char nameNoTerminal , GenericGrammar grammar )
    {
        visited.Add ( nameNoTerminal );
        for ( int i = 0 ;i < grammar.productions.Count ;i++ )
        {
            for ( int j = 0 ;j < grammar.productions [i].rightSide.Count ;j++ )
            {
                if ( grammar.productions [i].rightSide [j].value.Equals ( nameNoTerminal ) )
                {
                    #region  s
                    if ( GetSetOfNoTerminals ( grammar ) [0].name.Equals ( grammar.productions [i].rightSide [j].value ) )
                    {
                        if ( !values.Contains ( '¬' ) )
                        {
                            values.Add ( '¬' );
                        }
                    }
                    #endregion


                    if ( ( j + 1 ) < grammar.productions [i].rightSide.Count )
                    {
                        #region Next is a terminal
                        if ( grammar.productions [i].rightSide [j + 1].kind.Equals ( Element.Kind.terminal ) )
                        {
                            if ( !values.Contains ( grammar.productions [i].rightSide [j + 1].value ) )
                            {
                                values.Add ( grammar.productions [i].rightSide [j + 1].value );

                            }
                        }
                        #endregion

                        #region Next is a no terminal
                        else if ( grammar.productions [i].rightSide [j + 1].kind.Equals ( Element.Kind.noTerminal ) )
                        {
                            values.Intersect ( GetFirstOfNoTerminal ( values , grammar.productions [i].rightSide [j + 1].value , grammar ) ).Any ();
                            #region Next is anullable
                            if ( ListContains ( GrammarTools.GetAnullableNoTerminals ( grammar ) , grammar.productions [i].rightSide [j + 1] ) && !visited.Contains ( grammar.productions [i].rightSide [j + 1].value ) )
                            {
                                values.Intersect ( GetNextOfNoTerminal ( visited , values , grammar.productions [i].rightSide [j + 1].value , grammar ) ).Any ();
                            }
                            #endregion

                        }
                        #endregion
                    }
                    #region At the end
                    else if ( ( j + 1 ) == grammar.productions [i].rightSide.Count )
                    {
                        //Tener en cuenta si es anulable que se hace

                        if ( !grammar.productions [i].leftSide.value.Equals ( nameNoTerminal ) && !visited.Contains ( grammar.productions [i].leftSide.value ) )
                        {

                            values.Intersect ( GetNextOfNoTerminal ( visited , values , grammar.productions [i].leftSide.value , grammar ) ).Any ();

                        }
                    }
                    #endregion
                }
            }
        }
        return values;
    }

    /// <summary>Lists the contains.</summary>
    /// <param name="elements">The elements.</param>
    /// <param name="element">The element.</param>
    /// <returns></returns>
    public static bool ListContains ( List<Element> elements , Element element )
    {

        foreach ( var elem in elements )
        {
            if ( elem.value.Equals ( element.value ) && elem.kind.Equals ( element.kind ) )
            {
                return true;
            }
        }

        return false;
    }
    #endregion

    #region Utilities GetSeleccionSetOfProductions
    /// <summary>Gets the seleccion set of production.</summary>
    /// <param name="values">The values.</param>
    /// <param name="index">The index.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<char> GetSeleccionSetOfProduction ( List<char> values , int index , GenericGrammar grammar )
    {
        Production production=grammar.productions[index-1];

        values.Intersect ( GetFirstOfProduction ( values , index , grammar ) ).Any ();

        if ( IsAnullableProduction ( production , grammar ) )
        {
            values.Intersect ( GetNextOfNoTerminal ( new List<char> () , values , production.leftSide.value , grammar ) ).Any ();
        }

        return values;

    }

    /// <summary>Gets the productions of.</summary>
    /// <param name="name">The name.</param>
    /// <param name="grammar">The grammar.</param>
    /// <returns></returns>
    public static List<Production> GetProductionsOf ( char name , GenericGrammar grammar )
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
    #endregion
    /// <summary>Gets the production with value.</summary>
    /// <param name="x">The x.</param>
    /// <param name="productions">The productions.</param>
    /// <returns></returns>
    public static Production GetProductionWithValue ( char x , List<Production> productions )
    {
        foreach ( Production production in productions )
        {
            if ( production.rightSide [0].value.Equals ( x ) && production.rightSide[0].kind.Equals(Element.Kind.terminal))
            {
                return production;
             
            }
        }

        return null;
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


}

