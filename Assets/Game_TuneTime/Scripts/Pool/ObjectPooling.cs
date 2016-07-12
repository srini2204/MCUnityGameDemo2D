using UnityEngine;
using System.Collections;
 
public class ObjectPooling : MonoBehaviour
{
	//set from spawner
	public GameObject[] prefab;
	public int poolSize;
	
	private GameObject[] pool;
	
	void Start()
	{
		
		pool = new GameObject[poolSize];
		
		for (int i = 0; i < poolSize; i++)
		{

            int rand = Random.Range(0, prefab.Length);
			pool[i] = (GameObject)Instantiate (prefab[rand], Vector3.zero, Quaternion.identity);
            pool[i].transform.SetParent(this.transform, false);
			pool[i].SetActive(false);
			
		}
		
	}
	
	public GameObject RetrieveInstance()
	{
		
		foreach (GameObject go in pool)
		{
			
			if (!go.activeSelf)
			{
				go.SetActive(true);
				return go;
			} 
			
		}
		
		return null;
		
	}
	
	public void DevolveInstance(GameObject go)
	{
		
		go.SetActive(false);
		
	}
	
}