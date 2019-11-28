using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAndarScript : MonoBehaviour,Interactuable
{
    public PalomoController palomoController;
    public LookingDown lookingScript;

    public void Execute()
    {
        palomoController.Walk();
        lookingScript.HideMenu();
    }
}
