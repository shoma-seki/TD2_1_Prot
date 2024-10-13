using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2Script : MonoBehaviour
{
    private Vector3 position;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.y += player.GetComponent<PlayerScript>().speed / 0.8f * Time.deltaTime;
        if (position.y < -100)
        {
            position.y = 100;
        }
        transform.position = position;
    }
}
