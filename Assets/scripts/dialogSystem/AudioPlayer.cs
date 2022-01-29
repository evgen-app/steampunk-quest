using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
  public delegate void AudioPlayerStopsCommit();
  private AudioSource _audioPlayer;
  private List<AudioPlayerStopsCommit> _stopsCommits;
  private bool _play;
  void Awake()
  {
    _audioPlayer = gameObject.GetComponent<AudioSource>();
    _stopsCommits = new List<AudioPlayerStopsCommit>();
  }

  public void addStopListener(AudioPlayerStopsCommit stopCommit) {
    _stopsCommits.Add(stopCommit);
  }

  public void PlayAudio(AudioClip audio) {
    _audioPlayer.clip = audio;
    _audioPlayer.Play();
    _play = true;  
  }

  void Update() {
    if (!_audioPlayer.isPlaying && _play) {
      Debug.Log(_stopsCommits.Count.ToString() + "commits");
      for (int i = 0; i < _stopsCommits.Count; ++i) {
        if (_stopsCommits[i] == null) continue;
        _stopsCommits[i]();
        _stopsCommits[i] = null;
      }
      _stopsCommits = new List<AudioPlayerStopsCommit>();
      _play = false;
    }
  }
}
