using UnityEngine;
using System.Collections;

public class glasses : MonoBehaviour {

    public float downSpeed;
    [SerializeField]
    AnimationCurve sinus;
    float startTime;
    [SerializeField]
    AudioClip sound;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= Time.deltaTime * new Vector3(0f, downSpeed);
        transform.position = new Vector3(sinus.Evaluate((Time.time-startTime)/4)*2f, transform.position.y, transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(col.gameObject.GetComponent<PlayerController>().blockMovement <= 0f)
            {
                AudioManager.PlayClip(sound);
                GameObject.FindObjectOfType<GameMaster>().PlayerCapturedGlasses(col.gameObject);
                Destroy(gameObject);
            }
            //OnPickUp(col.gameObject.GetComponent<PowerUpManager>());
            
        }
    }
}
