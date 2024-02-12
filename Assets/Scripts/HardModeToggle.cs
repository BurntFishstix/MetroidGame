using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardModeToggle : MonoBehaviour
{
    public Toggle hardModeToggle;
    public PlayerHealth playerHealth;
    public GameObject hardText;

    void Start()
    {
        // Set the toggle to reflect the initial state of invincibility
        hardModeToggle.isOn = playerHealth.HardMode;
    }

    // Called when the toggle state changes
    public void OnToggleHard(bool invincible)
    {
        playerHealth.HardMode = true;
        hardText.SetActive(true);
    }
}
