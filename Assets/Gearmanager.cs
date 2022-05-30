using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearmanager : MonoBehaviour
{
    public bool gearplaced;


    public GameObject missingcanvas;
    public GameObject insertgearcanvas;

    public GameObject missinggear;

    [SerializeField] Animator spinanim;
    [SerializeField] Animator dooranim;
    [SerializeField] float secs;

    public void gearinserted()
    {
        StartCoroutine(spin());
        missinggear.SetActive(true);
    }

    private IEnumerator spin()
    {
        AudioManager.instance.playsound(4);
        spinanim.SetTrigger("spin");

        yield return new WaitForSeconds(secs);

        dooranim.SetTrigger("open");

    }
}
