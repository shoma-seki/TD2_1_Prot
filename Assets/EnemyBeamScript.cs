using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyBeamScript : MonoBehaviour
{
    private EnemyScript enemy;
    private PlayerScript player;

    private Vector3 position;
    private Vector3 direction;
    private Vector3 scale = Vector3.one;

    private float fireTime;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();
        enemy = FindAnyObjectByType<EnemyScript>();
        position = enemy.transform.position;
        //Assert.IsNull(player);
        //Assert.IsNull(enemy);
        direction = (player.transform.position - enemy.transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    // Update is called once per frame
    void Update()
    {
        fireTime -= Time.deltaTime;
        if (fireTime < 0)
        {
            Destroy(gameObject);
        }

        scale.z += 100f * Time.deltaTime;
        transform.localScale = scale;
    }

    public void SetRotate()
    {
    }

    public void SetFireTime(float fireTime)
    {
        this.fireTime = fireTime;
    }
}
