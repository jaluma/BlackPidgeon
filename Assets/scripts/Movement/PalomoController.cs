using System;
using UnityEngine;

public class PalomoController : MonoBehaviour {
    public float TurnForceMultiplier = 1;
    public float MaxSpeedMultiplierWalking = 0.5f;
    public float MaxSpeedMultiplierFlying = 1.0f;
    public float MaxSpeed = 50.0f;
    //public float StopAngle = -10.0f;
    //public float MoveAngle = 0.0f;
    //public float FlyAngle = 20.0f;
    public float DelayTimeFly = 2f;
    public float DropSpeed = 20.0f;

    public Vector3 DistanceFlying;

    private Rigidbody _rigidBody;
    private Camera _mainCamera;
    private GameObject _player;

    public bool Flying { get => _flying; }
    private bool _flying;
    private bool _grounded;

    private bool _moveForwardGround;

    void Start() {
        _rigidBody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        _player = GameObject.FindGameObjectWithTag("Player");

        //DisableFly();
        //EnableWalk();
        //DisableWalk();      // arrancamos parados
    }

    // Update is called once per frame
    void Update() {
        if (_flying) {
            transform.position = transform.position + _mainCamera.transform.forward * MaxSpeed * MaxSpeedMultiplierFlying * Time.deltaTime;
            transform.forward = _mainCamera.transform.forward;
        } else {

            if (!_grounded) {
                _rigidBody.useGravity = true;
                _rigidBody.AddForce(1, -DropSpeed, 1);
            } else {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _rigidBody.mass = 2;

                if (_moveForwardGround) {
                    transform.position = transform.position + _mainCamera.transform.forward * MaxSpeed * MaxSpeedMultiplierWalking * Time.deltaTime;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Contains("Ground")) {
            _grounded = true;
        }
    }

    public void EnableFly() {
        DisableWalk();      //check
        _flying = true;
        _grounded = false;
        _rigidBody.useGravity = false;

        _player.GetComponent<CameraController>().ChangePositionCamera(DistanceFlying);
    }

    public void DisableFly() {
        _flying = false;
        _rigidBody.useGravity = true;

        _player.GetComponent<CameraController>().ResetPositionCamera();
    }

    public void EnableWalk() {
        DisableFly();       //check
        _grounded = true;
        _moveForwardGround = true;
    }

    public void DisableWalk() {
        _moveForwardGround = false;
    }

    public void Fly() {
        if (_flying) {
            DisableFly();
            _mainCamera.GetComponent<LookingDown>().DisableFly();
        } else {
            EnableFly();
            _mainCamera.GetComponent<LookingDown>().EnableFly();
        }
    }

    public void Walk() {
        _mainCamera.GetComponent<LookingDown>().DisableFly();
        if (_moveForwardGround) {
            DisableWalk();
        } else {
            EnableWalk();
        }
    }

}
