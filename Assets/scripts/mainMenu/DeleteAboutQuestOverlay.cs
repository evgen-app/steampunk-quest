using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteAboutQuestOverlay : MonoBehaviour
{
  void Start() {
    Button btn = gameObject.GetComponent<Button>().GetComponent<Button>();
    btn.onClick.RemoveAllListeners();
    btn.onClick.AddListener(handleClick);

  }

  public void handleClick() {
    Debug.Log("fuck");
    Destroy(gameObject.transform.parent.gameObject);
  }
}
