using UnityEngine;
using System.Collections;

public class BatholderManager : MonoBehaviour {

    [SerializeField]
    Animator batAnimator;

    [SerializeField]
    AudioClip swing;

    int hitsleft;

	// Use this for initialization
	void Start () {
	
	}

    void OnEnable()
    {
        Debug.Log("Enabled at " + Time.time.ToString());
        hitsleft = 3;
    }

    void HideMe()
    {
        this.gameObject.SetActive(false);
    }

    public void SwingBat()
    {
        AudioManager.PlayClip(swing);
        batAnimator.SetTrigger("Hit");
        hitsleft--;
        if (hitsleft < 1)
        {
            Invoke("HideMe", 0.2f);
        }
    }
}
