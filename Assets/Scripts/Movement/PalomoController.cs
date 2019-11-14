using System;
using UnityEngine;

public class PalomoController : MonoBehaviour {
    public float ForwardThrustForce = 40.0f;

    public float TurnForceMultiplier = 20;

    public float MaxSpeed = 100.0f;

    private Vector3 _controlForce;
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
            float x = _mainCamera.transform.forward.x;
            float y = _mainCamera.transform.forward.y;

            _controlForce.Set(
                x * TurnForceMultiplier,
                y * TurnForceMultiplier,
                1.0f
            );
            _controlForce = _controlForce.normalized * ForwardThrustForce;
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
            _rigidBody.AddRelativeForce(_controlForce, ForceMode.Force);

            transform.forward = _rigidBody.velocity;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name.Contains("terrain")) {
            _grounded = true;
        }

        _flying = false;
    }
}
    