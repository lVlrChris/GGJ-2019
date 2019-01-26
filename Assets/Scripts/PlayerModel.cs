using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public int playerNr = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal_P" + playerNr);
        float yInput = Input.GetAxis("Vertical_P" + playerNr);
        
        if (xInput != 0 || yInput != 0) {
            transform.rotation = Quaternion.LookRotation(new Vector3(xInput, 0 , yInput));
        }
    }
}
