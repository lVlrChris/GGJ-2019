using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // GameManager is a singleton instance.
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; }}

    [SerializeField]
    private float _gameDuration = 90;
    public float _timeLeft;

    [Header("Players")]
    [SerializeField]
    private GameObject _playerOne;
    [SerializeField]
    private GameObject _playerOneSpawn;
    [SerializeField]
    private GameObject _playerTwo;
    [SerializeField]
    private GameObject _playerTwoSpawn;

    [Header("Score Values")]
    [SerializeField]
    private int _pickupMultiplier = 100;

    [Header("Menu Objects")]
    [SerializeField]
    private GameObject _mainMenu;
    [SerializeField]
    private GameObject _scoreScreen;
    [SerializeField]
    private GameObject _dogWinImage;
    [SerializeField]
    private GameObject _dogLoseImage;
    [SerializeField]
    private GameObject _catWinImage;
    [SerializeField]
    private GameObject _catLoseImage;
    [SerializeField]
    private GameObject _dogVictoryImage;
    [SerializeField]
    private GameObject _catVictoryImage;
    [SerializeField]
    private GameObject _drawImage;
    [SerializeField]
    private Text _dogCandyText;
    [SerializeField]
    private Text _dogDamageText;
    [SerializeField]
    private Text _catCandyText;
    [SerializeField]
    private Text _catDamageText;

    [Header("Background Music")]
    [SerializeField]
    private AudioClip _mainTheme;
    [SerializeField]
    private AudioClip _menuTheme;

    private bool _gameStarted = false;

    void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Physics.IgnoreLayerCollision(9, 10);
        _timeLeft = _gameDuration;
        _scoreScreen.SetActive(false);
        _mainMenu.SetActive(true);
        SoundManager.instance.PlayGameMusic(_menuTheme);

        _dogWinImage.SetActive(false);
        _dogLoseImage.SetActive(false);
        _catWinImage.SetActive(false);
        _catLoseImage.SetActive(false);
        _dogVictoryImage.SetActive(false);
        _catVictoryImage.SetActive(false);
        _drawImage.SetActive(false);

    }

    void Update()
    {
        if (_gameStarted) {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft <= 0) {
                GameManager.Instance.CalculateScores();
            }
        }
    }

    public void CalculateScores() {
        _gameStarted = false;

        Player playerOne = _playerOne.GetComponent<Player>();
        Player playerTwo = _playerTwo.GetComponent<Player>();

        int playerOneScore = playerOne.pickups * _pickupMultiplier;
        int playerTwoScore = playerTwo.pickups * _pickupMultiplier;
        
        playerOneScore -= playerOne.totalDamage;
        playerTwoScore -= playerTwo.totalDamage;

        // print("Player one: " + playerOneScore + " - Player Two: " + playerTwoScore);

        // Populate statistics screen
        _dogCandyText.text = "Candy: " + playerOne.pickups;
        _dogDamageText.text = "Damage: -" + playerOne.totalDamage;
        _catCandyText.text = "Candy: " + playerTwo.pickups;
        _catDamageText.text = "Damage: -" + playerTwo.totalDamage;

        if (playerOneScore > playerTwoScore) {
            //Player 1 won!
            print("Player one won!!!");
            _dogVictoryImage.SetActive(true);
            _dogWinImage.SetActive(true);
            _catLoseImage.SetActive(true);
            
        } else if (playerTwoScore > playerOneScore) {
            //Player 2 won!
            print("Player two won!!!");
            _catVictoryImage.SetActive(true);
            _catWinImage.SetActive(true);
            _dogLoseImage.SetActive(true);
        } else {
            //Both players tied!
            _drawImage.SetActive(true);
            _dogLoseImage.SetActive(true);
            _catLoseImage.SetActive(true);
            print("Both players Tied...");
        }

        _scoreScreen.SetActive(true);
    }

    public void PlayGame(bool isPlayAgain = false) {
        _mainMenu.SetActive(false);

        SoundManager.instance.PlayGameMusic(_mainTheme);
        
        _timeLeft = _gameDuration;
        _playerOne = Instantiate(_playerOne, _playerOneSpawn.transform.position, Quaternion.identity);
        _playerTwo = Instantiate(_playerTwo, _playerTwoSpawn.transform.position, Quaternion.identity);
        _gameStarted = true;
    }

    public void PlayAgain() {
        StartCoroutine(ReloadScene());
        // SceneManager.LoadScene("Level_Design_03");
    }

    public IEnumerator ReloadScene() {
        Scene scene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene.name);

        // Wait for scene to load
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
