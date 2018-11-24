using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IObserver
{

    public float heroStartLife;
    public float heroLife;
    public int enemyDamage;
    private IObservable _hero;
    public GameObject HeroReference;

    public UIManager uiManager;
    public Image healthBar;
    public Image tripleIcon;

    public bool startIconCount;


    void Start ()
    {
        heroLife = heroStartLife;
        uiManager = new UIManager(healthBar, tripleIcon);
        _hero = HeroReference.GetComponent<Player>();
        _hero.Subscribe(this);
        heroLife = 100;
	}
	
	
	void Update ()
    {
        uiManager.Update();

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            uiManager.startIconCount = true;
            uiManager.powerUpStartTime = 15;
            uiManager.powerUpRemainingTime = 15;
        }
        
	}

    public void OnNotify(string action)
    {
        switch (action)
        {
            case "HeroTakeEnemyDamage":
                HeroTakeDamage(enemyDamage);
                break;
            case "StartCount":
                uiManager.startIconCount = true;
                break;
                    
            default:
                break;
        }
    }
    public void HeroTakeDamage(int damage)
    {
        if(heroLife >= 0)
        {
            heroLife -= damage;
            uiManager.UpdateHealthBar(heroLife, heroStartLife);

        }
        else
        {
            LooseGame();
        }
    }

    public void LooseGame()
    {
        Debug.Log("Perdiste El Juego");
        heroLife = 100;
    }
}

