using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject _brokenPrefab;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Equals("Player")) {
            gameObject.SetActive(false);
            Instantiate(_brokenPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
