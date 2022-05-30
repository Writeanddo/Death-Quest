using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enddoor : MonoBehaviour
{
    public bool hasunlockeddoor;
    [SerializeField] Animator anim;
    [SerializeField] float timetowait;

    public GameObject nokeyfound, unlockdoor;

    public GameObject keyindoor;


    public void opendoor()
    {
        StartCoroutine(openco());
    }

    private IEnumerator openco()
    {
        AudioManager.instance.playsound(5);
        keyindoor.SetActive(true);
        yield return new WaitForSeconds(timetowait);
        anim.SetTrigger("open");
    }


}
