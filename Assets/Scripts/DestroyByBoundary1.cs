using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary1 : MonoBehaviour
{


    private void OnTriggerExit (Collider other) 
	{
         
		Destroy(other.gameObject);//other:Bolt object
        
	}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
