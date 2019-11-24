using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVolarScript : MonoBehaviour,Interactuable
{

    public PalomoController palomoController;
    public LookingDown lookingScript;

    public void Execute()
    {
        palomoController.Fly();
        lookingScript.HideMenu();
    }

 
}
