using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact1 : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    int scoreValue = 10;

    private GameController1 gameController;
    
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController1>();
        }
        else
        {
            Debug.LogError("GameController not found! Ensure it has the 'GameController' tag.");
        }
    }

    private void OnTriggerEnter(Collider other) // 🔹 Fix: Changed from OnTriggerExit
    {
        if (other.tag == "Boundary1")
            return;

        // Instantiate explosion effect
        Instantiate(explosion, transform.position, transform.rotation);

        // Ensure gameController is not null before updating the score
        if (gameController != null)
        {
            gameController.AddScore(scoreValue);
        }
        

        // Handle player collision separately
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}