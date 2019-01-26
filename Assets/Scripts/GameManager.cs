using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // GameManager is a singleton instance.
    public static GameManager instance = null;

    [SerializeField]
    private float _gameDuration = 180;

    void Awake() {
        if (instance = null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameTimeRoutine(_gameDuration));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GameTimeRoutine(float duration) {
        yield return new WaitForSecondsRealtime(duration);

    }
}
