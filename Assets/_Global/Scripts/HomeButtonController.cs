using UnityEngine;
using System.Collections;

public class HomeButtonController : MonoBehaviour {

    public Animator homeButtonAnimator;
    public SceneNavController snc;

    // Use this for initialization
    void Start () {
        homeButtonAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        homeButtonAnimator.SetTrigger("isHit");
        //SendMessageUpwards("triggerHomeButtonAnimation");
        Debug.Log("HomeButtonController : Home Button pressed");
    }

    void homeButtonAnimationDone()
    {
        Debug.Log("Home Button animation ended");
        snc.homeButtonAnimationDone();
        Debug.Log("Message sent upwards");
    }
}
