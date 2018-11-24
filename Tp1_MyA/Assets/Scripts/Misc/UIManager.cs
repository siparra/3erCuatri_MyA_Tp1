using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    private Image _HealthBar;
    private Image _tripleIcon;

    public bool startIconCount;
    public float powerUpStartTime;
    public float powerUpRemainingTime;

    public UIManager(Image pHealthBar, Image ptripleIcon)
    {
        _HealthBar = pHealthBar;
        _tripleIcon = ptripleIcon;
    }
		

	public void Update ()
    {
        if (startIconCount)
        {
            var contador = Time.deltaTime;
            powerUpRemainingTime -= contador;
            UpdatePowerUpIcon(powerUpRemainingTime, powerUpStartTime);
            if(contador > 15)
            {
                startIconCount = false;
            }
        }
    }

    public void UpdateHealthBar(float health, float startHealth)
    {
        _HealthBar.fillAmount = health / startHealth;
    }

    public void UpdatePowerUpIcon(float remaingTime, float startTime)
    {
        _tripleIcon.fillAmount = remaingTime / startTime;
        
    }

    public void AlgunMetodo()
    {
        Debug.Log("algun log");
    }
}
