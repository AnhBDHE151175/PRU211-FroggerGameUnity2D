using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazorControl : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform laserPosition;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        laserPosition.position = hit.point;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, laserPosition.position);
    }
}
