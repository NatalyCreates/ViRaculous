using UnityEngine;
using System.Collections;

public class EagleControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("Jump") || Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            Debug.Log("what");
            //baldEagleLiteCharacter.Soar();
        }
        if (Input.GetKeyDown("Jump"))
        {
            Debug.Log("what");
            //baldEagleLiteCharacter.Soar();
        }
    }
}
