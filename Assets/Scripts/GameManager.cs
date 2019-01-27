using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager is a singleton instance.
    public static GameManager instance;

    [SerializeField]
    private float _gameDuration = 90;
    public float _timeLeft;

    [Header("Players")]
    [SerializeField]
    private GameObject _playerOne;
    [SerializeField]
    private GameObject _playerTwo;

    [Header("Score Values")]
    [SerializeField]
    private int _pickupMultiplier = 100;

    private bool _gameStarted = false;


    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Physics.IgnoreLayerCollision(9, 10);
        _timeLeft = _gameDuration;

        //TODO: set gameStarted from menu
        _gameStarted = true;
    }

    void Update()
    {
        if (_gameStarted) {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0) {
                instance.CalculateScores();
            }
        }
    }

    public void CalculateScores() {
        Player playerOne = _playerOne.GetComponent<Player>();
        Player playerTwo = _playerTwo.GetComponent<Player>();

        int playerOneScore = playerOne.pickups * _pickupMultiplier;
        int playerTwoScore = playerTwo.pickups * _pickupMultiplier;
        
        playerOneScore -= playerOne.totalDamage;
        playerTwoScore -= playerTwo.totalDamage;

        print("Player one: " + playerOneScore + " - Player Two: " + playerTwoScore);
        if (playerOneScore > playerTwoScore) {
            //Player 1 won!
            print("Player one won!!!");
        } else if (playerTwoScore > playerOneScore) {
            //Player 2 won!
            print("Player two won!!!");
        } else {
            //Both players tied!
            print("Both players Tied...");
        }

        // View results screen
    }
}
