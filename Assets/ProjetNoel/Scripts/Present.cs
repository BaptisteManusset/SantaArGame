using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    private void Start() => InteractionManager.AddPresentToList(this);
    private void OnDisable() => InteractionManager.RemovePresentToList(this);
    private void OnMouseDown() => GetPresent();

    private void GetPresent()
    {
        GameManager.IncreaseScore();
        Destroy(gameObject);
    }

}
