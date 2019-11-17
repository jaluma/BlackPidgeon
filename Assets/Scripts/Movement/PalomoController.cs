using System;
using UnityEngine;

public class PalomoController : MonoBehaviour
{
    public float TurnForceMultiplier = 1;
    public float MaxSpeed = 50.0f;
    public float StopAngle;
    public float MoveAngle;
    public float FlyAngle;
    public float DelayTimeFly = 2f;

    private Rigidbody _rigidBody;
    private Camera _mainCamera;

    private bool _flying;
    private bool _grounded;

    private bool _moveForwardGround;
    private float _elapsedTimeFly=0f;



    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;

        _flying = false;
        _grounded = true;
        _moveForwardGround = true;
        MoveAngle = MoveAngle * 0.01f;
        StopAngle = StopAngle * 0.01f;
        FlyAngle = FlyAngle * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_flying)
        {
            var forward = _mainCamera.transform.forward;
            //var right = _mainCamera.transform.right;

            forward.Normalize();
            //right.Normalize();

            var desiredMoveDirection = forward;
            transform.Translate(desiredMoveDirection * MaxSpeed * Time.deltaTime);
            transform.forward = desiredMoveDirection;
        }
        else
        {
            
            if (!_grounded)
            {
                _rigidBody.useGravity = true;
                _rigidBody.AddForce(1, -500, 1);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _rigidBody.mass = 2;

                // controller andando
                if (_mainCamera.transform.forward.y <= StopAngle)
                {
                    _moveForwardGround = false;
                }

                if (_mainCamera.transform.forward.y >= MoveAngle && _mainCamera.transform.forward.y < FlyAngle)
                {
                    _moveForwardGround = true;
                }

                if(_mainCamera.transform.forward.y >= FlyAngle)
                {
                    _elapsedTimeFly += Time.deltaTime;
                    if (_elapsedTimeFly >= DelayTimeFly)
                        _flying = true;
                    print(_flying);

                }
                else
                {
                    _elapsedTimeFly = 0;
                }

                if (_moveForwardGround)
                {
                    transform.position = transform.position + _mainCamera.transform.forward * MaxSpeed * Time.deltaTime;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (_flying)
        {

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Ground"))
        {
            _grounded = true;
            _flying = false;
        }

        
    }


   
}
