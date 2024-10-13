using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWarningScript : MonoBehaviour
{
    private PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation((player.transform.position - transform.position).normalized);
    }
}
