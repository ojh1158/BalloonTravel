using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_ : MonoBehaviour
{

    public GameObject sound_main;

    public AudioSource chainge;

    public void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Balloon")
        {
            sound_main.GetComponent<Sound_chainge>().chainge_ado(chainge);
        }
    }
}
