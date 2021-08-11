using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    // void OnCollisionEnter(Collision other) 
    // {
    //     Debug.Log(this.name + "--Collided with--" + other.gameObject.name);
    // }

    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;



    void OnTriggerEnter(Collider other) {
        // Debug.Log($"{this.name} --Triggered by-- {other.gameObject.name}");
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
 