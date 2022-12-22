using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnergyShield : MonoBehaviour
{
    [SerializeField] private float shakeStrength = 0.03f;
    [SerializeField] private float shakeDuration = 0.25f;
    [SerializeField] private float rippleCooldown = 0.4f;
    [SerializeField] private VisualEffect sparks;

    private Material material;
    private float rippleTime = 100.0f;
    private Coroutine shakeRoutine;
    private Vector3 originalPosition;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        sparks.enabled = false;
    }

    public void GetHit(RaycastHit hit)
    {
        if(rippleTime < rippleCooldown)
        {
            return;
        }

        material.SetVector("_RippleOrigin", hit.textureCoord);
        rippleTime = material.GetFloat("_RippleThickness") * -2.0f;

        if (shakeRoutine != null)
        {
            StopCoroutine(shakeRoutine);
            transform.position = originalPosition;
        }
        originalPosition = transform.position;
        shakeRoutine = StartCoroutine(Shake(hit));
    }

    private void Update()
    {
        rippleTime += Time.deltaTime;
        material.SetFloat("_RippleTime", rippleTime);
    }

    private IEnumerator Shake(RaycastHit hit)
    {
        sparks.transform.position = hit.point;
        sparks.transform.rotation = Quaternion.LookRotation(Vector3.up, hit.normal);
        sparks.enabled = true;
        sparks.Play();

        for(float t = 0.0f; t < shakeDuration; t += Time.deltaTime)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeStrength;
            yield return null;
        }

        transform.position = originalPosition;
    }
}
