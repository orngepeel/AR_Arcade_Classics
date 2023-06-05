using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadControlSide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("ControlSideKey") == "right")
        {
            RectTransform dpadLocation = GetComponent<RectTransform>();
            dpadLocation.anchorMin = new Vector2(1, 0);
            dpadLocation.anchorMax = new Vector2(1, 0);
            dpadLocation.anchoredPosition = new Vector2(-300, 300);
        }
    }

}
