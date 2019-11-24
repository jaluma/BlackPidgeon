using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour {
    private Quaternion _rotation;
    public GameObject Parent;

    public bool Block = false;
    private Transform positionInitial;

    private void Start() {
        positionInitial = transform;
    }

    void Update() {
        if (Block) {
            transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            //Camera.main.GetComponent<LookingDown>().UpdateLastShowed();
        } else {
            transform.localPosition = new Vector3(0.1f, 0.36f, 0.72f);
            transform.parent = Camera.main.transform;
            transform.rotation = new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w);
            //transform.rotation = Camera.main.transform.rotation;
        }
    }
}
