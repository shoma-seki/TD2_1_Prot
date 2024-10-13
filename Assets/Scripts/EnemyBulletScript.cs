using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 position;
    private PlayerScript player;
    private float speed = 15f;

    public Vector3 scale;

    private float aliveTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();
        position = transform.position;
        direction = player.transform.position - position;

        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
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
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
