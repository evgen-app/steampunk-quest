using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
  public delegate void AudioPlayerStopsCommit();
  private AudioSource _audioPlayer;
  private List<AudioPlayerStopsCommit> _stopsCommits;
  void Awake()
  {
    Debug.Log("shit");
    _audioPlayer = gameObject.GetComponent<AudioSource>();
    _stopsCommits = new List<AudioPlayerStopsCommit>();
  }

  public void addStopListener(AudioPlayerStopsCommit stopCommit) {
    _stopsCommits.Add(stopCommit);
  }

  public void PlayAudio(AudioClip audio) {
    _audioPlayer.clip = audio;
    _audioPlayer.Play();    
  }

  void Update() {
    if (!_audioPlayer.isPlaying) {
      for (int i = 0; i < _stopsCommits.Count; ++i) {
        _stopsCommits[i]();
      }
      _stopsCommits = new List<AudioPlayerStopsCommit>();
    }
  }
}
