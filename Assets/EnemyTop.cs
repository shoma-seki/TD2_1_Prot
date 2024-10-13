using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTop : MonoBehaviour
{
    private EnemyScript enemy;
    private Vector3 localPosition;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindAnyObjectByType<EnemyScript>();
        localPosition = transform.localPosition;
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isWeak)
        {
            localPosition.y = 0.6f;
        }
        else
        {
            localPosition = startPosition;
        }

        transform.localPosition = localPosition;
    }
}
