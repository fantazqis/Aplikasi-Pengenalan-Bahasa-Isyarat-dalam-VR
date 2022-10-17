using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public GameObject[] spriteManager;
    public string[] letterToSpawn;
    public string SpriteToSpawn;

    public void Start()
    {
        Change();
    }

    public void Change()
    {
        //Debug.Log("change spawn 2");
        foreach (GameObject Sprite in spriteManager)
        {
            Sprite.gameObject.SetActive(false);
            //Debug.Log("change foreach");
        }

        //Debug.Log("change spawn");
        SpriteToSpawn = letterToSpawn[Random.Range(0, letterToSpawn.Length - 1)];
        foreach (GameObject Sprite in spriteManager)
        {
            //Debug.Log("change if");
            if (Sprite.name == SpriteToSpawn)
            {
                //Debug.Log("change spawn 3");
                Sprite.gameObject.SetActive(true);
            }
        }

    }
}
