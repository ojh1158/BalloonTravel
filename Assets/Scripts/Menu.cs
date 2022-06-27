using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Continue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        //게임 시간 활성화
        Debug.Log("시간 활성화"); 
        Time.timeScale = 1.0f;
    }

}
