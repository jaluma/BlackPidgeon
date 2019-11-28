using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonMakeItRainScript : MonoBehaviour, Interactuable
{
    public GameObject ataque;
    public LookingDown lookingScript;

    public void Execute()
    {
        lookingScript.HideMenu();
        ataque.GetComponent<AtaqueAerio>().BombaVa();
    }
}
