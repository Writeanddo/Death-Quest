using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Uimanager : MonoBehaviour
{
    public static Uimanager instance;

    [SerializeField] Image pos1;
    [SerializeField] Image pos2;
    [SerializeField] Sprite empty;

    [SerializeField] GameManager GameManager;

    [SerializeField] Volume volume;
    [SerializeField] GameObject Globalvolume;
    [SerializeField] Vignette vignette;
    [SerializeField] Color red;

    public float vignettemin, vignettemax, vignettecurrent, lerptime, lerpmultiplier;
    public bool abletolerp, ABLETOLERPDOWN;
    public bool hasrestlerptime;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        findvolume();
    }
    private void Update()
    {
        if (GameManager.Items[0]!= null)
        {
            pos1.sprite = GameManager.Items[0].GetComponent<item>().image;
        }
        else
        {
            pos1.sprite =  empty;
        }
        
        if(GameManager.Items[1] != null)
        {
            pos2.sprite = GameManager.Items[1].GetComponent<item>().image;

        }
        else
        {
            pos2.sprite = empty;
        }


        lerptime += Time.deltaTime;
        if (abletolerp)
        {
            vignettecurrent = Mathf.Lerp(vignettemin, vignettemax, lerptime * lerpmultiplier);

            vignette.intensity.value = vignettecurrent;
            if (vignettecurrent == vignettemax)
            {
                ABLETOLERPDOWN = true;
                hasrestlerptime = false;
            }
        }

        if (ABLETOLERPDOWN)
        {
            abletolerp = false;
            if (!hasrestlerptime)
            {
                Resetlerptime();
            }



            vignettecurrent = Mathf.Lerp(vignettemax, vignettemin, lerptime * lerpmultiplier);
            vignette.intensity.value = vignettecurrent;
            abletolerp = false;
            if (vignettecurrent == vignettemin)
            {
                ABLETOLERPDOWN = false;
            }
        }

    }


    public void findvolume()
    {
        volume = Globalvolume.GetComponent<Volume>();
        volume.sharedProfile.TryGet<Vignette>(out vignette);
        vignette.color.Override(red);
    }


    public void Resetlerptime()
    {
        lerptime = 0f;
        hasrestlerptime = true;

    }
    private void OnDisable()
    {
  
        vignette.intensity.value = 0f;
    

    }

}
