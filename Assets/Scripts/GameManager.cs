using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager is a singleton instance.
    public static GameManager instance = null;

    [SerializeField]
    private float _gameDuration = 90;

    public float _timeLeft;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = _gameDuration;
    }

    // Update is called once per frame
    void Update()
    {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft < 0) {
            EndGame();
        }
    }

    void EndGame() {
        
    }
}
