using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonMakeItRainScript : MonoBehaviour, Interactuable
{
    public AtaqueAerio ataque;
    public LookingDown lookingScript;

    public void Execute()
    {
        lookingScript.HideMenu();
        ataque.BombaVa();
        
    }
}
