using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimScript : MonoBehaviour
{
    private Vector3 playerPos;
    public Vector3 PlayerPos { set; get; }

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, playerPos);
        lineRenderer.SetPosition(1, new Vector3(0, playerPos.y, 0));
    }
}
