using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanzarPalomas : MonoBehaviour
{
    public float delay=3f;
    private float time;
    private bool atacar=false;
    public ImagePigeons imagePigeon;
    public Text text;
    public AudioClip clip;
    public AudioSource source;
    private bool isPlaying = false;
    private int palomasLanzadas=0;
    public int speed;
    public float delayDisparo = 0.5f;
    private float delayEntrePaloma;
    // Start is called before the first frame update

    private void Start()
    {
        source.clip = clip;
    }

    private void playMusic()
    {
        if (!isPlaying)
        {
            source.Play();
            source.volume = 0.25f;
            isPlaying = true;
        }
    }
    private void stopMusic()
    {
        if (isPlaying)
        {
            source.Stop();
            isPlaying = false;
        }
    }

    private void Update()
    {
        if (atacar)
        {
            playMusic();
            time += Time.deltaTime;
            string txt = System.Math.Abs(System.Math.Truncate(delay - time)).ToString();
            if (System.Math.Abs(System.Math.Truncate(delay - time)) < 0)
            {
                txt = "";
            }
            
            text.text = txt;
            if (time > delay) {
                stopMusic();
                delayEntrePaloma += Time.deltaTime;
                while(palomasLanzadas< imagePigeon.GetCount()&& delayEntrePaloma > delayDisparo) { 
                    GameObject prefab = Resources.Load("PalomaProyectil") as GameObject;
                    GameObject paloma = Instantiate(prefab) as GameObject;
                    paloma.transform.position = transform.position + Camera.main.transform.forward * 2;
                    Rigidbody rb = paloma.GetComponent<Rigidbody>();
                    rb.velocity = Camera.main.transform.forward * speed;
                    delayEntrePaloma = 0;
                    palomasLanzadas++;
                }
                if(palomasLanzadas>= imagePigeon.GetCount()) {
                    atacar = false;
                    time = 0;
                    text.text = "";
                    palomasLanzadas = 0;
                }
                
            }
        }
    }
    public void Atacar()
    {
        atacar = true;
        
    }
}
