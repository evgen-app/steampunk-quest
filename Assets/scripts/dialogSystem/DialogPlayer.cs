using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//todo: make scenes and access to dialog player via it
[RequireComponent(typeof(AudioPlayer))]
[RequireComponent(typeof(AudioVisualizer))]
public class DialogPlayer : MonoBehaviour
{
  [SerializeField]
  AudioPlayer _audioPlayer;
  [SerializeField]
  AudioVisualizer _audioVisualizer;
  
  DialogDataClass[] _dialogData;
  
  int _idx = 0;
  Replica _currentReplica;
  bool _isDialogPlaying = true;
  bool getIsDialogPlaying(){
    return _isDialogPlaying;
  }

  void changeDialogData(DialogDataClass[] dialogData){
    _dialogData = dialogData;
    _idx = 0;
    _currentReplica = createReplica();
    _currentReplica.Play();
  }

  void playReplica(int idx) {
    if (idx >= DialogData.FirstScene.Length) return;
    //Debug.Log(idx.ToString() + DialogData.FirstScene[idx].text);

    Replica replica = new Replica(
      DialogData.FirstScene[idx].audio,
      new AudioVisualizer.AudioVisualizerData(
        text: _dialogData[idx].text,
        role: _dialogData[idx].role
      ),      
      _audioPlayer,
      () => {
        Debug.Log(idx);
        playReplica(idx+1);
      },
      _audioVisualizer
    );
    replica.Play();
  }

  Replica createReplica() {
    Replica replica = new Replica(
      _dialogData[_idx].audio,
      new AudioVisualizer.AudioVisualizerData(
        text: _dialogData[_idx].text,
        role: _dialogData[_idx].role
      ),      
      _audioPlayer,
      () => {},
      _audioVisualizer
    );
    return replica;
  }
  
  void Start()
  {
    _dialogData = DialogData.FirstScene;
    _audioPlayer = Object.FindObjectOfType<AudioPlayer>();
    _audioVisualizer = Object.FindObjectOfType<AudioVisualizer>();
    _currentReplica = createReplica();
    _currentReplica.Play();  
  }

  // Update is called once per frame
  void Update()
  {
    if (_idx >= _dialogData.Length-1) {
      _isDialogPlaying = false;
    }
    if (_currentReplica.getIsEnded()) {
      _idx++;
      _currentReplica = createReplica();
      _currentReplica.Play();
    }
  }
}
