using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Image misilIcon;
    public Image shieldIcon;

    public Text highScore;
    public Text score;
    public int actualScore = 0;

    public GameObject menu;

    public bool startIconCount;


    void Start ()
    {
        heroLife = heroStartLife;
        uiManager = new UIManager(healthBar, tripleIcon, misilIcon, shieldIcon);
        _hero = HeroReference.GetComponent<Player>();
        _hero.Subscribe(this);
        heroLife = 100;
        Time.timeScale = 0;

        SetScore(0);

        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
	}
	
	
	void Update ()
    {
        uiManager.Update();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
	}

    public void OnNotify(string action)
    {
        switch (action)
        {
            case "HeroTakeEnemyDamage":
                HeroTakeDamage(enemyDamage);
                break;
            case "StartTripleCount":
                misilIcon.fillAmount = 0;
                uiManager.currentIcon = tripleIcon;
                uiManager.startIconCount = true;
                uiManager.powerUpStartTime = 15;
                uiManager.powerUpRemainingTime = 15;
                break;
            case "StartMisilCount":
                tripleIcon.fillAmount = 0;
                uiManager.currentIcon = misilIcon;
                uiManager.startIconCount = true;
                uiManager.powerUpStartTime = 15;
                uiManager.powerUpRemainingTime = 15;
                break;
            case "StartShieldCount":
                uiManager.startShieldIconCount = true;
                uiManager.shieldPowerUpRemainingTime = 20;
                uiManager.shieldPowerUpStartTime = 20;
                break;
            case "UpdateScore":
                SetScore(10);
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
        SceneManager.LoadScene(0);
        heroLife = 100;
    }

    public void SetScore(int points)
    {
        actualScore += points;
        score.text = actualScore.ToString();

        if(actualScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", actualScore);
            highScore.text = actualScore.ToString();
        }
    }
}

