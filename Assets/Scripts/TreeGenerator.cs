using UnityEngine;
using System.Collections;

public class TreeGenerator : MonoBehaviour {

	public GameObject treePrefab1;
	public GameObject treePrefab2;
	public GameObject treePrefab3;

	private static GameObject[] treePrefabs;

	// Use this for initialization
	void Start () {
		// Sorry for ugliness, didn't find a way to load all prefabs by label
		treePrefabs = new GameObject[]{ treePrefab1, treePrefab2, treePrefab2 };     
		GameObject ground = GameObject.FindWithTag("Ground");
		Transform rt = ground.transform;

		for (int i = 0; i < 3000; i++)
		{
			float xBound = (int) (0.5 * ground.GetComponent<Renderer>().bounds.size.x);
			float zBound = (int) (0.5 * ground.GetComponent<Renderer>().bounds.size.z);
			float xVal = Random.Range(-xBound, xBound) / 2;
			float zVal = Random.Range(-zBound, zBound) / 2;
			float yVal = -2f;

			GameObject treePrefab = treePrefabs[Random.Range(0, treePrefabs.Length)];
			Instantiate(treePrefab, new Vector3(xVal, yVal, zVal), Quaternion.Euler(0f, 0f, 0f));//y+5f
		}
	}

	// Update is called once per frame
	void Update () {

	}

}
