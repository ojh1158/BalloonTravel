using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_chainge : MonoBehaviour
{

    public AudioSource start_Audio;

    public AudioSource old_Audio;

    void Start()
    {
        StartCoroutine(Audio_start_(start_Audio));
    }

    public void chainge_ado(AudioSource Chainge_Audio)
    {
        StartCoroutine(Audio_Fade(Chainge_Audio));
    }

    IEnumerator Audio_start_(AudioSource Chainge_Audio)
    {
        while (true)
        {
            yield return null;
            Chainge_Audio.volume += Time.fixedDeltaTime * 0.1f;

            if (Chainge_Audio.volume > 0.99f)
            {
                old_Audio = Chainge_Audio;

                Debug.Log(old_Audio);
                yield break;
            }
        }
    }

    IEnumerator Audio_Fade(AudioSource Chainge_Audio)
    {
        while (true)
        {
            yield return null;
            old_Audio.volume -= Time.fixedDeltaTime * 0.1f;
            Chainge_Audio.volume += Time.fixedDeltaTime * 0.1f;
            if (Chainge_Audio.volume > 0.99f)
            {
                old_Audio = Chainge_Audio;
                Debug.Log(old_Audio);
                yield break;
            }
        }
    }

    //IEnumerator old_sd(AudioSource Chainge_Audio)
    //{
    //    yield return null;

    //    old_Audio = Chainge_Audio;

    //}

}
