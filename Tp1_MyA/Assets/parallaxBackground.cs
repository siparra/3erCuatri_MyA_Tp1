using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour {
    public GameObject image1;
    public GameObject image2;
    public SpriteRenderer[] clouds;

    private Vector3 _startPosition = new Vector3(0, 0, 0);
    private Vector3 _endPosition = new Vector3(0, -160, 0);

    public float speed = 5f;
    public float cloudTimer;
	// Use this for initialization
	void Start () {
        cloudTimer = 5f;
	}
	
	// Update is called once per frame
	void Update () {

        image1.transform.position += new Vector3(0, -1*(Time.deltaTime * speed), 0);
        image2.transform.position += new Vector3(0, -1 * (Time.deltaTime * speed), 0);

        if(image1.transform.localPosition.y <= _endPosition.y)
        {
            image1.transform.localPosition = _startPosition;
        }
        if (image2.transform.localPosition.y <= _endPosition.y)
        {
            image2.transform.localPosition = _startPosition;
        }

        if (cloudTimer < 0)
        {
            var index = Random.Range(0, clouds.Length - 1);
            Vector3 position = new Vector3(Random.Range(-4,4), 12f, 0);
            var cloud = Instantiate(clouds[index], position, this.transform.rotation);
            cloud.sortingOrder = Random.Range(1, 4);
            cloudTimer = Random.Range(3, 8);
        }
        cloudTimer -= Time.deltaTime;
    }
}
