using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator1 : MonoBehaviour
{
    // Start is called before the first frame update

    public float tumble;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
