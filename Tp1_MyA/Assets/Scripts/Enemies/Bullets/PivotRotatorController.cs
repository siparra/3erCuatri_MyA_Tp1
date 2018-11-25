using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotatorController : MonoBehaviour {
    public float speed;
    // Update is called once per frame

    private void Start()
    {
        speed = 30f;
    }
    void Update () {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
	}
}
