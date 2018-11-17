using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ViewPlayer view;
    public IController controller;
    public GameObject bullet;

    public void Awake()
    {
        ModelPlayer _m = new ModelPlayer(this.transform);
        controller = new ControllerPlayer(_m, view, bullet);
    }

    void Start ()
    {
		
	}
	

	void Update ()
    {
        controller.OnUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
        }
	}
}
