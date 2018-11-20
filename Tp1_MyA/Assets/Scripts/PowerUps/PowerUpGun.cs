using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGun : PowerUp {


	void Start ()
    {
		
	}
	

	void Update ()
    {

        contadorForDestroy += Time.deltaTime;
        contadorForFade += Time.deltaTime;
        DestroyInTime(timeForDestroy);
        FadeInTIme(timeForFade);
    }
}
