using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilHero : MonoBehaviour {

    public float speed;
    private MisilBulletGenerator _bulletPool;
    private Vector3 _pos;
    private Vector3 _localScale;
    private Quaternion _localRotation;
    private float _frecuency = 5f;
    private float _magnitude = 0.2f;
    public Transform sprite;
    public GameObject particleEffect;
    public Transform heroTransform;
    public LOS los;
    public Transform target;
    public Collider2D[] enemigos;

    private float _contrador;

    void Start()
    {

        los = GetComponent<LOS>();
    }

    void Update()
    {
        _contrador += Time.deltaTime;

        if (_contrador > 1f)
        {
            //var enemigos = Physics.OverlapSphere(transform.position, 2.5f);
            enemigos = Physics2D.OverlapCircleAll(transform.position, 2.5f);
            _contrador = 0;
            if (enemigos.Length > 1)
            {
                foreach(var hit in enemigos)
                {
                    if(hit.tag == "Enemy" && target == null)
                    {

                        target = hit.GetComponent<Transform>();
                        
                    }
                }
            }
        }

        if (target)
        {
            var direction = (target.transform.position - transform.position).normalized;

            var smooth = 1f;
            var lookRotation = Quaternion.LookRotation(target.position - transform.position);

            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * smooth);

            //Vector3 vectorToTarget = target.transform.position - transform.position;
            //float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            //Quaternion qt = Quaternion.AngleAxis(angle, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * smooth);
        }
        else
        {
            Move();
        }

        
    }

    public void Move()
    {
        _pos += transform.up * Time.deltaTime * speed;
        transform.position = _pos + transform.right * Mathf.Sin(Time.time * _frecuency) * ((_magnitude += Time.deltaTime)/2);
        //transform.Rotate(transform.up, ((transform.position.x + transform.position.y) / 2));
        // transform.LookAt(transform);
        // transform.position = transform.position + new Vector3(Mathf.Sin(Time.time * 10f), 0, 0.5f);
    }

    private void Initialize()
    {
        _pos = heroTransform.position;
        _frecuency = Random.Range(2f, 3f);
        _magnitude = Random.Range(0.1f, 0.5f);
        target = null;
        StartCoroutine(DestroyBullet(this));
    }

    private void Dispose()
    {
        // throw new NotImplementedException();
    }

    public static void InitializeBullet(MisilHero bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.Initialize();
    }

    public static void DisposeBullet(MisilHero bullet)
    {
        bullet.Dispose();
        bullet.gameObject.SetActive(false);
    }

    public void SetBulletPool(MisilBulletGenerator bulletPool)
    {
        _bulletPool = bulletPool;
    }

    IEnumerator DestroyBullet(MisilHero bullet)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(particleEffect, this.transform.position, Quaternion.identity);
        _bulletPool.ReturnBulletToPool(bullet);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(particleEffect, this.transform.position, Quaternion.identity);
            _bulletPool.ReturnBulletToPool(this);
        }

    }
}
