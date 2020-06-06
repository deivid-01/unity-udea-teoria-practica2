using Boo.Lang.Environments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI of Add production
/// </summary>
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
    public GameObject btnReset;
    public GameObject goRighSide;

    public GameObject windowTerminal;
    public GameObject windowNoTerminal;


    public GameObject btnAddLeftSide;

    public GameObject btnAddNull;

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
        btnReset.SetActive ( false );
    }

    private void Update ()
    {
        if ( rightSide.text.Length > 0 )
        {
            btnDone.SetActive ( true );
            btnAddNull.SetActive ( false );

        }

        if ( leftSide.text.Length > 0 )
        {
            btnReset.SetActive ( true );
            btnAddLeftSide.SetActive ( false );
        }
    }


    public void RightAddTerminal (string input, char kind, GameObject window) {
        AddInput ( input , kind );
        HideWindow ( window );
        EnableComponnets ();
    }

    public void DisableComponents () {
        goRighSide.SetActive ( false );
        btnDone.SetActive ( false );
        btnReset.SetActive ( false );
    }

    public void EnableComponnets () {
        goRighSide.SetActive ( true );
        btnAddNull.SetActive ( true );
        if ( rightSide.text.Length >= 1 )
        {
            btnDone.SetActive ( true );
            btnReset.SetActive ( true );
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


    public void Close (bool back) {
        if(leftSide.text.Length>0  && rightSide.text.Length>0 && back==false)
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

    public  void ResetUIProduction ()
    {
        leftSide.text = "";
        rightSide.text = "";
        btnAddNull.SetActive ( true );
        btnAddLeftSide.SetActive ( true );
        goRighSide.SetActive ( false );
        btnReset.SetActive ( false );
        btnDone.SetActive ( false );
    }

    public void ShowError ( string msg )
    {

        errorMsg.text = msg;
        StartCoroutine ( ShowWindow () );

    }

    public void ReseText ( Text text ) {
        text.text = "";
    }


    IEnumerator ShowWindow ()
    {
        windowError.SetActive ( true );
        yield return new WaitForSeconds ( 1.5f );
        windowError.SetActive ( false );
    }

    public void AddNull () {
        goRighSide.SetActive ( false );
        rightSide.text = "λ";
        ProductionController.AddNullProduction ( );

    }
}
