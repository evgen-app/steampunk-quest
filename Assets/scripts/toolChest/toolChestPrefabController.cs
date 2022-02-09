using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;


public class toolChestPrefabController : MonoBehaviour
{
    [SerializeField]
    private GameObject toolChestModel;
    [SerializeField]
    private GameObject sampleBtn;
    [SerializeField]
    private GameObject toolDialogTemplate;
    [Serializable]
    public struct _spriteTool
    {
        public string name;
        public GameObject rawImagePrefab;
    }
    public _spriteTool[] SpriteTools;

    private Dictionary<string, GameObject> dictSpriteTools = new Dictionary<string, GameObject>();

    private GameObject openChestBtn;
    private GameObject takeToolBtn;
    private ARRaycastManager raycastManager;
    private Text status;
    private bool spawnChest;
    private bool detectPlane = false;
    private GameObject _recObj;
    private bool _isTracking;
    private bool openedChestTool = false;
    List<ARRaycastHit> hits;


    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        status = GameObject.FindGameObjectWithTag("status").GetComponent<Text>(); //на main сцене всегда будет текстовая полоска со статусом, по константе
        openChestBtn  = Instantiate(sampleBtn, GameObject.FindGameObjectWithTag("canvas_ui").transform);
        openChestBtn.transform.GetChild(0).GetComponent<Text>().text = "Открыть";
        takeToolBtn = Instantiate(sampleBtn, GameObject.FindGameObjectWithTag("canvas_ui").transform);
        takeToolBtn.transform.GetChild(0).GetComponent<Text>().text = "Взять";

        UnityEngine.Events.UnityAction spawnDialogTakeToolAction = () =>
        {
            spawnDialogTakeTool();
        };


        UnityEngine.Events.UnityAction openBlohaAction = () =>
        {

            SceneManager.LoadScene("BlohaGame", LoadSceneMode.Additive);
            Destroy(openChestBtn);
            openedChestTool = true;
        };



        openChestBtn.GetComponent<Button>().onClick.AddListener(openBlohaAction);
        takeToolBtn.GetComponent<Button>().onClick.AddListener(spawnDialogTakeToolAction);
        
        openChestBtn.SetActive(false);
        takeToolBtn.SetActive(false);

        foreach (_spriteTool i in SpriteTools)
        {
            dictSpriteTools.Add(i.name, i.rawImagePrefab);
        }
    }


    void Update()
    {

        if (spawnChest == true)
        {
            detectPLanes();
            detectObjects();
        }

    }
    private void detectPLanes()
    {
        hits = new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count == 0 && detectPlane == false)
        {
            status.text = "Идет поиск плоскости" + string.Concat(Enumerable.Repeat(".", UnityEngine.Random.RandomRange(1, 3)));
        }
        else
        {
            if (detectPlane == false && hits.Count > 0)
            {
                detectPlane = true;
                status.text = "";
                GameObject chest = Instantiate(toolChestModel, hits[0].pose.position, new Quaternion());
                chest.gameObject.name = "chest5";
            }
        }
    }
    private void detectObjects()
    {
        RaycastHit raycastHit;
        Ray ray = new Ray(raycastManager.gameObject.transform.GetChild(0).transform.position, raycastManager.gameObject.transform.GetChild(0).transform.forward);
        if (Physics.Raycast(ray, out raycastHit) && GameObject.FindGameObjectsWithTag("aim").Length == 0)
        {
            Debug.Log(raycastHit.collider.gameObject.name + " brrr");
            if (raycastHit.collider.gameObject.tag == "chest" && openedChestTool == false)
            {
                if (_isTracking == false)
                {
                    _isTracking = true;
                    _recObj = raycastHit.collider.gameObject;
                    PlayerPrefs.SetInt("chestNumber", Convert.ToInt32(_recObj.name.Substring(5)));
                    _recObj.GetComponent<Outline>().enabled = true;
                    openChestBtn.SetActive(true);
                }
            }
            else if (raycastHit.collider.gameObject.tag == "tool")
            {
                if (_isTracking == false)
                {
                    _isTracking = true;
                    _recObj = raycastHit.collider.gameObject;
                    _recObj.GetComponent<Outline>().enabled = true;
                    takeToolBtn.SetActive(true);
                    status.text = _recObj.GetComponent<toolController>().toolName;

                }
            }
            else
            {
                resetIsTracking();
            }
        }
        else
        {
            resetIsTracking();
        }
    }
    private void resetIsTracking()
    {
        if (_isTracking == true)
        {
            status.text = ".";
            _isTracking = false;
            _recObj.GetComponent<Outline>().enabled = false;
            if (openChestBtn != null && takeToolBtn != null)
            {
                openChestBtn.SetActive(false);
                takeToolBtn.SetActive(false);
            }


        }
    }
    void spawnDialogTakeTool()
    {
        GameObject toolDialog = Instantiate(toolDialogTemplate, GameObject.FindGameObjectWithTag("canvas_ui").transform);
        toolDialog.transform.GetChild(0).GetComponent<Text>().text = "Вы нашли: " + _recObj.GetComponent<toolController>().toolName;
        Instantiate(dictSpriteTools[_recObj.GetComponent<toolController>().toolName], toolDialog.transform);
        takeToolBtn.SetActive(false);

        if (_recObj.GetComponent<toolController>().toolName != "Гаечный ключ")
        {
           GameObject OKbtn = Instantiate(sampleBtn, toolDialog.transform);
           OKbtn.GetComponent<RectTransform>().pivot = new Vector2(0.5f, -1.66f);
           OKbtn.transform.GetChild(0).GetComponent<Text>().text = "OK";
            UnityEngine.Events.UnityAction destroyDialogAction = () =>
            {
                destroyDialog();
            };

   OKbtn.GetComponent<Button>().onClick.AddListener(destroyDialogAction);
        }
        else
        {
            GameObject useWrenchBtn = Instantiate(sampleBtn, toolDialog.transform);
            useWrenchBtn.GetComponent<RectTransform>().pivot = new Vector2(0.5f, -1.66f);
            useWrenchBtn.transform.GetChild(0).GetComponent<Text>().text = "Использовать";

            UnityEngine.Events.UnityAction useWrenchAction = () =>
            {
                useWrench();
            };

            useWrenchBtn.GetComponent<Button>().onClick.AddListener(useWrench);
        }
        Destroy(_recObj);
    }
  

    public void spawnChestTool()
    {
        spawnChest = true;
    }
    public void useWrench()
    {
        //открывается кручение гаек
    }
    public void destroyDialog()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("dialog_canvas"));
    }

}
