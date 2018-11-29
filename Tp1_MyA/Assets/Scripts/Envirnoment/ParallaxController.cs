using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {

    public GameObject image1;
    public GameObject image2;
    public SpriteRenderer[] clouds;
    public float speed;
    private Vector3 _startPosition;
    private float cloudTimer;
	// Use this for initialization
	void Start () {
        _startPosition = new Vector3(0,0,0);
        cloudTimer = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        image1.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        image2.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);

        if(image1.transform.localPosition.y <= -320f)
        {
            image1.transform.localPosition = _startPosition;
        }
        if (image2.transform.localPosition.y <= -320f)
        {
            image2.transform.localPosition = _startPosition;
        }

        if (cloudTimer < 0)
        {
            var index = Random.Range(0, 4);
            var position = new Vector3(Random.Range(-5, 5), 12f, 0);
            var cloud = Instantiate(clouds[index], position, this.transform.rotation);
            cloud.sortingOrder = Random.Range(0, 5);
            cloudTimer = Random.Range(2f, 5f);
        }

        cloudTimer -= Time.deltaTime;
    }
}
