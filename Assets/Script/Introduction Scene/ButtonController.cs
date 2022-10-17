using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject[] buttonToDeactivate;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject ButtonToDeactivate in buttonToDeactivate)
        {
            ButtonToDeactivate.gameObject.SetActive(false);
            //Debug.Log("change foreach");
        }

    }


 
}
