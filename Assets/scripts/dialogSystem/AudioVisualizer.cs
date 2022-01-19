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
  private AudioVisualizerData data;

  [SerializeField]
  private Canvas _canvasOverlay;
  private AudioVisualizerData _visualizerData;

  void Start() {
    if (GameObject.FindGameObjectsWithTag("dialog_canvas").Length == 0) {
      Instantiate(_canvasOverlay, Vector3.zero, Quaternion.identity);
    }
  }
  public void changeAudioVisualizerData(AudioVisualizerData visualizerData) {
    Text content = GameObject.FindGameObjectWithTag("dialog_content").GetComponent<Text>();
    content.text = visualizerData._text;
    Text name = GameObject.FindGameObjectWithTag("dialog_name").GetComponent<Text>();
    switch (visualizerData._role) {
      case Roles.CAPTAIN:
        name.text = "Капитан";
        break;
      case Roles.PILOT:
        name.text = "Пилот";
        break;
      case Roles.VOICE_ASSISTANT:
        name.text = "Голосовой помощник";
        break;
    }
  }
}
