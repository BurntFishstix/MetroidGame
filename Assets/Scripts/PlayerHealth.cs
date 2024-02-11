using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;
    public TextMeshProUGUI livesText;
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

    public void TakeDamage(int damage)
    {
        health -= damage;
        livesText.text = "Lives: " + health;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
