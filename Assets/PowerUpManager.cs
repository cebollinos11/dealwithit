using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {

    int size = 1;
    int maxSize = 4;

    [SerializeField]
    GameObject Bat;
    [SerializeField]
    GameObject ShotGun,Glasses;

    [SerializeField]
    AudioClip getHit;

    [SerializeField]
    ParticleSystem hitParticles;

    [SerializeField]SpriteRenderer sR;
    Material originalMaterial;

    [SerializeField]
    Material hitmaterial;

    [SerializeField]
    Material powerUpMaterial;

    IEnumerator FlashFast()
    {
        sR.material = powerUpMaterial;
        yield return new WaitForSeconds(0.3f);
        sR.material = originalMaterial;
    }

    public void DoFlashFast()
    {
        StartCoroutine(FlashFast());
    }


    public void StartStagger() {
    
        // put material flashback in
        sR.material = hitmaterial;
    
    }

    public void EndStagger() { 
    
    // put original material in
        sR.material = originalMaterial;
    
    }

    public void GetHit()
    {
        AudioManager.PlayClip(getHit);
        hitParticles.Play();
    }

    void Awake()
    {
        Bat.SetActive(false);
        ShotGun.SetActive(false);
        Glasses.SetActive(false);
    }
	// Use this for initialization
	void Start () {
        originalMaterial = sR.material;
	}

    public void GetGlasses()
    {
        Glasses.SetActive(true);
        
    }

    public void GetBaseball()
    {
        Bat.SetActive(true);
    }

    public void GetShotgun()
    {
        ShotGun.SetActive(true);
    }

    void Update()
    {

       
    }

    public void Resize(int direction)
    {
        size+=direction;
        if (size > maxSize)
            size = maxSize;

        if (size < 0)
            size = 0;

        float targetSize = 0.5f;

        if(size>0)
        {
            targetSize = 0.5f + (float)size / 2.0f;
        }
        transform.localScale = Vector3.one * targetSize;
    }
}
