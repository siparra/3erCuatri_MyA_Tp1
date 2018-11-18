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

    public IShootStrategy automaticStrategy;
    public IShootStrategy tripleStrategy;

    public bool canShot;
    public float fireRate;

    public void Awake()
    {
        model = new ModelPlayer(this.transform);
        controller = new ControllerPlayer(model, view, bullet, this);
        automaticStrategy = new Automatic(canShot, fireRate, bullet, mainGun);
        tripleStrategy = new Triple(canShot, fireRate, bullet, mainGun, sideGunL, sideGunR);
    }

    void Start ()
    {
        model.typeOfShoot = TypeOfShoot.TRIPLE;
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
