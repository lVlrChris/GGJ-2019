using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField]
    private float _floatDuration;
    [SerializeField]
    private float _floatSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * _floatSpeed * Time.deltaTime;
    }
}
