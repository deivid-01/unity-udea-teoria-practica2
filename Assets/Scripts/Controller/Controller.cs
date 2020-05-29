using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    #region Singlenton

    public static Controller instance;
    private void Awake ()
    {
        instance = this;
    }
    #endregion

    string whyFail;

    public dynamic grammar;


    public void CheckGrammar ( string data ) {

        if ( BelongToSomeone ( data ) )
        {
            UI.instance.ShowWindow(UI.instance.windowHilera);
        }
        else
        {
           UI.instance.ShowResult (UI.instance.windowResultGrammar, UI.instance.resultGrammar,whyFail );        
        }

    }

    public bool BelongToSomeone ( string data ) {
        if ( S.Belong ( data ) )
        {
            grammar = new S ();
            return true;

        }
        else if ( Q.Belong ( data ) )
        {
            grammar = new Q ();
            return true;

        }
        else if ( LL.Belong ( data ) )
        {

            grammar = new LL ();
            return true;

        }
        return false;
    }

    public void CheckHilera (string hilera) {
        if ( grammar.ValidateHilera (hilera) )
        { 
            UI.instance.ShowResult ( UI.instance.windowResultHilera , UI.instance.resultHilera , "La hilera es valida" );
            return;
        }
        UI.instance.ShowResult(UI.instance.windowResultHilera,UI.instance.resultHilera, "La hilera NO es valida" );

    }


}
