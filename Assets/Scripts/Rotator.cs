using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 Force;

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(Force * Time.deltaTime);
	}
}
