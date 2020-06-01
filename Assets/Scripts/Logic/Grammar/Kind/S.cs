using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class S
{
    public S ()
    {
        //Build grammmar
    }
    public static bool Belong ( GenericGrammar grammar ) => ( !FirstElementsAreTerminals ( grammar ) || !SameProductionDiffRightTerminal ( grammar ) ) ? false : true;

    public bool ValidateHilera ( string hilera )
    {
        //ValidateHilera
        throw new NotImplementedException ( "Valide Hilera no se ha implementado" );
    }


    #region Utilities methods
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
