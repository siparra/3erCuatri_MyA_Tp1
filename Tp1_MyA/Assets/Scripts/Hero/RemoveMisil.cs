using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMisil : MonoBehaviour
{


	void Start ()
    {
        StartCoroutine(DestroyGO());
	}
	
    public IEnumerator DestroyGO()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
