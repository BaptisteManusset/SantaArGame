using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    Image ui;
    //[SerializeField] string format = "{0}";
    //[SerializeField] bool hideEgalOnZero = false;
    //[SerializeField] bool round = false;


    [SerializeField] FloatReference max;
    [SerializeField] FloatReference value;
    private void Awake()
    {
        ui = GetComponent<Image>();
    }
    public void UpdateMe()
    {
        ui.fillAmount = value.Value / max.Value;
    }

    private void FixedUpdate()
    {
        UpdateMe();
    }
}
