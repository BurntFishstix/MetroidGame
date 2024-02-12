using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;
    public TextMeshProUGUI livesText;
    public bool isInvincible = false;
    public bool hardMode = false;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        livesText.text = "Lives: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsInvincible // Add property to control invincibility
    {
        get { return isInvincible; }
        set { isInvincible = value; }
    }

    public bool HardMode
    {
        get { return hardMode; }
        set { hardMode = value; }
    }


    public void TakeDamage(int damage)
    {
        if (hardMode)
        {
            damage = 3;
            health -= damage;
        }
        if (!isInvincible && !hardMode)
        {
            health -= damage;
            livesText.text = "Lives: " + health;
        }
        else if (isInvincible)
        {
            livesText.text = "Lives: " + health;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("LoseScreen");
        }
    }
    
}
