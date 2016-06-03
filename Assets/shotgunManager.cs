using UnityEngine;
using System.Collections;

public class shotgunManager : MonoBehaviour {

    [SerializeField]
    Animator shotgunAnimator;

    [SerializeField] ParticleSystem particle;
    [SerializeField]
    AudioClip shootsound;

    int hitsleft;

    void HideMe()
    {
        this.gameObject.SetActive(false);
    }

    

    void OnEnable()
    {
        Debug.Log("Enabled at " + Time.time.ToString());
        hitsleft = 3;
    }

    public void ShootShotgun()
    {
        AudioManager.PlayClip(shootsound);
        particle.Play();
        shotgunAnimator.SetTrigger("Shoot");
        hitsleft--;
        if (hitsleft < 1)
        {
            Invoke("HideMe", 0.2f);
        }
    }
}
