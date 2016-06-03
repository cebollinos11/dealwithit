using UnityEngine;
using System.Collections;

public class CamaraManager : MonoBehaviour {

    Camera cam;
    float originalSize;
    float originalZ;
    bool followingPlayer;
    Transform targetToFollow;

    float targetZoom;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        originalSize = cam.orthographicSize;
        targetZoom = originalSize;
        originalZ = cam.transform.position.z;

        Transform fol = GameObject.FindObjectOfType<PlayerController>().transform;
        
	}

    public void ResetCamera()
    {
        followingPlayer = false;
        transform.position = new Vector3(0, 0, originalZ);
        targetZoom = originalSize;
    }

    public void FollowPlayer(Transform who)
    {
        followingPlayer = true;
        targetToFollow = who;
    }

    public void ZoomIn()
    {
        targetZoom = 1f;
    }


	
	// Update is called once per frame
	void Update () {

        if(followingPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, targetToFollow.position,0.5f);
            transform.position = new Vector3(transform.position.x, transform.position.y, originalZ);
            Debug.Log(targetToFollow.position);
        }


        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, 0.1f);
	    
	}
}
