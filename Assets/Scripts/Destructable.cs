using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    private GameObject _brokenPrefab;

    [SerializeField]
    private int _value;

    [SerializeField]
    private TextMeshPro _damageText;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Equals("Player")) {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null) {
                player.AddDamage(_value);
                gameObject.SetActive(false);
                Instantiate(_brokenPrefab, transform.position, transform.rotation);

                Camera camera = Camera.main;
                TextMeshPro text = Instantiate<TextMeshPro>(_damageText, transform.position, Quaternion.LookRotation(camera.transform.position) * Quaternion.Euler(0, 180, 0));
                text.text = "-" + _value;
                
                Destroy(gameObject);
            }
        }
    }
}
