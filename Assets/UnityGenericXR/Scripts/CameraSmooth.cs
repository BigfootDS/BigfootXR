/*
 * Imported from the tutorial found online here:
 * http://blog.vikubb.com/2017/07/28/how-to-beautify-the-vr-spectator-camera-and-record-stunning-vr-content-of-your-game/
 * Read it for info about post-processing & making things look good for spectators.
 * This script is a modified version of the smoothing script referenced in the article.
 * The original version of this script relied on external instances & other scripts.
 * This script is self-contained. 
 * Place it on your desired spectator camera and play.
 */

using UnityEngine;
using System.Collections;

public class CameraSmooth: MonoBehaviour
{
    public Camera cameraTarget;
    public Camera cameraSelf;
    public bool enableSmooth = true;

    [Range(0.0f, 12.0f)]
    public float lerpPositionRate = 8.0f;
    [Range(1.0f, 12.0f)]
    public float lerpRotationRate = 4.0f;

    public void Start()
    {
        if (!cameraSelf)
            cameraSelf = GetComponent<Camera>();

        cameraTarget = Camera.main; 
        // Yes, if you change the default Unity camera stuff then this will break.

        // Making sure the spectators get a nice, clean view from their TV or monitor.
        cameraSelf.stereoTargetEye = StereoTargetEyeMask.None;
        cameraSelf.targetDisplay = 0;

        // Copy the VR camera settings where applicable.
        cameraSelf.nearClipPlane = cameraTarget.nearClipPlane;
        cameraSelf.farClipPlane = cameraTarget.farClipPlane;
        cameraSelf.transform.position = cameraTarget.transform.position;
        cameraSelf.transform.rotation = cameraTarget.transform.rotation;

        cameraTarget.targetDisplay = 0;
    }

    public void FixedUpdate()
    {
        if (!cameraTarget)
            return;

        var posRate = lerpPositionRate;
        var rotRate = lerpRotationRate;

        if (enableSmooth)
        {
            // Smoothing is recommended. Read the tutorial-article linked at the start for info.
            transform.position = Vector3.Lerp(transform.position, cameraTarget.transform.position, Mathf.Clamp01(posRate * Time.fixedDeltaTime));
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraTarget.transform.rotation, Mathf.Clamp01(rotRate * Time.fixedDeltaTime));
        }
        else
        {
            transform.position = cameraTarget.transform.position;
            transform.rotation = cameraTarget.transform.rotation;
        }
    }
}