using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Ending : MonoBehaviour
{
    public GameObject Cutsin;

    public Image Black;

    public Image Waik_up;

    public float Speed;

    float fadeCount;
    void Start()
    {
        StartCoroutine(up());
    }

    IEnumerator up()
    {
        while (true)
        {
            yield return null;
            transform.position += Vector3.up * Speed;
            if (transform.position.y > 5515)
            {
                StartCoroutine(Fade());
                yield break;
            }
        }
    }

    IEnumerator Fade()
    {
        
        while (true)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);

            Black.color = new Color(0, 0, 0, fadeCount);

            if (fadeCount > 1f)
            {
                yield return new WaitForSeconds(3f);
                StartCoroutine(waik_up());
                yield break;
            }


        }
    }
    IEnumerator waik_up()
    {

        while (true)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);

            Waik_up.color = new Color(255, 255, 255, fadeCount);

            if (fadeCount > 1f)
            {
                yield return new WaitForSeconds(2f);
                while (true)
                {
                    fadeCount -= 0.01f;
                    yield return new WaitForSeconds(0.01f);

                    Waik_up.color = new Color(255, 255, 255, fadeCount);

                    if (fadeCount < 0f)
                    {
                        Cutsin.SetActive(true);
                        yield break;
                    }
                }
                
            }


        }
    }
}
