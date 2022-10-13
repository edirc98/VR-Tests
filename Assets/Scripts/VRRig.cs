using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 PosOffset;
    public Vector3 RotOffset; 

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(PosOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(RotOffset);
    }
}
public class VRRig : MonoBehaviour
{
    public VRMap head; 
    public VRMap leftHand;
    public VRMap rightHand; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
