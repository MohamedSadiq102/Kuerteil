using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer2 : MonoBehaviour
{

    void Awake() 
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer2>().Length;
        if(numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
