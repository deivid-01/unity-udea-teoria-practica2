
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    #region Singlenton
    public static UI instance;

    private void Awake ()
    {
        instance = this;
    }
    #endregion


    public GameObject windowGrammar;
    public GameObject windowConfirmationGrammar;

    public GameObject windowHilera;
    public GameObject windowConfirmationHilera;


    public GameObject actualWindow;

    public GameObject windowResultGrammar;
    public GameObject windowResultHilera;
    public Text resultGrammar;
    public Text resultHilera;
    private void Start ()
    {
        actualWindow = windowGrammar;
    }
    public void ReadGrammar ( InputField inputGrammar )
    {
        
      
        Controller.instance.CheckGrammar ( inputGrammar.text );
    }

    public void ReadHilera ( InputField inputHilera )
    {
        Controller.instance.CheckHilera ( inputHilera.text );
    }

    public void GetAnswerGrammar ( bool ans )
    {

        if ( ans )
        {
            Enable ( windowGrammar );
            return;
        }
        Application.Quit (); //exit
    }

    public void GetAnswerHilera ( bool ans )
    {

        if ( ans )
        {
            Enable ( windowHilera );
            return;
        }
        Enable ( windowConfirmationGrammar );
    }

    public void ShowResult ( GameObject window,Text result,string res ) {
        Enable ( window );

        result.text = res;
    }
  

    public void ShowWindow ( GameObject window )
    {
        Enable ( window );
    }

    public void Enable ( GameObject next )
    {
        actualWindow.SetActive ( false );
        next.SetActive ( true );
        actualWindow = next;
    }
}
