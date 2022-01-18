using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutQuestClickHandle : MonoBehaviour
{
  [SerializeField]
  private Canvas _overlayLayout;
  public void handleClick() {
    Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    Canvas a = Instantiate(_overlayLayout, Vector3.zero, Quaternion.identity).GetComponent<Canvas>();
    a.renderMode = RenderMode.ScreenSpaceCamera;
    a.worldCamera = mainCamera;
  }

}
