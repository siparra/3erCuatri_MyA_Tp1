using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    private Image _HealthBar;
    private Image _tripleIcon;
    private Image _misilIcon;
    public Image currentIcon;
    private Image _shieldIcon;

    public bool startIconCount;
    public bool startShieldIconCount;
    public float powerUpStartTime;
    public float powerUpRemainingTime;
    public float shieldPowerUpRemainingTime;
    public float shieldPowerUpStartTime;


    public UIManager(Image pHealthBar, Image ptripleIcon, Image pMisilIcon, Image pShieldIcon)
    {
        _HealthBar = pHealthBar;
        _tripleIcon = ptripleIcon;
        _misilIcon = pMisilIcon;
        currentIcon = _misilIcon;
        _shieldIcon = pShieldIcon;
    }
		

	public void Update ()
    {
        if (startIconCount)
        {
            var contador = Time.deltaTime;
            powerUpRemainingTime -= contador;
            UpdatePowerUpIcon(currentIcon, powerUpRemainingTime, powerUpStartTime);
            if(contador > 15)
            {
                startIconCount = false;
            }
        }

        if (startShieldIconCount)
        {
            var contador = Time.deltaTime;
            shieldPowerUpRemainingTime -= contador;
            UpdatePowerUpIcon(_shieldIcon, shieldPowerUpRemainingTime, shieldPowerUpStartTime);
            if (contador > 20)
            {
                startIconCount = false;
            }
        }
    }

    public void UpdateHealthBar(float health, float startHealth)
    {
        _HealthBar.fillAmount = health / startHealth;
    }

    public void UpdatePowerUpIcon(Image icon, float remaingTime, float startTime)
    {
        icon.fillAmount = remaingTime / startTime;
        
    }

    public void AlgunMetodo()
    {
        Debug.Log("algun log");
    }
}
