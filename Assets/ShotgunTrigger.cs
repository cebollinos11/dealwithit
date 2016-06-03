using UnityEngine;
using System.Collections;

public class ShotgunTrigger : MonoBehaviour {

    [SerializeField]
    shotgunManager smg;
    
	// Use this for initialization
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            smg.ShootShotgun();

            PlayerController p = col.gameObject.GetComponent<PlayerController>();
            Debug.Log(p);
            if (p == null)
                return;

            if(transform.parent.transform.position.x-p.transform.position.x > 0)
                p.BaseballHit(-1f);
            else{
                p.BaseballHit(1f);
            }
        }
    }
	}

