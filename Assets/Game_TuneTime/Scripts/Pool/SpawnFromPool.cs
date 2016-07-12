using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class SpawnFromPool : MonoBehaviour
{
	
	public float releaseInterval = 1.0f;
	
	private ObjectPooling pool;
	private GameObject go;
	
	private struct QueueItem
	{
		public string name;
	}
	
	private List<QueueItem> _queue = new List<QueueItem>();
	private bool _canRelease = true;
	
	private float _timeOfLastFrame = 0.0f;
	public float timeout = 3.0f;
	
	private float _timeOfLastIdle = 0.0f;
	public float idleMinTimeout = 3.0f;
	
	
	void Start()
	{
		
		pool = GameObject.Find("Emitter").GetComponent<ObjectPooling>();
		
	}
	
	void Update()
	{
		
		if(Input.GetKeyDown(KeyCode.Return))
		{
            SpawnNewObject();
        }
		
		float timeSinceLastFrame = Time.time - _timeOfLastFrame;
        if (timeSinceLastFrame > timeout)
        {
			ProcessIdle();
        }
		
		ProcessQueue();
		
	}
	
	private void ProcessIdle()
	{
		
		float timeSinceLastIdle = Time.time - _timeOfLastIdle;
        if (timeSinceLastIdle > idleMinTimeout)
        {
			
			idleMinTimeout = Random.Range(timeout, timeout * 2);
            SpawnNewObject();
            _timeOfLastIdle = Time.time;
			
        }
	
	}
	
	private Vector3 getRandomSpawnPoint()
	{
        return new Vector3(Random.Range(0, 1920f), 0f, 0f);	
	}
	
	
	private void ProcessQueue()
	{
        int speed = Random.Range(100, 400);
		
		if(_queue.Count > 0 && _canRelease)
		{
			
			_timeOfLastFrame = Time.time;
			
			go = pool.RetrieveInstance();
			
			if (go) 
			{

                go.GetComponent<HitObject>().Release(getRandomSpawnPoint(), speed);
                _queue.RemoveAt(0);
				
				StartCoroutine(startReleaseInterval());
				
			}
			else
			{
				//Debug.Log("There are no items to spawn.");	
			}
			
		}
		
	}
	
	IEnumerator startReleaseInterval()
	{
		
		_canRelease = false;
		yield return new WaitForSeconds(releaseInterval);
		_canRelease = true;
		
	}
	
	public void SpawnNewObject()
	{
		
		QueueItem item;
        item.name = "name";
		_queue.Add(item);
	
	}
	
}