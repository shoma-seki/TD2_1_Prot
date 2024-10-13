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

    private float shotCoolTime = 3f;
    private float kShotCoolTime = 3f;
    public GameObject bullet;

    private bool CanFire;

    public GameObject beamWarning;
    private float beamWarningTime = 1.5f;
    private float kBeamWarningTime = 1.5f;

    public EnemyBeamScript beam;
    private float fireTime;

    public bool isWeak;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();
        position = transform.position;

        //transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == false)
        {
            scaleT += 2f * Time.deltaTime;
            scaleT = Mathf.Clamp01(scaleT);
            //transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(5, 5, 5), EaseOutQuint(scaleT));
            if (scaleT >= 1.0f)
            {
                isStart = true;
            }
        }

        if (isStart)
        {
            endPosition = new Vector3(0, player.transform.position.y, 0);
            position = Vector3.Lerp(position, endPosition, t * Time.deltaTime);
            transform.position = position;
            if (transform.localScale.x > 10f)
            {
                Destroy(gameObject);
            }

            Shot();
        }
    }

    private void Shot()
    {
        if (CanFire == false)
        {
            shotCoolTime -= Time.deltaTime;
        }

        if (shotCoolTime < 0)
        {
            shotCoolTime = kShotCoolTime;
            CanFire = true;
            Instantiate(beamWarning, transform.position, Quaternion.identity);
            //Instantiate(bullet, position, Quaternion.identity);
        }

        if (CanFire)
        {
            beamWarningTime -= Time.deltaTime;

            if (beamWarningTime < 0)
            {
                CanFire = false;
                beamWarningTime = kBeamWarningTime;

                EnemyBeamScript newBeam = Instantiate(beam, transform.position, Quaternion.identity);
                newBeam.SetFireTime(1f);
                fireTime = 1f;
                newBeam.SetRotate();
            }
        }

        fireTime -= Time.deltaTime;

        Debug.Log(CanFire);

        if (CanFire || fireTime > 0)
        {
            isWeak = true;
        }
        else
        {
            isWeak = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            transform.localScale += Vector3.one / 2f;
        }
    }

    private float EaseOutQuint(float t)
    {
        return 1 - Mathf.Pow(1 - t, 4);
    }
}
