using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
     
    void Update()
    {
        //메뉴 
        if (Input.GetButtonDown("Cancel"))
        {


            if (menu.activeSelf)
            {
                Time.timeScale = 1;
                //Debug.Log("시간 활성화");
                menu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                //Debug.Log("시간 비활성화");
                menu.SetActive(true);
            }
   
        }
        
    }

    public void GameExit()
    {

        // 게임 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else

        Application.Quit();
        
        Debug.Log("게임 종료");
#endif
    }




}

