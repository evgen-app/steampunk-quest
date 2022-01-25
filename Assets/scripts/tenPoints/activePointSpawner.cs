using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePointSpawner : MonoBehaviour
{
  [SerializeField]
  private GameObject activePoint;
  private GameObject[] activePoints;
  private Canvas ui_output;
  private int length = 10;
  void Start() {
    ui_output = Object.FindObjectOfType<Canvas>();
    activePoints = new GameObject[10];
    for (int i = 0; i < 10; ++i) {
      activePoints[i] = Instantiate(activePoint, 
      new Vector3(
          transform.position.x + (135 * ((i)%7)),
          transform.position.y - (135 * ((int)(i)/7)),
          0
        ),
        Quaternion.identity
      );
      activePoints[i].transform.SetParent(ui_output.transform);
      activePoints[i].transform.parent.SetSiblingIndex(6);
    }
  }

  public void delete() {
    length--;
    Destroy(activePoints[length]);
  }
  public void add() {
    activePoints[length] = Instantiate(activePoint, 
    new Vector3(
          transform.position.x + (135 * ((length)%7)),
          transform.position.y - (135 * ((int)(length)/7)),
          0
      ),
      Quaternion.identity
    );
    activePoints[length].transform.SetParent(ui_output.transform);
    length++;
  }
}
