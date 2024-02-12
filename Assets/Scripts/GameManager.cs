using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int normalDamage = 1;
    public int hardDamage = 3;

    private int currentDamage;

    // UI Toggle for hard mode
    public Toggle hardModeToggle;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Check saved preference for hard mode
        if (PlayerPrefs.HasKey("HardMode"))
        {
            bool isHardMode = PlayerPrefs.GetInt("HardMode") == 1;
            hardModeToggle.isOn = isHardMode;
        }
    }

    // Call this method when the toggle is changed
    public void SetHardMode(bool isHardMode)
    {
        if (isHardMode)
        {
            currentDamage = hardDamage;
        }
        else
        {
            currentDamage = normalDamage;
        }

        PlayerPrefs.SetInt("HardMode", isHardMode ? 1 : 0);
        PlayerPrefs.Save();
    }

    // Call this method from your enemy script to get the current damage
    public int GetCurrentDamage()
    {
        return currentDamage;
    }
}