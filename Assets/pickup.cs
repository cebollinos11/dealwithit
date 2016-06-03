using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {

    public Vector2 direction;
    float ttl = 10f;
    [SerializeField]
    AudioClip sound;

    protected virtual void OnPickUp(PowerUpManager pum)
    {
        Debug.Log("Pick up");
        pum.DoFlashFast();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0f, 0f, 1f);
        transform.position += new Vector3(direction.x,direction.y,0f)*Time.deltaTime;
        ttl -= Time.deltaTime;
        if (ttl < 0f)
            Destroy(gameObject);
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            AudioManager.PlayClip(sound);
            OnPickUp(col.gameObject.GetComponent<PowerUpManager>());
            Destroy(gameObject);
        }
       

    }
}
