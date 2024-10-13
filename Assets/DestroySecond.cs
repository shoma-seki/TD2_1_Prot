using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySecond : MonoBehaviour
{
    private float time = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0f)
        {
            Destroy(gameObject);
        }
    }
}
