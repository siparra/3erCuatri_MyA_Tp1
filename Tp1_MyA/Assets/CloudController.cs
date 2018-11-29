using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(0, -2f * Time.deltaTime, 0);
        if(this.transform.position.y <= -20f)
        {
            Destroy(this);
        }
	}
}
