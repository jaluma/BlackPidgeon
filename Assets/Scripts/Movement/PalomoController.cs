using System;
using UnityEngine;

public class PalomoController : MonoBehaviour {
    public float TurnForceMultiplier = 1;
    public float MaxSpeed = 50.0f;

    private Rigidbody _rigidBody;
    private Camera _mainCamera;

    private bool _flying;
    private bool _grounded;

    void Start () {
        _rigidBody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;

        _flying = true;
        _grounded = false;
    }

	// Update is called once per frame
	void Update () {
        if (_flying) {
            var forward = _mainCamera.transform.forward;
            //var right = _mainCamera.transform.right;

            forward.Normalize();
            //right.Normalize();

            var desiredMoveDirection = forward;
            transform.Translate(desiredMoveDirection * MaxSpeed * Time.deltaTime);
            transform.forward = desiredMoveDirection;
        } else {
            if (!_grounded) {
                _rigidBody.useGravity = true;
                _rigidBody.AddForce(1, -500, 1);
            } else {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _rigidBody.mass = 2;

                // controller andando
            }
        }
    }

    void FixedUpdate()
    {
        if (_flying) {
            
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Contains("Ground")) {
            _grounded = true;
        }

        _flying = false;
    }
}
    