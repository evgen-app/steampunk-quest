using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mailController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject filter;
    [SerializeField] GameObject mapDialog;
    [SerializeField] GameObject mapBtn;
    public void onMailBtnClick()
    {
        gameObject.SetActive(true);
        filter.SetActive(true);
    }
    public void onExitMailClick()
    {
        gameObject.SetActive(false);
        filter.SetActive(false);

    }
    public void onOpenMapClick()
    {
        mapDialog.GetComponent<mapController>().changeMapStatus(0);
        mapBtn.SetActive(true);
        mapDialog.SetActive(true);

    }

}
