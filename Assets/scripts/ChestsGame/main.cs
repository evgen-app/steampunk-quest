using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System.Linq;
using System;
public class main : MonoBehaviour
{
    [SerializeField] List<GameObject> chests;
    [SerializeField] GameObject chestWidthLamp;
    [SerializeField] GameObject button;

    ARRaycastManager raycastManager;
    Text status;
    bool spawnedchest = false;
    bool search = true;
    public List<ARRaycastHit> hits;
    bool isTracking = false; //эта переменная state отслеживаемого лучем объекта
    GameObject rayRecObj;
    
    void Start()
    {
        raycastManager = gameObject.GetComponent<ARRaycastManager>();
        status = FindObjectOfType<Text>();
    }

    void Update()
    {
       
        detectPLanes();
        openChest();
    }
    private void spawnChests(Vector3 hitPos)
    {
         GameObject obj;
        List<Vector3> cords = new List<Vector3>{
            new Vector3(hitPos.x + 0.7f, hitPos.y, hitPos.z + 0.2f),
            new Vector3(hitPos.x - 0.7f, hitPos.y, hitPos.z + 0.2f),
            new Vector3(hitPos.x + 0.3f, hitPos.y, hitPos.z + 0.1f),
            new Vector3(hitPos.x - 0.3f, hitPos.y, hitPos.z + 0.1f),
            new Vector3(hitPos.x , hitPos.y, hitPos.z)
        };
        for (int i = 0; i <= cords.Count+1; i++) { 
            GameObject chest = chests[UnityEngine.Random.Range(0, chests.Count)];
            //GameObject chest = chests[0];


            int index = UnityEngine.Random.Range(0, cords.Count-1);
            obj = Instantiate(chest, position: cords[index], rotation: new Quaternion());
            obj.name = "chest" + i.ToString();
            cords.RemoveAt(index);
        }
         obj = Instantiate(chestWidthLamp, position: cords[0], rotation: new Quaternion());
        obj.name = "chest 5";

    }
    private void detectPLanes()
    {
        hits = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count == 0 && search == true)
        {
            status.text = "Идет поиск плоскости" + string.Concat(Enumerable.Repeat(".", UnityEngine.Random.RandomRange(1, 3)));
        }
        else
        {
            search = false;
            if (spawnedchest == false && hits.Count > 0)
            {
                status.text = "spawned chest";
                spawnedchest = true;
                spawnChests(hits[0].pose.position);
            }
        }
    }
    private void openChest()
    {

        Ray ray = new Ray(gameObject.transform.GetChild(0).transform.position, gameObject.transform.GetChild(0).transform.forward);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            status.text = "ray";
            if (raycastHit.collider.gameObject.tag == "chest")
            {
                if (isTracking == false)
                {
                    isTracking = true;
                    rayRecObj = raycastHit.collider.gameObject;
                    //устанавливаем подсветку объекта + добавляем кнопку открыть
                    PlayerPrefs.SetInt("chestNumber", Convert.ToInt32(rayRecObj.name.Substring(5)));
                    rayRecObj.GetComponent<Outline>().enabled = true;
                    button.SetActive(true);
                    status.text = "chest";
                }
                status.text = "chest";

                //raycastHit.collider.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                resetIsTracking();
            }
        }
        else{
            resetIsTracking();
        }
    }
    private void resetIsTracking()
    {
        if (isTracking == true)
        {
            isTracking = false;
            //сбрасываем подсветку объекта + убираем кнопку открыть
            status.text = "no chest";
            rayRecObj.GetComponent<Outline>().enabled = false;
            button.SetActive(false);

        }
    }
    public void openBloha()
    {
        Debug.LogError("SCENE");
        SceneManager.LoadScene("BlohaGame", LoadSceneMode.Additive);
    }
}
