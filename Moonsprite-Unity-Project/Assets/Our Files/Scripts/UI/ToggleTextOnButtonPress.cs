using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToggleTextOnButtonPress : MonoBehaviour
{
    public TextMeshProUGUI buttonText;

    void Start()
    {
        //textDown.alpha = 0;
    }

    public void ShowDown()
    {
        //textUp.alpha = 0;
        //textDown.alpha = 1;

        RectTransform rectTransform = buttonText.GetComponent<RectTransform>();
        rectTransform.position += new Vector3(+5, -5, 0);
    } 

    public void ShowUp()
    {
        //textUp.alpha = 1;
        //textDown.alpha = 0;

        RectTransform rectTransform = buttonText.GetComponent<RectTransform>();
        rectTransform.position += new Vector3(-5, +5, 0);
    }
}
