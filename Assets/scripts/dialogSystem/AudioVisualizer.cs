using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVisualizer : MonoBehaviour
{
  public class AudioVisualizerData{
    public string _text;
    public Roles _role;
    public AudioVisualizerData(string text, Roles role) {
      _text = text;
      _role = role;
    }
  }
  private GameObject _avatar;
  [SerializeField]
  private GameObject _captainAvatar;
  [SerializeField]
  private GameObject _pilotAvatar;
  [SerializeField]
  private GameObject _voiceAssistantAvatar;
  private AudioVisualizerData data;

  [SerializeField]
  private Canvas _canvasOverlay;
  private AudioVisualizerData _visualizerData;
  void Start() {
    if (GameObject.FindGameObjectsWithTag("dialog_canvas").Length == 0) {
      Instantiate(_canvasOverlay, Vector3.zero, Quaternion.identity);
    }
  }
  IEnumerator setText() {
    Text content = GameObject.FindGameObjectWithTag("dialog_content").GetComponent<Text>();
    content.text = "";
    foreach(char i in _visualizerData._text) {
      content.text += i;
      yield return new WaitForSeconds(0.05f);
    }
  }
  string RoleToString(Roles role) {
    string res = "";
    switch (role) {
      case Roles.CAPTAIN:
        res = "Капитан";
        break;
      case Roles.PILOT:
        res = "Пилот";
        break;
      case Roles.VOICE_ASSISTANT:
        res = "Голосовой помощник";
        break;
      case Roles.CAPTAIN_IN_IMAGINATION:
        res = "Капитан (воспоминание)";
        break;
      case Roles.VOICE_ASSISTANT_IN_IMAGINATION:
        res = "Elizabeth (воспоминание)";
        break;
    }
    return res;
  }
  IEnumerator setHeader() {
    Text name = GameObject.FindGameObjectWithTag("dialog_name").GetComponent<Text>();
    name.text = "";
    string nameText = RoleToString(_visualizerData._role);
    foreach(char i in nameText) {
      name.text += i;
      yield return new WaitForSeconds(0.05f);
    }
  }
  public void changeAudioVisualizerData(AudioVisualizerData visualizerData) {
    Canvas canvas = Object.FindObjectOfType<Canvas>();
    Text content = GameObject.FindGameObjectWithTag("dialog_content").GetComponent<Text>();
    _visualizerData = visualizerData;
    StartCoroutine("setText");
    StartCoroutine("setHeader");
    Destroy(_avatar);
    switch(visualizerData._role) {
      case Roles.CAPTAIN:
        _avatar = Instantiate(_captainAvatar, _captainAvatar.transform.position, Quaternion.identity);
        break;
      case Roles.PILOT:
        _avatar = Instantiate(_pilotAvatar, _pilotAvatar.transform.position, Quaternion.identity);
        break;
      case Roles.VOICE_ASSISTANT:
        _avatar = Instantiate(_voiceAssistantAvatar, _voiceAssistantAvatar.transform.position, Quaternion.identity);
        break;
      case Roles.CAPTAIN_IN_IMAGINATION:
        _avatar = Instantiate(_captainAvatar, _captainAvatar.transform.position, Quaternion.identity);
        break;
      case Roles.VOICE_ASSISTANT_IN_IMAGINATION:
        _avatar = Instantiate(_voiceAssistantAvatar, _voiceAssistantAvatar.transform.position, Quaternion.identity);
        break;
    }
    _avatar.transform.SetParent(canvas.transform, false);
  }
}
