using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapController : MonoBehaviour
{
    [SerializeField] GameObject filter;
    [SerializeField] GameObject indicatorFill;
    [SerializeField] Text percents;

    [SerializeField] List<GameObject> pices;
    public int mapStatus;
    public void changeMapStatus(int newStatus)
    {
        pices[mapStatus].SetActive(false);
        pices[newStatus].SetActive(true);
        percents.text = ((3 - newStatus) * 25).ToString() + "%";
        indicatorFill.GetComponent<RectTransform>().sizeDelta = new Vector2 (17.5262f, 42f * (3 - newStatus)/4f);
        mapStatus = newStatus;
    }
    public void onMapBtnClick()
    {
        gameObject.SetActive(true);
        filter.SetActive(true);
    }
    public void onExitMapClick()
    {
        gameObject.SetActive(false);
        filter.SetActive(false);

    }
}
