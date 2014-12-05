using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    private AudioSource[] mAudioSrcKey;
    private AudioClip[] mAudioClip;

	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
	
	}
}
