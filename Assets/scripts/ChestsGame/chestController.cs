using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            Debug.Log(gameObject.transform.GetChild(0).gameObject.name);
            PlayerPrefs.SetInt(gameObject.name, 2);
            gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            if (gameObject.name == "chest5")
            {
                gameObject.transform.Find("lamp").gameObject.SetActive(true);
            }
        }

    }
}
