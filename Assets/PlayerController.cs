using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float walkForce;
    public float baseballHitForce;

    public KeyCode KeyJump;
    public KeyCode KeyLeft;
    public KeyCode KeyRight;

    Rigidbody2D rb;

    bool canJump;
    float faceDirection = 1;

    public float blockMovement;

    PowerUpManager powerupManager;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        powerupManager = GetComponent<PowerUpManager>();
	}

    public void BaseballHit(float dir)
    {
        powerupManager.GetHit();
        Stagger();
        rb.AddForce(new Vector2(baseballHitForce*dir,jumpForce));
    }

    void Stagger()
    {
        powerupManager.StartStagger();
        blockMovement = 1f;

        if(transform.localScale.y>0f)
        {
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }
    }
        

    void Jump()
    {
        if(canJump)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            
            canJump = false;
        }
        
    }

    void Walk(bool dir)
    {
        float direction = 1;
        if (dir == false)
            direction = -1;

        if (direction > 0 && transform.localScale.x < 0)
            transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z);

        if (direction < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        transform.position += direction * new Vector3(walkForce, 0f, 0f) * Time.deltaTime;
    }

	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.F2))
        { BaseballHit(1); }

        if (blockMovement>0f)
        {
            blockMovement -= Time.deltaTime;

            if(blockMovement<=0f)
            {
                if (transform.localScale.y < 0f)
                {
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                }
                powerupManager.EndStagger();
            }
            return;
        }
           

        if (Input.GetKeyDown(KeyJump))
        {
            Jump();
        }

        if(Input.GetKey(KeyLeft))
        {
           Walk(false);
        }

        if (Input.GetKey(KeyRight))
        {
            Walk(true);
        }
        /*
        if(Input.GetKeyDown(KeyCode.Q))
        {
            BaseballHit(-1f);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            BaseballHit(1f);
        }
	*/
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "NoResetJump")
        {
            return;
        }
        canJump = true;
    }

 
}
