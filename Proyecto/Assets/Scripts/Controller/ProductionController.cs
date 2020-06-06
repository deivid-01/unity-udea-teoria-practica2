using JetBrains.Annotations;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
/// <summary>
/// Production controller to create new productions
/// </summary>
public class ProductionController : MonoBehaviour
{

    public static Production production;
    public static string kind;


    private void Start ()
    {
        GameEvent.instance.OnAddProduction += AddProduction;
        production= new Production ();
    }

    public void AddProduction ( string r ) { 
         GrammarController.genericGrammar.productions.Add ( production );
        production = new Production ();
    }

    public static void CheckNoTerminal (string input) {

        if (! VerificationNoTerminal ( input ) )
        {
            return;
        }

        //Add new No terminal
        AddNoTerminal (input);
        
        GameEvent.instance.RightAddTerminal ( input , 'N' , UIProduction.instance.windowNoTerminal );
        



    }

    public static void CheckTerminalNoTerminal (string input) {

        if ( kind.Equals ( "N" ) )
        {
            CheckTerminal ( input );
        }
        else if ( kind.Equals ( "T" ) )
        {
            CheckNoTerminal ( input );
        }
    }

    public static void CheckTerminal ( string input ) {
        if ( !VerificationTerminal ( input ) )
        {
            return;
        }

        AddTerminal ( input );
       
        GameEvent.instance.RightAddTerminal ( input , 'T' , UIProduction.instance.windowTerminal );


    }

    public static bool VerificationNoTerminal (string input) {
        if ( input.Length <= 0 )
        {
            GameEvent.instance.ErrorAddProduction ( "Ingresa al menos 1 caracter" );
            return false;
        }

        if ( Encoding.ASCII.GetBytes ( input ) [0] < 65 || Encoding.ASCII.GetBytes ( input ) [0] > 90 )
        {
            GameEvent.instance.ErrorAddProduction ( "Los valores deben ser de la A-Z (MAYUSCULA)" );
            return false;
        }
        return true;
    }

    public static bool  VerificationTerminal ( string input ) {

        Debug.Log ( input );
        if ( input.Length == 0 )
        {
            GameEvent.instance.ErrorAddProduction ( "Ingresa al menos 1 caracter" );
            return false;
        }
        return true;
    }

    public static void AddNoTerminal (string value) {

        Element newElement= new Element(Element.Kind.noTerminal,value[0]);
        if ( production.leftSide is null )
        {
            newElement.index = GrammarController.genericGrammar.productions.Count + 1;
            production.leftSide = newElement;
            
        }
        else
        {
            production.rightSide.Add ( newElement );
        }

    }

    public static void AddTerminal ( string value ) { 
        Element newElement= new Element(Element.Kind.terminal,value[0]);
        production.rightSide.Add ( newElement );
    }


    public void ResetProduction () {
        production = new Production ();
        UIProduction.instance.ResetUIProduction ();
    }

    public  static void AddNullProduction ()
    {
        production.rightSide.Add ( new Element ( Element.Kind.nulo , 'λ' ) );
    }
}
 