using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatefulSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static int HealthCurrent;
    public static int HealthMax;
    public static int EnergyCurrent;
    public static int EnergyMax;

    private Image healthBar;
    private Image energyBar;
    void Start()
    {
        healthBar = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        energyBar = transform.GetChild(1).GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
        energyBar.fillAmount = (float)EnergyCurrent / (float)EnergyMax;
    }
}
