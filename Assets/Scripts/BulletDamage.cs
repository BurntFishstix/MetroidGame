using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletDamage : MonoBehaviour
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
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Final")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            audioManager.PlaySFX(audioManager.hitagain);
            SceneManager.LoadScene("WinScreen");

        }
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            audioManager.PlaySFX(audioManager.hitagain);
        }

        if (collision.gameObject)
        {
            Destroy(this.gameObject);
        }
    }
}
