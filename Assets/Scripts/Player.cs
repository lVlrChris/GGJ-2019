using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxSpinSpeed = 200;
    [SerializeField]
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
        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");
        
        xSpeed = xSpeed * _speed * Time.deltaTime;
        ySpeed = ySpeed * _speed * Time.deltaTime;

        rb.AddTorque(new Vector3(xSpeed, 0, ySpeed));

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
