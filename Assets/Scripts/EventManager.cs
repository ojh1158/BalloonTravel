using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject dialoguemanager;
    public void OnTriggerEnter(Collider other) //�̱��� ����
    {
        if (other.tag == "Player")
        {
            dialoguemanager.GetComponent<DialogueManager>().Event_1_1();
        }
    }
}
