using UnityEngine;
using System.Collections;

//using GemSDK.Unity;

public class BaldEagleLiteUserControllerScript : MonoBehaviour {

    public BaldEagleLiteCharacterScript baldEagleLiteCharacter;
	public float upDownInputSpeed=3f;



    //private IGem gem;

    void Start () {
		baldEagleLiteCharacter = GetComponent<BaldEagleLiteCharacterScript> ();

        Debug.Log("Start");
        //GemManager.Instance.Connect();
        Debug.Log("GetGem");
        //gem = GemManager.Instance.GetGem(0);
    }

	void Update(){
		if (Input.GetButtonDown("Jump")) {
			baldEagleLiteCharacter.Soar ();
		}
        /*
		if (Input.GetKeyDown (KeyCode.H)) {
			baldEagleLiteCharacter.Hit ();
		}
        */
		if (Input.GetButtonDown ("Fire1")) {
			baldEagleLiteCharacter.Attack ();
		}
        /*
		if (Input.GetKey (KeyCode.N)) {
			baldEagleLiteCharacter.upDown=Mathf.Clamp(baldEagleLiteCharacter.upDown-Time.deltaTime*upDownInputSpeed,-1f,1f);
		}
		if (Input.GetKey (KeyCode.U)) {
			baldEagleLiteCharacter.upDown=Mathf.Clamp(baldEagleLiteCharacter.upDown+Time.deltaTime*upDownInputSpeed,-1f,1f);
		}
        */
	}
	
    /*
    Quaternion GetGemRotation()
    {
        if (gem != null)
        {
            return gem.Rotation;
        }
        else
        {
            return Quaternion.identity;
        }
    }
    */

	void FixedUpdate(){
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

        /*
        if (gem != null)
        {
            if (Input.GetMouseButton(0))
            {
                gem.CalibrateAzimuth();
            }
        }

        Quaternion rot = GetGemRotation();

        baldEagleLiteCharacter.forwardAcceleration = rot.x;
        baldEagleLiteCharacter.yawVelocity = rot.z;
        */

        baldEagleLiteCharacter.forwardAcceleration = v;
        baldEagleLiteCharacter.yawVelocity = h;
    }

    void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
        //GemManager.Instance.Disconnect();
    }

    void OnApplicationPause(bool paused)
    {
        Debug.Log("OnPause");
        /*
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("OnPause Android");
            if (paused)
            {
                GemManager.Instance.Disconnect();
            }
            else
            {
                GemManager.Instance.Connect();
            }
        }
        */
    }

}
