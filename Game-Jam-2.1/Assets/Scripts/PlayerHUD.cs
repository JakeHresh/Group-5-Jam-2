using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Slider slider;

    private HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        SetHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthBar();
    }

    void SetHealthBar()
    {
        slider.value = healthSystem.health / healthSystem.MaxHealth;
    }
}
