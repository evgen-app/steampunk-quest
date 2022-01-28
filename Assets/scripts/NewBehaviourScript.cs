using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] mapController map;
    public void click()
    {
        if (map.mapStatus == 2)
        {
            map.changeMapStatus(0);
        }
        else
        {
            map.changeMapStatus(map.mapStatus + 1);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
