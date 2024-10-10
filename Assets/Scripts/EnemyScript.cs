using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Vector3 position;
    private Vector3 endPosition;
    private PlayerScript player;
    private float t = 0.5f;

    private float scaleT;

    private bool isStart;

    private float shotCoolTime = 0.5f;
    private float kShotCoolTime = 0.5f;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();
        position = transform.position;

        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == false)
        {
            scaleT += 2f * Time.deltaTime;
            scaleT = Mathf.Clamp01(scaleT);
            transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(2, 2, 2), EaseOutQuint(scaleT));
            if (scaleT >= 1.0f)
            {
                isStart = true;
            }
        }

        if (isStart)
        {
            //endPosition = new Vector3(0, player.transform.position.y, 0);
            //position = Vector3.Lerp(position, endPosition, t * Time.deltaTime);
            //transform.position = position;
            if (transform.localScale.x > 4f)
            {
                Destroy(gameObject);
            }

            Shot();
        }
    }

    private void Shot()
    {
        shotCoolTime -= Time.deltaTime;
        if (shotCoolTime < 0)
        {
            shotCoolTime = kShotCoolTime;
            Instantiate(bullet, position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            transform.localScale += other.gameObject.GetComponent<BulletScript>().scale / 3f;
        }
    }

    private float EaseOutQuint(float t)
    {
        return 1 - Mathf.Pow(1 - t, 4);
    }
}
