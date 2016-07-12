using UnityEngine;
using System.Collections;

public class HitObject : MonoBehaviour
{

    public bool isDead = false;

    private Vector3 targetPosition;
    public int speed;

	// Use this for initialization
	void Start () {
	
	}
	
    public void Release(Vector3 startPosition, int speed)
    {

        isDead = false;
        this.transform.localPosition = startPosition;
        this.speed = speed;

        targetPosition = new Vector3(startPosition.x, startPosition.y + 1300, startPosition.z);

        GetComponent<Animator>().SetTrigger("Moving");
        StartCoroutine("MoveCoroutine");
    }

    IEnumerator MoveCoroutine()
    {

        while (Vector3.Distance(transform.localPosition, targetPosition) > 5)
        {

            float step = speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, step);

            yield return null;
        }

        //Reached the target
        Reset();

    }

    public void Reset()
    {

        isDead = true;

    }

    public void NoteHit()
    {
        StopCoroutine("MoveCoroutine");
        GetComponent<Animator>().SetTrigger("Hit");
        Debug.Log("NoteHit");
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        NoteHit();
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("MouseUpAsButton");
    }

    void OnClick ()
    {
        Debug.Log("OnMouseClick");
        NoteHit();
    }

}
