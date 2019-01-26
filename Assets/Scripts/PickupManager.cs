using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public static PickupManager instance = null;

    [SerializeField]
    private GameObject _pickupPrefab;
    [SerializeField]
    private GameObject[] _spawnPoints;

    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void SpawnNewPickup() {
        int pickedSpawnPoint = Random.Range(0, _spawnPoints.Length);
        Instantiate(_pickupPrefab, _spawnPoints[pickedSpawnPoint].transform.position, Quaternion.identity);
    }
}
