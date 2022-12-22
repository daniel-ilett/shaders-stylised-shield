using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;

        var energyShield = hit.transform.GetComponent<EnergyShield>();

        if (energyShield != null)
        {
            energyShield.GetHit(hit);
        }

        //Renderer rend = hit.transform.GetComponent<Renderer>();
        //MeshCollider meshCollider = hit.collider as MeshCollider;

        //Debug.Log(rend);

        //if (rend == null || rend.sharedMaterial == null || meshCollider == null)
            //return;

        //Texture2D tex = rend.material.mainTexture as Texture2D;
        //Vector2 pixelUV = hit.textureCoord;
        //Debug.Log(pixelUV);
        //pixelUV.x *= tex.width;
        //pixelUV.y *= tex.height;

        //tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
        //tex.Apply();
    }
}
