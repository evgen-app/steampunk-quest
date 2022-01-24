using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeActiveButtonScript : MonoBehaviour
{
  private activePointSpawner _pointSpawner;
  [SerializeField]
  private CrossButtonHandler _notFakeButton;
  private Canvas canvas;
  void Start() {
    _pointSpawner = Object.FindObjectOfType<activePointSpawner>();
    canvas = Object.FindObjectOfType<Canvas>();
  }
  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      if(Vector3.Distance(transform.position, Input.mousePosition) < 100) {
        _pointSpawner.delete();
        GameObject obj = Instantiate(_notFakeButton.gameObject, Input.mousePosition, Quaternion.identity);
        obj.transform.SetParent(canvas.gameObject.transform);
        obj.GetComponent<CrossButtonHandler>().active = true;
      }
    }
  }
}
