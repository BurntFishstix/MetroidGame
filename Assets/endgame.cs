using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgame : MonoBehaviour
{
     AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    private void End()
    {

        Debug.Log("GameEnd");
            audioManager.PlaySFX(audioManager.buttonHover);
    }

}