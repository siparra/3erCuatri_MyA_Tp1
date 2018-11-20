using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject sprite;
    public float timeForDestroy;
    public float contadorForDestroy;
    public float contadorForFade;
    public int timeForFade;
    public bool ableToFade = true;

    public virtual void DestroyInTime(float timetodestroy)
    {
        if(contadorForDestroy > timeForDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void FadeInTIme(float timeforfade)
    {
        if(contadorForFade >= timeForFade && ableToFade == true)
        {
            StartCoroutine(Fade());
            ableToFade = false;
        }
    }

    public virtual IEnumerator Fade()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            sprite.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            sprite.SetActive(true);
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Hero")
        {
            Destroy(this.gameObject);
        }
            
    }
}
