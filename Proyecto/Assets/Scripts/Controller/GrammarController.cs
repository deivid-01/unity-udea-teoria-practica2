using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Grammar controller to create new grammar and check
/// </summary>
public class GrammarController : MonoBehaviour
{
    #region Singlenton
    [SerializeField]
    public static GrammarController instance;

    string kind;
    #endregion
    
    string whyFail;
    //Este tenga La lista[,] de las producciones
    public dynamic grammar;

    public static GenericGrammar genericGrammar;
    private void Awake ()
    {
        instance = this;
    }

    public void Start ()
    {
       genericGrammar = new GenericGrammar ();
    }

    public void CheckGrammar (  ) {

        if ( BelongToSomeone ( ) )
        {
            UIGrammar.instance.ShowWindow(UIGrammar.instance.windowHilera);
            UIGrammar.instance.resultGrammar.text = "It's a " + kind + " grammar";
            return;
        }
        UIGrammar.instance.ShowResult ( UIGrammar.instance.windowErrorConfirmationGrammar , UIGrammar.instance.resultGrammar , whyFail );


    }

    public bool BelongToSomeone (  ) {
        if ( S.Belong ( genericGrammar ) )
        {
            this.grammar = new S (genericGrammar);
            kind = "S";
            return true;

        }
        else if ( Q.Belong ( genericGrammar ) )
        {
            this.grammar = new Q (genericGrammar);
            kind = "Q";
            return true;

        }
        else if ( LL.Belong ( genericGrammar ) )
        {
            kind = "LL(1)";
            this.grammar = new LL (genericGrammar);
            return true;

        }
        return false;
    }

    public void CheckHilera (string hilera) {
        Debug.Log ( "Hilera " + hilera );
        if ( grammar.ValidateRow (hilera+"¬"))
        { 
            UIGrammar.instance.ShowResult ( UIGrammar.instance.windowResultHilera , UIGrammar.instance.resultHilera , "Row accepted" );
            return;
        }
        UIGrammar.instance.ShowResult(UIGrammar.instance.windowResultHilera,UIGrammar.instance.resultHilera, "Row not accepted" );

    }

    public void ResetProductions () {

        genericGrammar = new GenericGrammar ();
        ProductionController.production = new Production ();
        SceneManager.LoadScene ( SceneManager.GetActiveScene ().buildIndex );
    }

   

}
