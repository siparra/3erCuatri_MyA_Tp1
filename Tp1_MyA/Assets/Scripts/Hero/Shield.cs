using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int life;
    public float contador;
    
	void Start ()
    {
        life = 5;
	}

    void OnEnable()
    { 
        life = 5;
        contador = 0;
    }

    void Update ()
    {
        contador += Time.deltaTime;

        if (contador > 20)
        {
            SetShieldInactive();
        }

		if(life <= 0)
        {
            SetShieldInactive();
        }
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        life--;
    }

    public void SetShieldInactive()
    {
        gameObject.SetActive(false);
    }
}
