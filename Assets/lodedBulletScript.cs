using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lodedBulletScript : MonoBehaviour
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
        Text text = GetComponent<Text>();
        text.text = player.loadedBullet.ToString();
    }
}
