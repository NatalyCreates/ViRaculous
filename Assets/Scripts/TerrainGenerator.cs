using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {

	public GameObject terrainPrefab;

	// Use this for initialization
	void Start () {
		GameObject ground = GameObject.FindWithTag("Ground");
		Transform rt = ground.transform;

		for (int i = 0; i < 600; i++)
		{
			float xBound = (int) (0.5 * ground.GetComponent<Renderer>().bounds.size.x);
			float zBound = (int) (0.5 * ground.GetComponent<Renderer>().bounds.size.z);
			float xVal = Random.Range(-xBound, xBound);
			float zVal = Random.Range(-zBound, zBound);
			float yVal = -2f;
			//yVal = 300f;

			/*
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Mountains"))
            {
                yVal = g.gameObject.GetComponent<Terrain>().SampleHeight(new Vector3(xVal, 0, zVal));
            }*/
			Instantiate(terrainPrefab, new Vector3(xVal, yVal, zVal), Quaternion.Euler(0f, 0f, 0f));//y+5f
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
