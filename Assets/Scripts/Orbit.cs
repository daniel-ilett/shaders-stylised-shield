using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private Transform orbitObject;
    [SerializeField] private float orbitSize;
    [SerializeField] private float orbitOffset;
    [SerializeField] private float orbitSpeed;

    private void Update()
    {
        if (!Input.GetButton("Fire1"))
        {
            var time = Time.time * Mathf.PI * orbitSpeed;

            var xPos = orbitObject.position.x + Mathf.Sin(time) * orbitSize;
            var yPos = orbitObject.position.y + orbitOffset;
            var zPos = orbitObject.position.z + Mathf.Cos(time) * orbitSize;

            transform.position = new Vector3(xPos, yPos, zPos);
            transform.LookAt(orbitObject);
        }
    }
}
