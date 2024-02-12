using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InvincibilityToggle : MonoBehaviour
{
    

    public Toggle invincibilityToggle;
    public PlayerHealth playerHealth;
    public GameObject invincibleText;

    void Start()
    {
        // Set the toggle to reflect the initial state of invincibility
        invincibilityToggle.isOn = playerHealth.IsInvincible;
    }

    // Called when the toggle state changes
    public void OnToggleInvincibility(bool invincible)
    {
        playerHealth.IsInvincible = true;
        invincibleText.SetActive(true);
    }
}
