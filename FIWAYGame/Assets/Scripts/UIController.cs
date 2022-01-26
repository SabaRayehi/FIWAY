using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text TimerText, LifeText, WonHealthText, WonLevelsText;
    public Image[] IconPlaces;
    public Sprite[] Images;
    public Image LifeImage;


    public void UpdateHealth(int iHealth)
    {
        LifeText.text = iHealth.ToString();
        if (iHealth <= 0)
        {
            LifeImage.enabled = false;
            LifeText.enabled = false;
        }
        else
        {
            LifeImage.enabled = true;
            LifeText.enabled = true;
        }

    }
    public void UpdateTimer(int iTime)
    {
        TimerText.text = string.Format("{0}:{1}", Mathf.RoundToInt(iTime / 60), iTime - Mathf.RoundToInt(iTime / 60) * 60);
    }
    public void UpdateUI()
    {
        PlayerActions AC = GameObject.Find("PlayerActions").GetComponent<PlayerActions>();
        int i;
        for (i = 0; i < AC.actions.Count; i++)
        {
            Action a = AC.actions.ToArray()[i];
            IconPlaces[i].sprite = Images[(int)a];
            IconPlaces[i].enabled = true;
        }
        for (int j = i; j < IconPlaces.Length; j++)
        {
            IconPlaces[j].enabled = false;
        }


    }
    public void UpdateWonScreen(int iHealth, int iLevel)
    {
        WonHealthText.text = iHealth.ToString();
        WonLevelsText.text = iLevel.ToString();
    }
}

