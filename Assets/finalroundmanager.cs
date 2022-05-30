using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class finalroundmanager : MonoBehaviour
{
    [SerializeField] Abacus abacus1;
    [SerializeField] Abacus abacus2;

    [SerializeField] bool canplay;

    [SerializeField] ParticleSystem Confetti;

    [SerializeField] GameObject image;
    [SerializeField] GameObject image2;
    [SerializeField] GameObject image3;

    [SerializeField] VideoPlayer videoplayer1, videoplayer2, videoplayer3;

    [SerializeField] GameObject welldonecanvas;

    private void Update()
    {
        if(canplay == false)
        {
            if (abacus1.correct && abacus2.correct)
            {
                canplay = true;
                Confetti.Play();

                image.SetActive(true);
                image2.SetActive(true);
                image3.SetActive(true);

                videoplayer1.Play();
                videoplayer2.Play();
                videoplayer3.Play();

                welldonecanvas.SetActive(true);

                AudioManager.instance.playsound(9);
                AudioManager.instance.playsound(10);
            }
        }
       
    }
}
