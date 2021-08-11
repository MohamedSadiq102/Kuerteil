using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] GameObject deathFX;

   [SerializeField] GameObject hitVFX;
   
   [SerializeField] int scorePerHit = 15;
   [SerializeField] int hitPoints = 2;

   ScoreBoard scoreBoard;
   GameObject parentGameObject;


   void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigitBody();

    }

     void AddRigitBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntimeA");
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        // After collising should print something
        // Debug.Log($"{name} has been hitted! by {other.gameObject.name}");

        ProcessHit();
        if(hitPoints < 1)
        {
            DestroyEnemy();
        }
        
    }

    // the Method to store the score for the whole game
    void ProcessHit()
    {
        GameObject storeVFX = Instantiate(hitVFX, transform.position, Quaternion.identity);
        storeVFX.transform.parent = parentGameObject.transform;
        hitPoints --;
    }

    // The Methode to destory the enemy after shooting him or collision with him
    void DestroyEnemy()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject storeFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        storeFX.transform.parent = parentGameObject.transform;
        // Destroy the enemies after collisioning
        Destroy(gameObject);
    }
}


