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
  private AudioClip _audio;
  void Start()
  {
    _audio = Resources.Load<AudioClip>("audio/пилот/есть");
    Replica another_rep = new Replica(
      _audio,
      new AudioVisualizer.AudioVisualizerData(
        "asdfsadf",
        role: Roles.PILOT
      ),
      _audioPlayer,

      () => {
        Debug.Log("fuck");
      },
      _audioVisualizer
    );
    Replica rep = new Replica(
      _audio,
      new AudioVisualizer.AudioVisualizerData(
        "Есть",
        role: Roles.PILOT
      ),
      _audioPlayer,

      () => {
        another_rep.Play();
      },
      _audioVisualizer
    );
    rep.Play();
  }

  // Update is called once per frame
  void Update()
  {
      
  }
}
