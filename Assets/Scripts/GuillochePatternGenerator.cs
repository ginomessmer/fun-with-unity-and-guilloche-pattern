using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GuillochePatternGenerator : MonoBehaviour
{
    public float Radius = 50;
    public float r = -0.25f;
    public float p = 25;

    public int TotalIterations = 360;

    public GameObject ObjectToSpawn;
    public bool AttachWithLine = false;

    private LineRenderer lineRenderer;

    public void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = TotalIterations;

        for (int i = 0; i <= TotalIterations; i++)
        {
            float currentPi = ((Mathf.PI * 2) / TotalIterations) * i;
            var point = CalculatePoint(Radius, r, p, currentPi);

            lineRenderer.SetPosition(i, point);

            var newObject = GameObject.Instantiate(ObjectToSpawn, point, Quaternion.identity, this.transform);
            newObject.name = String.Format("#{0}@{1}", i, currentPi);
        }

        lineRenderer.enabled = AttachWithLine;
    }

    public Vector2 CalculatePoint(float R, float r, float p, float pi)
    {
        pi = Mathf.Clamp(pi, 0, Mathf.PI * 2);

        return new Vector2
        {
            x = (R + r) * Mathf.Cos(pi) + (r + p) * Mathf.Cos(((R + r) / r) * pi),
            y = (R + r) * Mathf.Sin(pi) - (r + p) * Mathf.Sin(((R + r) / r) * pi)
        };
    }
}
