using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrammarController : MonoBehaviour
{
    #region Singlenton
    [SerializeField]
    public static GrammarController instance;

    private void Awake ()
    {
        instance = this;
    }
    #endregion
    
    string whyFail;
    //Este tenga La lista[,] de las producciones
    public dynamic grammar;

    public static GenericGrammar genericGrammar= new GenericGrammar();

    public void CheckGrammar (  ) {

        if ( BelongToSomeone ( ) )
        {
            UIGrammar.instance.ShowWindow(UIGrammar.instance.windowHilera);
        }
        else
        {
           UIGrammar.instance.ShowResult (UIGrammar.instance.windowResultGrammar, UIGrammar.instance.resultGrammar,whyFail );        
        }

    }

    public bool BelongToSomeone (  ) {
        if ( S.Belong ( genericGrammar ) )
        {
            this.grammar = new S ();
            return true;

        }
        else if ( Q.Belong ( genericGrammar ) )
        {
            this.grammar = new Q ();
            return true;

        }
        else if ( LL.Belong ( genericGrammar ) )
        {

            this.grammar = new LL ();
            return true;

        }
        return false;
    }

    public void CheckHilera (string hilera) {
        if ( grammar.ValidateHilera (hilera) )
        { 
            UIGrammar.instance.ShowResult ( UIGrammar.instance.windowResultHilera , UIGrammar.instance.resultHilera , "La hilera es valida" );
            return;
        }
        UIGrammar.instance.ShowResult(UIGrammar.instance.windowResultHilera,UIGrammar.instance.resultHilera, "La hilera NO es valida" );

    }


}
