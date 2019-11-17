using System;
using UnityEngine;

public class PalomoController : MonoBehaviour {
    public float TurnForceMultiplier = 1;
    public float MaxSpeedMultiplierWalking = 0.5f;
    public float MaxSpeedMultiplierFlying = 1.0f;
    public float MaxSpeed = 50.0f;
    public float StopAngle = -10.0f;
    public float MoveAngle = 0.0f;
    public float FlyAngle = 20.0f;
    public float DelayTimeFly = 5f;
    public float DropSpeed = 20.0f;

    private Rigidbody _rigidBody;
    private Camera _mainCamera;

    private bool _flying;
    private bool _grounded;

    private bool _moveForwardGround;
    private float _elapsedTimeFly = 0.0f;

    private Vector3 StopAngleVector;

    void Start() {
        _rigidBody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;

        _flying = false;
        _grounded = true;
        _moveForwardGround = true;

        MoveAngle *= 0.01f;
        StopAngle *= 0.01f;
        FlyAngle *= 0.01f;
    }

    // Update is called once per frame
    void Update() {
        if (_flying) {
            var forward = _mainCamera.transform.forward;
            //var right = _mainCamera.transform.right;

            forward.Normalize();
            //right.Normalize();

            var desiredMoveDirection = forward;
            transform.Translate(desiredMoveDirection * MaxSpeed * MaxSpeedMultiplierFlying * Time.deltaTime);
            transform.forward = desiredMoveDirection;
        } else {

            if (!_grounded) {
                _rigidBody.useGravity = true;
                _rigidBody.AddForce(1, -DropSpeed, 1);

            } else {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _rigidBody.mass = 2;

                // controller andando
                if (_mainCamera.transform.forward.y <= StopAngle) {
                    DisableWalk();
                }

                if (_mainCamera.transform.forward.y >= MoveAngle && _mainCamera.transform.forward.y < FlyAngle) {
                    EnableWalk();
                }

                if (_mainCamera.transform.forward.y >= FlyAngle) {
                    _elapsedTimeFly += Time.deltaTime;
                    if (_elapsedTimeFly >= DelayTimeFly) {
                        EnableFly();
                    }

                } else {
                    _elapsedTimeFly = 0;
                }

                if (_moveForwardGround) {
                    transform.position = transform.position + _mainCamera.transform.forward * MaxSpeed * MaxSpeedMultiplierWalking * Time.deltaTime;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Contains("Ground")) {
            _grounded = true;
            DisableFly();
        }

        DisableFly();
    }

    void EnableFly() {
        _flying = true;
        _grounded = false;
        _rigidBody.useGravity = false;
    }

    void DisableFly() {
        _flying = false;
        _rigidBody.useGravity = true;
    }

    void EnableWalk() {
        _grounded = true;
        _moveForwardGround = true;
    }

    void DisableWalk() {
        _moveForwardGround = false;
    }

}
