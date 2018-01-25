using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeOut : MonoBehaviour {
    public AudioFadeOut()
    {
        Debug.Log("We are here !!!!!!!!!!!!!!!!!!!!!!!!");
    }
    
     
        public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        Debug.Log("We are here ????????????????????????");

        float startVolume = audioSource.volume;
            while (audioSource.volume > 0)
            {
                Debug.Log(audioSource.volume+" ");
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            
            }

            audioSource.Stop();
            audioSource.volume = startVolume;

        return null;
        }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
