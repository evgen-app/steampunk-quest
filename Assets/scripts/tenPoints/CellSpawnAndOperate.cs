using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawnAndOperate : MonoBehaviour
{
  private GameObjectWithFlag[,] _checkedMatrix = new GameObjectWithFlag[4, 4];
  [SerializeField]
  private GameObject _uncheckedButton;
  [SerializeField]
  private GameObject _checkedButton;
  private Canvas uiParent;
  private GameObject tagget;
  void Start() {
    Vector3 startPos = GameObject.FindGameObjectWithTag("tenpoints_startpos").transform.position;
    tagget = GameObject.FindGameObjectWithTag("tenpoints_tagget");
    uiParent = Object.FindObjectOfType<Canvas>();
    for (int i = 0; i < 4; ++i) {
      for (int j = 0; j < 4; ++j) {
        Vector3 pos = new Vector3(
          startPos.x - 150 * i,
          startPos.y - 150 * j,
          0
        );
        _checkedMatrix[i, j] = new GameObjectWithFlag(Instantiate(_uncheckedButton, Vector3.zero, Quaternion.identity), false);
        _checkedMatrix[i, j].gameObject.transform.SetParent(uiParent.transform);
        _checkedMatrix[i, j].gameObject.transform.position = pos;
        _checkedMatrix[i, j].gameObject.transform.SetSiblingIndex(4);
      }
    }
  }
  public void checkButton(Vector3 position) {
    operateOnButton(position, true);
  }
  public void uncheckButton(Vector3 position) {
    operateOnButton(position, false);
  }
  public List<GameObject> getNotCheckedButtons() {
    List<GameObject> result = new List<GameObject>();
    for (int i = 0; i < 4; ++i) {
      for (int j = 0; j < 4; ++j) {
        if (_checkedMatrix[i, j].isChecked == false) {
          result.Add(_checkedMatrix[i, j].gameObject);
        }
      }
    }
    result.Add(tagget);
    return result;
  }
  void operateOnButton(Vector3 position, bool check) {
    for (int i = 0; i < 4; ++i) {
      for (int j = 0; j < 4; ++j) {
        if (_checkedMatrix[i, j].gameObject.transform.position == position) {
          _checkedMatrix[i, j].isChecked = check;
          if (check){
            Destroy(_checkedMatrix[i, j].gameObject);
          }
          _checkedMatrix[i, j].gameObject = Instantiate(check ? _checkedButton : _uncheckedButton, position, Quaternion.identity);
          if (check) {
            _checkedMatrix[i, j].gameObject.GetComponent<CrossButtonHandler>()._isInCell = true;
          }
          _checkedMatrix[i, j].gameObject.transform.SetParent(uiParent.gameObject.transform);
          _checkedMatrix[i, j].gameObject.transform.SetSiblingIndex(4);
        }
      }
    }
  }
}

struct GameObjectWithFlag {
  public GameObject gameObject;
  public bool isChecked;
  public GameObjectWithFlag(GameObject gameObject, bool isChecked) {
    this.gameObject = gameObject;
    this.isChecked = isChecked;
  } 
}
