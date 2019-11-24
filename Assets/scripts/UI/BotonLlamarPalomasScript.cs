using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonLlamarPalomasScript : MonoBehaviour,Interactuable
{

    public LanzarPalomas lanzar;

    public void Execute()
    {
        lanzar.Atacar();
    }


}
