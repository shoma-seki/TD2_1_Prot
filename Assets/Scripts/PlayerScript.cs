using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector3 position;
    private Vector3 prePosition;
    private Vector3 direction;

    private Vector3 startPosition;

    private float distance;

    public float speed;
    private float accumulationSpeed = 10f;
    public float theta;
    private float reloadTheta;

    public GameObject top;
    public GameObject bottom;

    public GameObject bullet;
    public int loadedBullet = 5;
    private bool isShot;

    private float shotCoolTime;
    private float kShotCoolTime = 0.2f;

    private int HP = 5;

    private PlayerAimScript playerAim;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        startPosition = transform.position;

        distance = Vector3.Distance(position, Vector3.zero);

        playerAim = FindAnyObjectByType<PlayerAimScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();

        direction = Vector3.zero - position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Shot()
    {
        reloadTheta += speed / 3f * Time.deltaTime;
        if (Mathf.Abs(reloadTheta) > Mathf.PI)
        {
            reloadTheta = 0;
            loadedBullet++;
            //if (prePosition.y > position.y)
            //{
            //    reloadTheta = 0;
            //    loadedBullet++;
            //}
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isShot = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isShot = false;
            shotCoolTime = kShotCoolTime;
        }

        if (isShot)
        {
            if (loadedBullet > 0)
            {
                shotCoolTime -= Time.deltaTime;
                if (shotCoolTime < 0.0f)
                {
                    loadedBullet--;
                    shotCoolTime = kShotCoolTime;
                    Instantiate(bullet, position, Quaternion.identity);
                }
            }
            //if (loadedBullet == 0)
            //{
            //    isShot = false;
            //    //speed = accumulationSpeed;
            //}
        }
    }

    private void Move()
    {
        if (isShot)
        {
            speed = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            accumulationSpeed += 10f * Time.deltaTime;
            speed = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 0;
            speed = accumulationSpeed;
            accumulationSpeed = 0;
        }

        prePosition = position;

        //if (Input.GetKey(KeyCode.A))
        //{
        //    speed += 5f * Time.deltaTime;
        //    speed = Mathf.Clamp(speed, -10, 10);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    speed -= 5f * Time.deltaTime;
        //    speed = Mathf.Clamp(speed, -10, 10);
        //}

        speed -= 5f * Time.deltaTime;
        //speed = Mathf.Clamp(speed, -10, 10);

        theta += speed / 3f * Time.deltaTime;

        position.y += speed / 0.8f * Time.deltaTime;

        float t = Mathf.InverseLerp(bottom.transform.position.y, top.transform.position.y, position.y);

        //Debug.Log(bottom.transform.localPosition.y);
        //Debug.Log(top.transform.localPosition.y);
        //Debug.Log(position.y);

        //Debug.Log(t);

        //distance = Mathf.Lerp(30, 10, t);
        distance = 20;

        position.x = distance * Mathf.Sin(theta);
        position.z = distance * Mathf.Cos(theta);

        transform.position = position;

        playerAim.PlayerPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            HP--;
            if (HP == 0)
            {
                transform.position = startPosition;
            }
        }
    }

    public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
    {
        Vector3 AB = b - a;
        Vector3 AV = value - a;
        return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
    }
}
