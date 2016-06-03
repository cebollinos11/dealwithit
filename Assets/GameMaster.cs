using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    Object[] pickUps;
    [SerializeField]
    Transform[] spawnpoints;

    [SerializeField]
    float pickUpFreq;
    float pickUpCounter;

    [SerializeField]
    float glassesFreq;
    float glassesCounter;

    glassesSpawner gS;

    CamaraManager cam;

	// Use this for initialization
	void Start () {
        pickUps = Resources.LoadAll("PickUps/");
        gS = GameObject.FindObjectOfType<glassesSpawner>();
        cam = GameObject.FindObjectOfType<CamaraManager>();

        pickUpCounter = pickUpFreq;
        glassesCounter = glassesFreq;
	}

    void SpawnPickUp()
    {
        int d = Random.Range(0, pickUps.Length);

        int d2 = Random.Range(0, spawnpoints.Length);
        Vector3 spawnpoint = spawnpoints[d2].position;

        GameObject item = (GameObject) Instantiate(pickUps[d], spawnpoint, Quaternion.identity) ;

        Vector2 direction = new Vector2(1f, 0);
        if (spawnpoint.x > 0f)
            direction *= -1f;

        item.GetComponent<pickup>().direction = direction;
    }

    public void PlayerCapturedGlasses(GameObject who)
    {
        cam.ZoomIn();
        cam.FollowPlayer(who.transform);
        who.GetComponent<PowerUpManager>().GetGlasses();

        PlayerController[] pc = GameObject.FindObjectsOfType<PlayerController>();
        for (int i = 0; i < pc.Length; i++)
        {
            pc[i].GetComponent<Rigidbody2D>().isKinematic = true;
            pc[i].blockMovement = 1f;
            
        }

        Invoke("ContinueGame", 1f);
    }

    void ContinueGame()
    {
        cam.ResetCamera();
        PlayerController[] pc = GameObject.FindObjectsOfType<PlayerController>();
        for (int i = 0; i < pc.Length; i++)
        {
            pc[i].GetComponent<Rigidbody2D>().isKinematic = false;

        }

    }

	
	// Update is called once per frame
	void Update () {
        pickUpCounter -= Time.deltaTime;
        if (pickUpCounter < 0f)
        {
            SpawnPickUp();
            pickUpCounter = pickUpFreq;
            //gS.SpawnGlasses();
        }

        glassesCounter -= Time.deltaTime;
        if (glassesCounter < 0f)
        {
            gS.SpawnGlasses();
            glassesCounter = glassesFreq;
            //gS.SpawnGlasses();
        }
	}
}
