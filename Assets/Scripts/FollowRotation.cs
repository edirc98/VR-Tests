using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.localRotation = new Quaternion(0, 0,-rightHand.transform.localRotation.z,1);
    }


}
