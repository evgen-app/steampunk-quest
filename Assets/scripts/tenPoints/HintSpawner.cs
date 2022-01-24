using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSpawner : MonoBehaviour
{
  public CrossButtonHandler activeButton;

  private CellSpawnAndOperate _cellOperator;
  private GameObject _hint;
  [SerializeField]
  private GameObject _spawnerHint;
  private GameObject _activeButtonSpawner;
  [SerializeField]
  private GameObject _hintUi;
  private int _idxBuffer = -1;
  List<GameObject> _notCheckedButtons;

  void Start() {
    _notCheckedButtons = new List<GameObject>();
    _cellOperator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CellSpawnAndOperate>();
    _activeButtonSpawner = GameObject.FindGameObjectWithTag("tenpoints_activeButtonSpawner");
  }

  int NearestGameObject() {
    int idx = -1;
    int counter = 0;
    double minDist = Mathf.Infinity;
    foreach(GameObject point in _notCheckedButtons) {
      double dist = Vector3.Distance(point.transform.position, activeButton.transform.position);
      if (dist < minDist) {
        idx = counter;
        minDist = dist;
      }
      counter++;
    }
    return idx;
  }
  void hintSpawn(int idx) {
    if (idx == _notCheckedButtons.Count - 1) {
      _hint = Instantiate(_spawnerHint, _spawnerHint.transform.position, Quaternion.identity);
      Canvas canv = Object.FindObjectOfType<Canvas>();
      _hint.transform.SetParent(canv.gameObject.transform, false); 
      activeButton.GetComponent<CrossButtonHandler>().isSpawnerHint = true;
    }
    else {
      _hint = Instantiate(_hintUi, _notCheckedButtons[idx].transform.position, Quaternion.identity);
      Canvas canv = Object.FindObjectOfType<Canvas>();
      _hint.transform.SetParent(canv.gameObject.transform); 
      activeButton.GetComponent<CrossButtonHandler>().isSpawnerHint = false;
    }
  }

  void Update() {
    _notCheckedButtons = _cellOperator.getNotCheckedButtons();
    if (!activeButton) return;
    int idx = NearestGameObject();
    if (_idxBuffer == idx) {
      return;
    }
    _idxBuffer = idx;
    if (_hint) {
      Destroy(_hint);
    }
    hintSpawn(idx);
  }

  public Vector3 destroyHintAndReturnItsPosition() {
    Debug.Log(_hint.transform.position);
    Vector3 hint_position = _hint.transform.position;
    Destroy(_hint);
    _hint = null;
    _idxBuffer = -1;
    return hint_position;
  }
}
