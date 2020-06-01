using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    #region Singlenton
    public static GameEvent instance;

    private void Awake ()
    {
        instance = this;
    }
    #endregion

    public event Action <string> ErrorOnAddPruduction;

    public event Action <string,char,GameObject> RightOnAddTerminal;
    public event Action  <string> OnAddProduction;


    public void ErrorAddProduction ( string msg ) => ErrorOnAddPruduction?.Invoke ( msg );

    public void RightAddTerminal ( string input , char kind,GameObject win ) => RightOnAddTerminal?.Invoke ( input , kind,win );

    public void AddProduction (string production) => OnAddProduction?.Invoke (production);

}
