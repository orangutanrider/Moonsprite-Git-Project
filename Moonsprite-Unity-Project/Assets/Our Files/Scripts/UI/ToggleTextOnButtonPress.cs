using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToggleTextOnButtonPress : MonoBehaviour
{
    public TextMeshProUGUI textUp;
    public TextMeshProUGUI textDown;

    void Start()
    {
        textUp.alpha = 1;
        textDown.alpha = 0;
    }

    public void ShowUp()
    {
        textUp.alpha = 1;
        textDown.alpha = 0;
    }

    public void ShowDown()
    {
        textUp.alpha = 0;
        textDown.alpha = 1;
    }
}
