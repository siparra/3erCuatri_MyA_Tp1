using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IObservable
{
    public ViewPlayer view;
    public IController controller;
    public GameObject bullet;
    public Transform mainGun;
    public Transform sideGunL;
    public Transform sideGunR;
    public Transform misilGunL;
    public Transform misilGunR;
    public ModelPlayer model;
    public GameObject shield;
    public Transform camara;

    public NormalBulletGenerator bulletPool;
    public MisilBulletGenerator misilPool;

    public IShootStrategy automaticStrategy;
    public IShootStrategy tripleStrategy;
    public IShootStrategy misilStrategy;

    private List<IObserver> _allObservers = new List<IObserver>();

    public bool canShot;
    public float fireRate;
    public float contador;

    public AudioSource soundSource;
    public AudioClip normalShootSound;
    public AudioClip misilSound;

    public void Awake()
    {

        bulletPool = GetComponent<NormalBulletGenerator>();
        misilPool = GetComponent<MisilBulletGenerator>();

        view = new ViewPlayer();
        model = new ModelPlayer(this.transform, shield);
        controller = new ControllerPlayer(model, view, this, camara);
        automaticStrategy = new Automatic(canShot, fireRate, bullet, mainGun, bulletPool);
        tripleStrategy = new Triple(canShot, fireRate, bullet, mainGun, sideGunL, sideGunR, bulletPool);
        misilStrategy = new Misil(canShot, fireRate, bullet, mainGun, sideGunL, sideGunR, bulletPool, misilGunL, misilGunR, misilPool);
    }

    void Start ()
    {
        model.typeOfShoot = TypeOfShoot.AUTOMATIC;
        contador = 0f;
    }
	

	void Update ()
    {
        controller.OnUpdate();

        contador += Time.deltaTime;
        if(contador > 15)

            model.typeOfShoot = TypeOfShoot.AUTOMATIC;
    }

    public void ShootByType(TypeOfShoot pTypeOfShot)
    {
        switch (pTypeOfShot)
        {
            case TypeOfShoot.AUTOMATIC:
                automaticStrategy.Shoot();
                break;
            case TypeOfShoot.TRIPLE:
                tripleStrategy.Shoot();
                break;
            case TypeOfShoot.MISIL:
                misilStrategy.Shoot();
                break;
            default:
                break;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PowerUpGun")
        {
            model.PowerUpGun();
            contador = 0;
        }
        else if(collision.gameObject.tag == "PowerUpShield")
        {
            model.PowerUpShield();
        }else if(collision.gameObject.tag == "Enemy")
        {
            NotifyObservers("HeroTakeEnemyDamage");
        }

    }

    public void Subscribe(IObserver observer)
    {
        if (!_allObservers.Contains(observer))
            _allObservers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        if (_allObservers.Contains(observer))
            _allObservers.Remove(observer);
    }

    public void NotifyObservers(string action)
    {
        foreach (var observer in _allObservers)
        {
            observer.OnNotify(action);
        }
    }
}
