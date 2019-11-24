using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour {
    public GameObject Parent;
    public bool Block = false;

    private Transform _positionInitial;

    private void Start() {
        _positionInitial = transform;       // no usar referencias. FALLA!
    }

    void Update() {
        if (Block) {
            transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            Camera.main.GetComponent<LookingDown>().UpdateLastShowed();
        } else {
            transform.localPosition = new Vector3(0.1f, 0.36f, 0.72f);          // valores por defecto del canvas.
            transform.parent = Camera.main.transform;
            transform.rotation = new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w);
        }
    }
}
