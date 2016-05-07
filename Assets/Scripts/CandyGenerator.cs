using UnityEngine;
using System.Collections;

public class CandyGenerator : MonoBehaviour {

    public GameObject cookiePrefab;

    /*
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.fontSize = 30;
        gs.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(100, 100, 300, 300), "aaa", gs);
    }
    */

    // Use this for initialization
    void Start () {
        GameObject ground = GameObject.FindWithTag("Ground");
        Transform rt = ground.transform;

        for (int i = 0; i < 300; i++)
        {
			float xBound = (int) (0.5 * ground.GetComponent<Renderer>().bounds.size.x);
			float zBound = (int) (0.5 * ground.GetComponent<Renderer>().bounds.size.z);
			float xVal = Random.Range(-xBound, xBound) / 100;
			float zVal = Random.Range(-zBound, zBound) / 100;
            float yVal = 0f;
            //yVal = 300f;

			if (xVal < 0 && -500 < xVal) {
				continue;
			}
            /*
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Mountains"))
            {
                yVal = g.gameObject.GetComponent<Terrain>().SampleHeight(new Vector3(xVal, 0, zVal));
            }*/
            Instantiate(cookiePrefab, new Vector3(xVal, yVal + 2f, zVal), Quaternion.Euler(270f, 0f, 0f));//y+5f
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
