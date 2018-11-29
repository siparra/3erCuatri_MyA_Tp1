using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudController : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(0, -2f * Time.deltaTime, 0);
        if(this.transform.localPosition.y <= -120)
        {
            Destroy(this);
        }
	}
}
