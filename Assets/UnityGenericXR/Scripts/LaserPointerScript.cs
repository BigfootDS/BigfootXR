using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerScript : MonoBehaviour {

    public Vector3 laserStartPos;
    public float laserMaxRange = 5000;
    public Vector3 laserEndPos;
    RaycastHit laserHitInfo;
    public LineRenderer thisLineRenderer;
    public GameObject pointerBall;
    

    public GameObject objectHitByLaser;

    private void Awake()
    {
     
        thisLineRenderer = GetComponent<LineRenderer>();
        pointerBall = transform.GetChild(0).gameObject;
       
        
       
    }

    private void Update()
    {
        thisLineRenderer.SetPosition(0, transform.position);
    }

    private void FixedUpdate()
    {
        if (UnityGenericXRManager.ugxrm.isLeftSideSqueezed && transform.parent.parent.parent.name == "Left Controller"){
            DrawTeleporter();

        } else if (UnityGenericXRManager.ugxrm.isRightSideSqueezed && transform.parent.parent.parent.name == "Right Controller"){
            DrawLaserPointer();

        }
        else {
            thisLineRenderer.SetPosition(1, transform.position);
            pointerBall.transform.position = transform.position;

        }




    }

    public void DrawLaserPointer ()
    {
        int layerMask = 1 << 2;
        layerMask = ~layerMask;
        if (Physics.Raycast(transform.position, transform.forward, out laserHitInfo, laserMaxRange, layerMask))
        {
            thisLineRenderer.SetPosition(1, laserHitInfo.point);
        }
        else
        {
            thisLineRenderer.SetPosition(1, transform.forward * laserMaxRange);
        }
        pointerBall.transform.position = thisLineRenderer.GetPosition(1);
    }


    public void DrawTeleporter()
    {
        int layerMask = 1 << 2;
        layerMask = ~layerMask;
        if (Physics.Raycast(transform.position, transform.forward, out laserHitInfo, laserMaxRange, layerMask))
        {
            thisLineRenderer.SetPosition(1, laserHitInfo.point);
        }
        else
        {
            thisLineRenderer.SetPosition(1, transform.forward * laserMaxRange);
            laserHitInfo = new RaycastHit();
        }
        pointerBall.transform.position = thisLineRenderer.GetPosition(1);

        if (!UnityGenericXRManager.ugxrm.isLeftTriggerSqueezed)
        {
            UnityGenericXRManager.ugxrm.teleporterOBJ.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
            if (laserHitInfo.collider != null)
            {
                UnityGenericXRManager.ugxrm.transform.position = UnityGenericXRManager.ugxrm.teleporterOBJ.transform.position;
            }
        }
        else
        {


            UnityGenericXRManager.ugxrm.teleporterOBJ.transform.position = thisLineRenderer.GetPosition(1);
            UnityGenericXRManager.ugxrm.teleporterOBJ.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }

}
