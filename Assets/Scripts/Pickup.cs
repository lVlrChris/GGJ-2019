using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Player player;

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag.Equals("Player")) {
            player = other.transform.GetComponent<Player>();
            if (player != null) {
                player.AddPickup();
                Destroy(this.gameObject);
            }
        }
    }
}
