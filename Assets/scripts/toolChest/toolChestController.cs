using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolChestController : MonoBehaviour
{

    void Start()
    {
        PlayerPrefs.SetInt(gameObject.name, 2);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(-180,0,0);
            PlayerPrefs.SetInt(gameObject.name, 2);
            
            for (int i = 0; i < gameObject.transform.parent.gameObject.transform.childCount; i++)
            {
                gameObject.transform.parent.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
