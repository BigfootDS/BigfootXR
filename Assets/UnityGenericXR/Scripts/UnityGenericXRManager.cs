using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;




public enum ActiveVRFamily { Oculus, Vive, Windows };


public class UnityGenericXRManager : MonoBehaviour {
    public static UnityGenericXRManager ugxrm;

    public string detectedHMD = "";
    public ActiveVRFamily activeVRHMD;

    public Transform leftController;
    public Transform leftAimingNub;
    public Transform rightController;
    public Transform rightAimingNub;

    public Vector3 oculusTouchOffset;
    public Vector3 ViveOffset;
    public Vector3 WindowsVROffset;

    public bool isLeftTriggerSqueezed;
    public bool isRightTriggerSqueezed;
    public bool isLeftSideSqueezed;
    public bool isRightSideSqueezed;

    [Header("Player Variables")]
    public float playerMovementSpeed = 5.0f;

    [Header("VR Extras")]
    public GameObject teleporterOBJ;


    private void Awake()
    {
        ugxrm = this;
        detectedHMD = XRDevice.model;
        if (teleporterOBJ != null)
        {
            teleporterOBJ.transform.parent = transform.parent; // let the teleporter parent become the world
        }
        if (detectedHMD.ToLower().Contains("vive"))
        {
            // Must be a Vive headset.
            activeVRHMD = ActiveVRFamily.Vive;
            leftAimingNub.localEulerAngles += ViveOffset;
            rightAimingNub.localEulerAngles += ViveOffset;
        }
        else if (detectedHMD.ToLower().Contains("oculus"))
        {
            // Must be an Oculus headset.
            activeVRHMD = ActiveVRFamily.Oculus;
            leftAimingNub.localEulerAngles += oculusTouchOffset;
            rightAimingNub.localEulerAngles += oculusTouchOffset;
        }
        else
        {
            // Must be a Windows VR headset.
            activeVRHMD = ActiveVRFamily.Windows;
            leftAimingNub.localEulerAngles += WindowsVROffset;
            rightAimingNub.localEulerAngles += WindowsVROffset;
        }
        Debug.Log("Detected a VR headset. Adjusted the controllers' lasers accordingly for precise aiming. The HMD is a " + detectedHMD);
    }


