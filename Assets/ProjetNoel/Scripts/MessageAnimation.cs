using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageAnimation : MonoBehaviour
{

    [SerializeField] List<GameObject> messages;
    public Button continu;

    void Start()
    {

        for (int i = 0; i < messages.Count; i++)
        {
            messages[i].SetActive(false);
        }

        continu.interactable = false;
        StartCoroutine("WaitAndPrint");
    }


    private IEnumerator WaitAndPrint()
    {
        for (int i = 0; i < messages.Count; i++)
        {
            Debug.Log(messages[i]);

            yield return new WaitForSecondsRealtime(1f);
            AudioManager.PlayNewMessage();
            messages[i].SetActive(true);
        }
        yield return new WaitForSecondsRealtime(1f);

        continu.interactable = true;
    }
}
