using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{

    public void OnPointerEnter(PointerEventData ped)
    {
        //AudioManager.PlayClick();
    }

    public void OnPointerDown(PointerEventData ped)
    {
        //SoundManager.Instance.PlayClick();
        AudioManager.PlayClick();

    }

}
