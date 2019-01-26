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

    [Header("Players")]
    [SerializeField]
    private Player _playerOne;
    [SerializeField]
    private Player _playerTwo;

    [Header("Score Values")]
    [SerializeField]
    private int _pickupMultiplier = 100;

    private bool gameStarted = false;


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
        Physics.IgnoreLayerCollision(9, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted) {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0) {
                EndGame();
            }
        }
    }

    void EndGame() {
        int playerOneScore = 0;
        int playerTwoScore = 0;
        playerOneScore = _playerOne.pickups * 100;
        playerTwoScore = _playerTwo.pickups * 100;

        if (playerOneScore > playerTwoScore) {
            //Player 1 won!
        } else if (playerOneScore > playerTwoScore) {
            //Player 2 won!
        }

        // View results screen
    }
}
