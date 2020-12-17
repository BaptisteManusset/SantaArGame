using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{

    public static InteractionManager instance;
    public List<Present> presents;




    private void Awake()
    {
        instance = this;
    }


    public static void AddPresentToList(Present present)
    {
        if (instance.presents.Contains(present) == false) instance.presents.Add(present);
    }
    public static void RemovePresentToList(Present present)
    {
        if (instance.presents.Contains(present)) instance.presents.Remove(present);
    }
}
