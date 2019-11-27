using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScene : MonoBehaviour
{
    public string sceneName = "TownHallScene";
    public LanzarPalomas palomas;
    public Text texto;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Palomo"))
        {
            if (palomas.getCountPalomasReclutadas() >= 1) {
                InfoPalomo.GetNumPalomas = palomas.getCountPalomasReclutadas();
                InfoPalomo.OtraEscena = true;
                SceneManager.LoadScene("TownHallScene");
            }
        else
            texto.text = "NECESITAS 3 PALOMAS";

        }
    }

    

}
