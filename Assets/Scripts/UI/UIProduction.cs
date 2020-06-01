using Boo.Lang.Environments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProduction : MonoBehaviour
{

    #region Singlenton
    public static UIProduction instance;

    private void Awake ()
    {
        instance = this;
    }
    #endregion

    #region Texts

    public Text leftSide;
    public Text rightSide;

    #endregion

    #region Errors
    public GameObject windowError;
    public Text errorMsg;
    #endregion

    #region GameObjects
    public GameObject btnDone;
    public GameObject goRighSide;

    public GameObject windowTerminal;
    public GameObject windowNoTerminal;
    #endregion

    #region inputs
    public InputField inputTerminal;
    public InputField inputNoTerminal;
    #endregion

    void Start ()
    {
     
        GameEvent.instance.ErrorOnAddPruduction += ShowError;
        GameEvent.instance.RightOnAddTerminal += RightAddTerminal;
       


        goRighSide.SetActive ( false );
        btnDone.SetActive ( false );
    }


    public void RightAddTerminal (string input, char kind, GameObject window) {
        AddInput ( input , kind );
        HideWindow ( window );
        EnableComponnets ();
    }

    public void DisableComponents () {
        goRighSide.SetActive ( false );
        btnDone.SetActive ( false );
    }

    public void EnableComponnets () {
        goRighSide.SetActive ( true );
        if ( rightSide.text.Length > 1 )
        {
            btnDone.SetActive ( true );
        }
    }
    public void ShowWindow ( GameObject window ) {

        window.SetActive ( true );
    }

    public void HideWindow ( GameObject window )
    {
        window.SetActive ( false );
    } 

    public void ReadInput ( InputField inputField ) {

        if ( inputField.gameObject.name.Equals ( "inputTerminal" ) )
        {
            ProductionController.CheckTerminal ( inputField.text );


        }
        else if ( inputField.gameObject.name.Equals ( "inputNoTerminal" ) )
        {

            ProductionController.CheckNoTerminal ( inputField.text );
        }

        inputField.text = "";

    }


    public void Close () {
        GameEvent.instance.AddProduction (leftSide.text+" -> "+rightSide.text );
       


        HideWindow ( gameObject );

        leftSide.text = "";
        rightSide.text = "";
        DisableComponents ();
    }

    public void AddInput ( string input,char kind ) {
        if ( kind.Equals ( 'N' ) )
        {
            if ( goRighSide.activeInHierarchy )
                rightSide.text += "<" + inputNoTerminal.text + ">";
            else
                leftSide.text += "<" + inputNoTerminal.text + ">";

        }
        else if ( kind.Equals ( 'T' ) )
        {
            rightSide.text += inputTerminal.text;
        }
    }






    public void ShowError ( string msg )
    {

        errorMsg.text = msg;
        StartCoroutine ( ShowWindow () );

    }

 


    IEnumerator ShowWindow ()
    {
        windowError.SetActive ( true );
        yield return new WaitForSeconds ( 1.5f );
        windowError.SetActive ( false );
    }
}
