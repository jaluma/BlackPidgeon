using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoJuego : MonoBehaviour
{
    public static EstadoJuego estado;
    public static int numPalomas=0;

    private void Awake()
    {
        if (estado == null) {
            estado = this;
            DontDestroyOnLoad(estado);
        }
        else if(estado!=this)
        {
            Destroy(gameObject);
        }
            

    }
 
}
