using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject _brokenPrefab;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Equals("Player")) {
            Instantiate(_brokenPrefab, transform.position, transform.rotation);
        }
    }
}
