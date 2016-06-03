using UnityEngine;
using System.Collections;

public class glassesSpawner : MonoBehaviour {

    Object glasses;
	// Use this for initialization
	void Start () {
        glasses = Resources.Load("glasses");

	}

    public void SpawnGlasses()
    {
        Instantiate(glasses, transform.position, Quaternion.identity);
    }
}
