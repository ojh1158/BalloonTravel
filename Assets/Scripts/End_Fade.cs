using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_Fade : MonoBehaviour
{
    public GameObject[] end_trigger;

    public GameObject[] object_set;

    public GameObject[] open_eyes_object;

    float fadeCount;

    public Image[] open_eyes_Fade;
    public Image[] Fade_image;

    bool open_eyes;

    int page = 0;

    public int Cut_flame_int;


    public void End_Trigger()
    {
        GameManager.isTalking = true;

        StartCoroutine(Time_line());
    }

    IEnumerator Time_line()
    {
        yield return null;
        StartCoroutine(Ending_start());
        while (true)
        {
            yield return null;
            if (open_eyes)
            {
                StartCoroutine(fade_in_Wt(0));
                yield break;
            }
            if (page == 1)
            {
                //StartCoroutine();
            }
        }
        
    }

    IEnumerator Ending_start()
    {
        fadeCount = 1.0f;
        open_eyes_object[0].SetActive(true);
        while (true)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);

            open_eyes_Fade[0].color = new Color(255, 255, 255, fadeCount);

            if (fadeCount < 0.6f)
            {
                while (true)
                {
                    fadeCount += 0.01f;
                    yield return new WaitForSeconds(0.01f);

                    open_eyes_Fade[0].color = new Color(255, 255, 255, fadeCount);

                    if (fadeCount > 0.9f)
                    {
                        while (true)
                        {
                            fadeCount -= 0.01f;
                            yield return new WaitForSeconds(0.01f);

                            open_eyes_Fade[0].color = new Color(255, 255, 255, fadeCount);
                            if (fadeCount < 0)
                            {
                                yield break;
                            }
                        }
                    }
                }
            }
        }
        
    }

    IEnumerator fade_in_Wt(int number)
    {
        fadeCount = 1.0f;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);     //0.01?????? ????

            Fade_image[number].color = new Color(255, 255, 255, fadeCount);
            if (fadeCount < 0.0f)
            {
                yield break;
            }
        }
    }

    IEnumerator fade_out_Bk(int number)
    {
        fadeCount = 1f;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);     //0.01?????? ????

            Fade_image[number].color = new Color(0, 0, 0, fadeCount);
            if (fadeCount < 0.0f)
            {
                yield break;
            }
        }
        
    }

}
