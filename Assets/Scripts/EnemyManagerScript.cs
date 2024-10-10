using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EnemySet1", 0);
        Invoke("EnemySet1", 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnemySet1()
    {
        Instantiate(enemy, new Vector3(0, 10, 0), Quaternion.identity);
        Instantiate(enemy, new Vector3(0, -10, 0), Quaternion.identity);
    }
}
