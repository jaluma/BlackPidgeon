using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByPoop : MonoBehaviour
{
	Animator myAnimator;
    // Start is called before the first frame update

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player"))
		{
			myAnimator.SetBool("die",true);
		}
	}
}
