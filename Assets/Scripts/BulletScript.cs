using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 position;
    private PlayerScript player;
    private float speed = 15f;

    public Vector3 scale;

    private float aliveTime = 10f;

    //private float aliveTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();
        position = transform.position;
        direction = new Vector3(0, player.transform.position.y, 0) - position;

        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.rotation = Quaternion.LookRotation(direction);

        velocity = direction.normalized * speed;
        position += velocity * Time.deltaTime;
        transform.position = position;

        //scale -= new Vector3(0.2f, 0.2f, 0.2f) * Time.deltaTime;
        transform.localScale = scale;

        if (scale.x <= 0.0f)
        {
            Destroy(gameObject);
        }

        aliveTime -= Time.deltaTime;
        if (aliveTime < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
