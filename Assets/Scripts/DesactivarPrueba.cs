using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarPrueba : MonoBehaviour,Interactuable
{


    public void Desactivar()
    {
        gameObject.SetActive(false);
        print("CiudadanoMorir");
    }

    public void Execute()
    {
        Desactivar();
    }
}
