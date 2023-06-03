using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlSideButtons : MonoBehaviour
{
    public GameObject leftButton;
    public GameObject rightButton;

    void Start()
    {
        if(PlayerPrefs.GetString("ControlSideKey") == "right")
        {
            toggleButtonColors("right");
        }
    }

    public void setControlSide(string side)
    {
        PlayerPrefs.SetString("ControlSideKey", side);
        PlayerPrefs.Save();
        toggleButtonColors(side);
    }

    void toggleButtonColors(string side)
    {
        Color inactive = new Color (0.976f, 0.976f, 0.976f, 1.000f);
        Color active = new Color (0.490f, 0.788f, 0.369f, 1.000f);
        if(side == "left")
        {
            leftButton.GetComponent<Image>().color = active;
            leftButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = inactive;

            rightButton.GetComponent<Image>().color = inactive;
            rightButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = active;
        }
        else
        {
            leftButton.GetComponent<Image>().color = inactive;
            leftButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = active;

            rightButton.GetComponent<Image>().color = active;
            rightButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = inactive;
        }


    }
}
