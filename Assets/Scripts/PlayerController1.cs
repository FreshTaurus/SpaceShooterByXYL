using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Boundary1 
{
	public float xMin, xMax, zMin, zMax;
}
public class PlayerController1 : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary1 boundary1;

    public GameObject shot;
	public Transform shotSpawn;

    public float fireRate;
	private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
        
        
        //Debug.Log("position of the player: " + GetComponent<Rigidbody>().position);
        //Debug.Log("position in x axis of the player: " + GetComponent<Rigidbody>().position.x);
 
        //write code to print out of bound warning
        GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary1.xMin, boundary1.xMax), 
			0, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary1.zMin, boundary1.zMax)
		);
        GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}