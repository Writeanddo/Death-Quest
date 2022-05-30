using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource[] Sounds;
    private void Awake()
    {
        instance = this;
    }


    public void playsound(int index)
    {
        Sounds[index].Play();
    }
}
