using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    private AudioSource audio;

    [SerializeField] AudioClip click;
    [SerializeField] AudioClip newMessage;
    [SerializeField] AudioClip recoltPresent;
    [SerializeField] AudioClip gameOver;
    [SerializeField] AudioClip win;

    private void Awake()
    {
        instance = this;
        audio = GetComponent<AudioSource>();
    }

    public static void PlayClick()
    {
        instance.audio.PlayOneShot(instance.click);
    }

    public static void PlayNewMessage()
    {
        instance.audio.PlayOneShot(instance.newMessage);
    }
    public static void PlayRecoltPresent()
    {
        instance.audio.PlayOneShot(instance.recoltPresent);
    }
}
