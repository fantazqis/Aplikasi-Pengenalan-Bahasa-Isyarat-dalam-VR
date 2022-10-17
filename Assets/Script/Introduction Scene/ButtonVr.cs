using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonVr : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    [Header("Modified Button")]
    public GameObject buttonToDissapear1;
    public GameObject buttonToDissapear2;
    public GameObject buttonToAppear1;
    public GameObject buttonToAppear2;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void ChangeSceneByName(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        StartCoroutine(ChangeScene(sceneName));
    }

    public void ChangeButton()
    {
        StartCoroutine(TimeDelay());
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(0.5f);
        buttonToDissapear1.gameObject.SetActive(false);
        buttonToDissapear2.gameObject.SetActive(false);
        buttonToAppear1.gameObject.SetActive(true);
        buttonToAppear2.gameObject.SetActive(true);
    }

    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
