using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replica {
  private AudioClip _clip;
  private AudioVisualizer.AudioVisualizerData _visualizerData;
  private AudioPlayer.AudioPlayerStopsCommit _onStop;
  private AudioPlayer _audioPlayer;
  private AudioVisualizer _audioVisualizer;
  private bool isEnded = false;

  public bool getIsEnded() {
    return isEnded;
  }

  public Replica(AudioClip clip, AudioVisualizer.AudioVisualizerData visualizerData, AudioPlayer audioPlayer, AudioPlayer.AudioPlayerStopsCommit onStop, AudioVisualizer audioVisualizer) {
    _clip = clip;
    _audioPlayer = audioPlayer;
    _audioVisualizer = audioVisualizer;
    _visualizerData = visualizerData;
  }


  public void Play() {
    _audioPlayer.PlayAudio(_clip);
    _audioPlayer.addStopListener(() => {
      isEnded = true;
    });
    _audioVisualizer.changeAudioVisualizerData(_visualizerData);
  }
}

