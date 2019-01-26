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
    [SerializeField]
    private GameObject _playerModel;
    [SerializeField]
    private float _maxSquash;
    [SerializeField]
    private float _squashRate;
    private Vector3 _originalScale;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = _maxSpinSpeed;

        _jumpForce = 0f;
        _originalScale = _playerModel.transform.localScale;
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
                
                float modelSquash = _playerModel.transform.localScale.y;

                //Squasing
                print("Current jump force: " + _jumpForce + " - " + _maxJumpForce);
                print("Current Squash: " + modelSquash + " - " + _maxSquash);
                if (modelSquash > _maxSquash) {
                    modelSquash -= _squashRate * Time.deltaTime;
                    _playerModel.transform.localScale -= new Vector3(0, _squashRate, 0);
                } else {
                    _playerModel.transform.localScale = new Vector3(_originalScale.x, _maxSquash, _originalScale.z);
                }
            } else {
                _jumpForce = _maxJumpForce;
            }

        } else {
            // Released jump button
            if (_jumpForce > 0f) {
                _jumpForce = _jumpForce + _minJumpForce;
                rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _playerModel.transform.localScale = _originalScale;
                _jumpForce = 0f;
            } 
        }
    }
}
