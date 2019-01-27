using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject _brokenPrefab;

    [SerializeField]
    private int _value;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Equals("Player")) {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null) {
                player.AddDamage(_value);
                gameObject.SetActive(false);
                Instantiate(_brokenPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
