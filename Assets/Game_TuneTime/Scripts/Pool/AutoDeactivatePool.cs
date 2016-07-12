using UnityEngine;
using System.Collections;
 
public class AutoDeactivatePool : MonoBehaviour
{
	
	private ObjectPooling pooling;
	
	void Start()
	{
		
        pooling = GameObject.Find("Emitter").GetComponent<ObjectPooling>();

    }
	
	void Update()
	{
		
		if(GetComponent<HitObject>().isDead)
		{
			pooling.DevolveInstance(gameObject);
		}
		
	}
	
}