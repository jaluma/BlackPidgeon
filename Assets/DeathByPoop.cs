using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DeathByPoop : MonoBehaviour
{
	Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();        
    }
    private void OnTriggerEnter(Collider other){
		if(other.CompareTag("poop"))
		{
            myAnimator.SetBool("die",true);
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            Destroy(gameObject, 6f);
        }
    }
    private void Update()
    {
        if(gameObject.transform.position.y<0 || gameObject.transform.position.x == 0)
            gameObject.SetActive(false);
    }
}
