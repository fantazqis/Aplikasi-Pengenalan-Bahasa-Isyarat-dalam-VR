using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AlphabetKeyboardButton : MonoBehaviour
{
    AlphabetKeyboardFunction alphabetKeyboardFunction;
    TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {
        alphabetKeyboardFunction = GetComponentInParent<AlphabetKeyboardFunction>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText.text.Length == 1)
        {
            NameButtonText();
            GetComponentInChildren<ButtonVr>().onRelease.AddListener(delegate { alphabetKeyboardFunction.InsertChar(buttonText.text); });
        }
    }

    public void NameButtonText()
    {
        buttonText.text = gameObject.name;
    }
}
