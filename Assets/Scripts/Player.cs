using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxSpinSpeed = 200;
    
    [Header("Jump Settings")]
    [SerializeField]
    private float _maxJumpForce;
    [SerializeField]
    private float _minJumpForce;
    [SerializeField]
    private float _jumpChargeRate;
    private float _jumpForce;


    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = _maxSpinSpeed;
    }

    // FixedUpdate before physics calculation
    void FixedUpdate()
    {
        ballMovement();
    }

    void Update() {
        float groundDistance = GetComponent<Collider>().bounds.extents.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance + 0.1f);

        if (isGrounded) {
            Jump();
        }
    }

    private void ballMovement() {
        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");
        
        xSpeed = xSpeed * _speed * Time.deltaTime;
        ySpeed = ySpeed * _speed * Time.deltaTime;

        rb.AddTorque(new Vector3(xSpeed, 0, ySpeed));
    }

    private void Jump() {
        // Holding jump button
        if (Input.GetKey(KeyCode.Space)) {
            if (_jumpForce < _maxJumpForce) {
                _jumpForce += _jumpChargeRate * Time.deltaTime;
            } else {
                _jumpForce = _maxJumpForce;
            }
            print(_jumpForce);

        } else {
            // Released jump button
            if (_jumpForce > 0f) {
                _jumpForce = _jumpForce + _minJumpForce;
                rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _jumpForce = 0f;
            } 
        }
    }
}
