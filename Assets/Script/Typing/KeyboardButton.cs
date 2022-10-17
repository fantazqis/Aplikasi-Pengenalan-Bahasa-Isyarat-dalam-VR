using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardButton : MonoBehaviour
{
    KeyboardFunction numberKeyboardFunction;
    TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {
        numberKeyboardFunction = GetComponentInParent<KeyboardFunction>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText.text.Length == 1)
        {
            NameButtonText();
            GetComponentInChildren<ButtonVr>().onRelease.AddListener(delegate { numberKeyboardFunction.InsertChar(buttonText.text); });
        }
    }

    public void NameButtonText()
    {
        buttonText.text = gameObject.name;
    }
}
