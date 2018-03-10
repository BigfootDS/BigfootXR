using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerInteractorScript : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        
        if (transform.parent.parent.parent.parent.name == "Left Controller" 
            && UnityGenericXRManager.ugxrm.isLeftTriggerSqueezed 
            && UnityGenericXRManager.ugxrm.isLeftSideSqueezed)
        {
            if (other.GetComponent<Button>() != null)
            {
                other.GetComponent<Button>().onClick.Invoke();
            } else
            {
                // checking for other possible scripts go here
            }
        } else if (transform.parent.parent.parent.parent.name == "Right Controller"
            && UnityGenericXRManager.ugxrm.isRightTriggerSqueezed
            && UnityGenericXRManager.ugxrm.isRightSideSqueezed)
        {
            if (other.GetComponent<Button>() != null)
            {
                other.GetComponent<Button>().onClick.Invoke();
            }
            else
            {
                // checking for other possible scripts go here
            }
        }
    }
}