    void Update () {
		switch (activeVRHMD)
        {
            case ActiveVRFamily.Oculus:
                // ABXY & Menus
                if (Input.GetButton("Oculus-ButtonPressA"))
                {
                    Debug.Log("Pressing the Oculus A button.");
                }
                if (Input.GetButton("Oculus-ButtonTouchA"))
                {
                    Debug.Log("Touching the Oculus A button.");
                }
                if (Input.GetButton("Oculus-ButtonPressB"))
                {
                    Debug.Log("Pressing the Oculus B button.");
                }
                if (Input.GetButton("Oculus-ButtonTouchB"))
                {
                    Debug.Log("Touching the Oculus B button.");
                }
                if (Input.GetButton("Oculus-ButtonPressX"))
                {
                    Debug.Log("Pressing the Oculus X button.");
                }
                if (Input.GetButton("Oculus-ButtonTouchX"))
                {
                    Debug.Log("Touching the Oculus X button.");
                }
                if (Input.GetButton("Oculus-ButtonPressY"))
                {
                    Debug.Log("Pressing the Oculus Y button.");
                }
                if (Input.GetButton("Oculus-ButtonTouchY"))
                {
                    Debug.Log("Touching the Oculus Y button.");
                }
                if (Input.GetButton("Oculus-ButtonPressStart"))
                {
                    Debug.Log("Pressing the Oculus Start button.");
                }
                // Thumbsticks & thumbrests
                if (Input.GetButton("Oculus-LeftThumbstickPress"))
                {
                    Debug.Log("Pressing the Oculus Touch left thumbstick button.");
                }
                if (Input.GetButton("Oculus-LeftThumbstickTouch"))
                {
                    Debug.Log("Touching the Oculus Touch left thumbstick button.");
                }
                if (Input.GetAxis("Oculus-LeftThumbstickNearTouch") != 0)
                {
                    Debug.Log("User is nearly touching the Oculus Touch left thumbstick button.");
                }
                if (Input.GetButton("Oculus-RightThumbstickPress"))
                {
                    Debug.Log("Pressing the Oculus Touch right thumbstick button.");
                }
                if (Input.GetButton("Oculus-RightThumbstickTouch"))
                {
                    Debug.Log("Touching the Oculus Touch right thumbstick button.");
                }
                if (Input.GetAxis("Oculus-RightThumbstickNearTouch") != 0)
                {
                    Debug.Log("User is nearly touching the Oculus Touch right thumbstick button.");
                }
                if (Input.GetButton("Oculus-RightThumbrestTouch"))
                {
                    Debug.Log("Touching the Oculus Touch right thumbrest.");
                }
                if (Input.GetAxis("Oculus-RightThumbrestNearTouch") != 0)
                {
                    Debug.Log("User is nearly touching the Oculus Touch right thumbrest.");
                }
                if (Input.GetButton("Oculus-LeftThumbrestTouch"))
                {
                    Debug.Log("Touching the Oculus Touch left thumbrest.");
                }
                if (Input.GetAxis("Oculus-LeftThumbrestNearTouch") != 0)
                {
                    Debug.Log("User is nearly touching the Oculus Touch left thumbrest.");
                }

                if (Input.GetAxis("Oculus-LeftThumbstickHorizontal") != 0)
                {
                    Debug.Log("User is moving the left Oculus Touch thumbstick horizontally.");
                }
                if (Input.GetAxis("Oculus-LeftThumbstickVertical") != 0)
                {
                    Debug.Log("User is moving the left Oculus Touch thumbstick vertically.");
                }

                if (Input.GetAxis("Oculus-RightThumbstickHorizontal") != 0)
                {
                    Debug.Log("User is moving the right Oculus Touch thumbstick horizontally.");
                }
                if (Input.GetAxis("Oculus-RightThumbstickVertical") != 0)
                {
                    Debug.Log("User is moving the right Oculus Touch thumbstick vertically.");
                }

                // Triggers
                if (Input.GetButton("Oculus-LeftIndexTriggerTouch"))
                {
                    Debug.Log("Touching the Oculus Touch left trigger.");
                }
                if (Input.GetAxis("Oculus-LeftIndexTriggerNearTouch") != 0)
                {
                    Debug.Log("User is nearly touching the Oculus Touch left trigger.");
                }
                if (Input.GetAxis("Oculus-LeftIndexTriggerSqueeze") != 0)
                {
                    isLeftTriggerSqueezed = true;
                    Debug.Log("User is squeezing the left Oculus Touch trigger.");
                } else
                {
                    isLeftTriggerSqueezed = false;
                }
                if (Input.GetButton("Oculus-RightIndexTriggerTouch"))
                {
                    Debug.Log("Touching the Oculus Touch right trigger.");
                }
                if (Input.GetAxis("Oculus-RightIndexTriggerNearTouch") != 0)
                {
                    Debug.Log("User is nearly touching the Oculus Touch right trigger.");
                }
                if (Input.GetAxis("Oculus-RightIndexTriggerSqueeze") != 0)
                {
                    isRightTriggerSqueezed = true;
                    Debug.Log("User is squeezing the right Oculus Touch trigger.");
                } else
                {
                    isRightTriggerSqueezed = false;
                }
                if (Input.GetAxis("Oculus-LeftHandTriggerSqueeze") != 0)
                { 
                    isLeftSideSqueezed = true;
                    Debug.Log("User is squeezing the left Oculus Touch hand trigger.");
                } else
                {
                     isLeftSideSqueezed = false;
                }
                if (Input.GetAxis("Oculus-RightHandTriggerSqueeze") != 0)
                {
                    isRightSideSqueezed = true;
                    Debug.Log("User is squeezing the right Oculus Touch hand trigger.");
                } else
                {
                    isRightSideSqueezed = false;
                }

                break;
            case ActiveVRFamily.Vive:

                // Vive menu buttons
                if (Input.GetButton("OpenVR-LeftViveMenuOculusXButton"))
                {
                    Debug.Log("Touching the left Vive menu button or Oculus X button.");
                }
                if (Input.GetButton("OpenVR-RightViveMenuOculusA"))
                {
                    Debug.Log("Touching the right Vive menu button or Oculus A button now.");
                }

                // Vive trackpads
                if (Input.GetButton("OpenVR-LeftViveTrackpadOculusThumbstickClick"))
                {
                    Debug.Log("Clicking the left Vive trackpad or left Oculus Touch thumbstick now.");
                }
                if (Input.GetButton("OpenVR-RightViveTrackpadOculusThumbstickClick"))
                {
                    Debug.Log("Clicking the right Vive trackpad or right Oculus Touch thumbstick now.");
                }
                if (Input.GetButton("OpenVR-LeftViveTrackpadOculusThumbstickTouch"))
                {
                    Debug.Log("Touching the left trackpad or thumbstick now.");
                }
                if (Input.GetButton("OpenVR-RightViveTrackpadOculusThumbstickTouch"))
                {
                    Debug.Log("Touching the right trackpad or thumbstick now.");
                }
                if (Input.GetAxis("OpenVR-LeftViveTrackpadOculusThumbstickHorizontal") != 0)
                {
                    Debug.Log("Moving on the X axis of the left Vive trackpad or Oculus Touch thumbstick now.");
                }
                if (Input.GetAxis("OpenVR-LeftViveTrackpadOculusThumbstickVertical") != 0)
                {
                    Debug.Log("Moving on the Y axis of the left Vive trackpad or Oculus Touch thumbstick now.");
                }
                if (Input.GetAxis("OpenVR-RightViveTrackpadOculusThumbstickHorizontal") != 0)
                {
                    Debug.Log("Moving on the X axis of the right Vive trackpad or Oculus Touch thumbstick now.");
                }
                if (Input.GetAxis("OpenVR-RightViveTrackpadOculusThumbstickVertical") != 0)
                {
                    Debug.Log("Moving on the Y axis of the right Vive trackpad or Oculus Touch thumbstick now.");
                }

                // Triggers
                if (Input.GetButton("OpenVR-LeftViveTriggerPressOculusTriggerTouch"))
                {
                    Debug.Log("Pressing the left Vive trigger or touching the right Oculus Touch trigger now.");
                }
                if (Input.GetButton("OpenVR-RightViveTriggerPressOculusTriggerTouch"))
                {
                    Debug.Log("Pressing the right Vive trigger or touching the right Oculus Touch trigger now.");
                }
                if (Input.GetAxis("OpenVR-LeftViveTriggerOculusTriggerSqueeze") != 0)
                {
                    isLeftTriggerSqueezed = true;
                    Debug.Log("Squeezing the left main trigger now.");
                } else
                {
                    isLeftTriggerSqueezed = false;
                }
                if (Input.GetAxis("OpenVR-RightViveTriggerOculusTriggerSqueeze") != 0)
                {
                    isRightTriggerSqueezed = true;
                    Debug.Log("Squeezing the right main trigger now.");
                } else
                {
                    isRightTriggerSqueezed = false;
                }
                if (Input.GetAxis("OpenVR-LeftViveGripOculusHandTrigger") != 0)
                {
                    isLeftSideSqueezed = true;
                    Debug.Log("Squeezing the left secondary trigger now.");
                } else
                {
                    isLeftSideSqueezed = false;
                }
                if (Input.GetAxis("OpenVR-RightViveGripOculusHandTrigger") != 0)
                {
                    isRightSideSqueezed = true;
                    Debug.Log("Squeezing the right secondary trigger now.");
                } else
                {
                    isRightSideSqueezed = false;
                }
                break;
            case ActiveVRFamily.Windows:
                
                // Touchpads
                if (Input.GetButton("WMR-LeftTouchpadTouch"))
                {
                    Debug.Log("Touching the left touchpad now.");
                }
                if (Input.GetButton("WMR-RightTouchpadTouch"))
                {
                    Debug.Log("Touching the right touchpad now.");
                }
                if (Input.GetButton("WMR-LeftTouchpadPress"))
                {
                    Debug.Log("Pressing the left touchpad now.");
                }
                if (Input.GetButton("WMR-RightTouchpadPress"))
                {
                    Debug.Log("Pressing the left trigger now.");
                }
                if (Input.GetAxis("WMR-LeftTouchpadHorizontal") != 0)
                {
                    Debug.Log("Moving on the left touchpad horizontally.");
                }
                if (Input.GetAxis("WMR-RightTouchpadHorizontal") != 0)
                {
                    Debug.Log("Moving on the right touchpad horizontally.");
                }
                if (Input.GetAxis("WMR-LeftTouchpadVertical") != 0)
                {
                    Debug.Log("Moving on the left touchpad vertically.");
                }
                if (Input.GetAxis("WMR-RightTouchpadVertical") != 0)
                {
                    Debug.Log("Moving on the right touchpad vertically.");
                }

                // Thumbsticks
                if (Input.GetButton("WMR-LeftThumbstickPress"))
                {
                    Debug.Log("Pressing the left thumbstick now.");
                }
                if (Input.GetButton("WMR-RightThumbstickPress"))
                {
                    Debug.Log("Pressing the right thumbstick now.");
                }
                if (Input.GetAxis("WMR-LeftThumbstickHorizontal") != 0)
                {
                    Debug.Log("Moving on the left thumbstick horizontally. Moving the player along the X axis too.");
                }
                if (Input.GetAxis("WMR-RightThumbstickHorizontal") != 0)
                {
                    Debug.Log("Moving on the right thumbstick horizontally.");
                }
                if (Input.GetAxis("WMR-LeftThumbstickVertical") != 0)
                {
                    Debug.Log("Moving on the left thumbstick vertically. Moving the player along the Z axis too.");
                }
                if (Input.GetAxis("WMR-RightThumbstickVertical") != 0)
                {
                    Debug.Log("Moving on the right thumbstick vertically.");
                }

                // Triggers - BACK
                if (Input.GetButton("WMR-RightSelectTriggerPress"))
                {
                    isRightTriggerSqueezed = true;
                    Debug.Log("Pressing the right trigger now.");
                } else
                {
                    isRightTriggerSqueezed = false;
                }
                if (Input.GetButton("WMR-LeftSelectTriggerPress"))
                {
                    isLeftTriggerSqueezed = true;
                    Debug.Log("Pressing the left trigger now.");
                } else
                {
                    isLeftTriggerSqueezed = false;
                }
                if (Input.GetAxis("WMR-RightSelectTriggerSqueeze") != 0)
                {
                    isRightTriggerSqueezed = true;
                    Debug.Log("Squeezing the right trigger now.");
                } else
                {
                    isRightTriggerSqueezed = false; 
                }
                if (Input.GetAxis("WMR-LeftSelectTriggerSqueeze") != 0)
                {
                    isLeftTriggerSqueezed = true;
                    Debug.Log("Squeezing the left trigger now.");
                } else
                {
                    isLeftTriggerSqueezed = false;
                }

                // Triggers - SIDE
                if (Input.GetButton("WMR-RightGripButtonPress"))
                {
                    isRightSideSqueezed = true;
                    Debug.Log("Pressing the right side trigger now.");
                } else
                {
                    isRightSideSqueezed = false;
                }
                if (Input.GetButton("WMR-LeftGripButtonPress"))
                {
                    isLeftSideSqueezed = true;
                    Debug.Log("Pressing the left side trigger now.");
                } else
                {
                    isLeftSideSqueezed = false;
                }
                if (Input.GetAxis("WMR-RightGripButtonSqueeze") != 0)
                {
                    isRightSideSqueezed = true;
                    Debug.Log("Squeezing the right side trigger now.");
                } else
                {
                    isRightSideSqueezed = false;
                }
                if (Input.GetAxis("WMR-LeftGripButtonSqueeze") != 0)
                {
                    isLeftSideSqueezed = true;
                    Debug.Log("Squeezing the left side trigger now.");
                } else
                {
                    isLeftSideSqueezed = false;
                }

                // Menu buttons
                if (Input.GetButton("WMR-LeftMenuButtonPress"))
                {
                    Debug.Log("Pressing the left menu button now.");
                }
                if (Input.GetButton("WMR-RightMenuButtonPress"))
                {
                    Debug.Log("Pressing the right menu button now.");
                }

                break;
            default:
                break;
        }
        
	}
}
