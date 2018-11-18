using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ViewPlayer view;
    public IController controller;
    public GameObject bullet;
    public Transform mainGun;
    public Transform sideGunL;
    public Transform sideGunR;
    public ModelPlayer model;

    public NormalBulletGenerator bulletPool;

    public IShootStrategy automaticStrategy;
    public IShootStrategy tripleStrategy;

    public bool canShot;
    public float fireRate;

    public void Awake()
    {

        bulletPool = GetComponent<NormalBulletGenerator>();

        model = new ModelPlayer(this.transform);
        controller = new ControllerPlayer(model, view, this);
        automaticStrategy = new Automatic(canShot, fireRate, bullet, mainGun, bulletPool);
        tripleStrategy = new Triple(canShot, fireRate, bullet, mainGun, sideGunL, sideGunR);
    }

    void Start ()
    {
        model.typeOfShoot = TypeOfShoot.AUTOMATIC;
    }
	

	void Update ()
    {
        controller.OnUpdate();
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
            default:
                break;
        }

    }


}
