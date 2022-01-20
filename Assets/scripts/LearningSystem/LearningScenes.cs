using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningScenes : MonoBehaviour
{
  [SerializeField]
  private List<Canvas> learningScenesUI;

  private int index = 0;

  public void destroyCurrentScene() {
    Destroy(learningScenesUI[index]);
  }

  public void hidCurrentScene() {
    learningScenesUI[index].gameObject.SetActive(false);
  }

  public void setNextScene() {
    destroyCurrentScene();
    index++;
    Instantiate(learningScenesUI[index], Vector3.zero, Quaternion.identity);
  } 
}
