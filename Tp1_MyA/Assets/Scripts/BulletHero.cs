using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHero : MonoBehaviour
{
    public float speed;

    void Start ()
    {
		
	}
	

	void Update ()
    {
        Move();
	}

    public void Move()
    {
        var direction = transform.up;
        transform.position += direction * speed * Time.deltaTime;
    }
}
