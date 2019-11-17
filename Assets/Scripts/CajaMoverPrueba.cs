using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMoverPrueba : MonoBehaviour,Interactuable
{
    public void Execute()
    {
        transform.position = transform.position+new Vector3(0,0,-2);
    }

}
