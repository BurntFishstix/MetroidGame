using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Swap : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
 
        if (SceneManager.GetActiveScene().name == "SampleScene")
            DoNotDestroy.instance.GetComponent<AudioSource>().Pause();
            //BGmusic.instance.GetComponent<AudioSource>().Play();
    }
}