using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject how_to_controll;

    public void Start_Button()
    {
        SceneManager.LoadScene(1);
    }

    public void How_To_Controll()
    {
        how_to_controll.SetActive(true);
    }
}
