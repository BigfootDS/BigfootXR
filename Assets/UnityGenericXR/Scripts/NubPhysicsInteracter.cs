using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubPhysicsInteracter : MonoBehaviour {

    public Rigidbody thisNubRigi;
    public HingeJoint thisNubHinge;
    public Vector3 thisVelocity;
    public Vector3 posAtPrevFrame;
    public List<Vector3> frameTrackPositions = new List<Vector3>();

    private void Update()
    {
        frameTrackPositions.Add(transform.position);
        if (frameTrackPositions.Count > 15)
        {
            frameTrackPositions.RemoveAt(0);
        }

        thisVelocity = frameTrackPositions[frameTrackPositions.Count-1] - frameTrackPositions[0];

        //thisVelocity = thisNubRigi.velocity;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<InteractableObjectInfo>() != null)
        {
            if (collider.gameObject.GetComponent<InteractableObjectInfo>().canBeInteractedWith)
            {
                if (UnityGenericXRManager.ugxrm.isLeftTriggerSqueezed && transform.parent.parent.name == "Left Controller")
                {
                    //if (collider.gameObject.GetComponent<FixedJoint>() != null)
                    //{
                    //    collider.gameObject.GetComponent<FixedJoint>().connectedBody = thisNubRigi;
                    //}
                    //else
                    //{
                    //    collider.gameObject.AddComponent<FixedJoint>();
                    //    collider.gameObject.GetComponent<FixedJoint>().connectedBody = thisNubRigi;
                    //}

                }
                else if (UnityGenericXRManager.ugxrm.isRightTriggerSqueezed && transform.parent.parent.name == "Right Controller")
                {
                    if (collider.gameObject.GetComponent<FixedJoint>() != null)
                    {
                        collider.gameObject.GetComponent<FixedJoint>().connectedBody = thisNubRigi;
                    }
                    else
                    {
                        collider.gameObject.AddComponent<FixedJoint>();
                        collider.gameObject.GetComponent<FixedJoint>().connectedBody = thisNubRigi;
                    }
                }
                else
                {
                    if (collider.gameObject.GetComponent<FixedJoint>() != null)
                    {
                        Destroy(collider.gameObject.GetComponent<FixedJoint>());
                        AddThrowForce(collider.gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractableObjectInfo>() != null)
        {
            Destroy(other.GetComponent<FixedJoint>());
            AddThrowForce(other.gameObject);
        }
    }

    public void AddThrowForce(GameObject thingToThrow)
    {
        thingToThrow.GetComponent<Rigidbody>().velocity = thisVelocity * 10;
        Debug.Log(thingToThrow.name
            + " is being thrown with a velocity of "
            + thingToThrow.GetComponent<Rigidbody>().velocity.ToString()
            + " and should be matching this velocity: " + thisVelocity * 10);
    }


    
}
