using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossButtonHandler : MonoBehaviour
{
  private bool _mouseDown = false;
  private HintSpawner _activePoint;
  public bool active = false;
  private CellSpawnAndOperate _cellOperator;
  public bool _isInCell = false;
  private activePointSpawner _pointSpawner;
  public bool isSpawnerHint = false;
  private GameObject _tagget;
  void Start() {
    _tagget = GameObject.FindGameObjectWithTag("tenpoints_tagget");
    _activePoint = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<HintSpawner>();
    _cellOperator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CellSpawnAndOperate>();
    _pointSpawner = Object.FindObjectOfType<activePointSpawner>(); 
  }
  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      if (Vector3.Distance(Input.mousePosition, gameObject.transform.position) < 100){
        active = true;
        if (_isInCell) {
          _cellOperator.uncheckButton(transform.position);
        }
        else {
          _pointSpawner.delete();
        }
      }    
    }
    if (Input.GetMouseButtonUp(0)) {
      if (active) {
        active = false;
        Vector3 pos = _activePoint.destroyHintAndReturnItsPosition();
        Debug.Log(pos.ToString() + _tagget.transform.position.ToString());
        if (isSpawnerHint) {
          _pointSpawner.add();
        }
        _activePoint.activeButton = null;
        _cellOperator.checkButton(pos);
        Destroy(gameObject);
      }

    }
    if (active) {
      _activePoint.activeButton = gameObject.GetComponent<CrossButtonHandler>();
      transform.position = Input.mousePosition;
    }
  }
}
