using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_out : MonoBehaviour
{
    public GameObject Image;
    public Image Fade;

    float fadeCount = 0f;


    IEnumerator fade_out()
    {
        while (fadeCount > 1f)
        {
            fadeCount += 0.005f;

            yield return new WaitForSeconds(0.01f) ;

            Fade.color = new Color(0, 0, 0, fadeCount);

            if (fadeCount > 1f)
            {
                yield break;
            }


        }
    }
}
