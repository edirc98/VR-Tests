using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{
    public GameObject ActivationObject; 
    public float ActivationThreshold = 0.3f;
    private ParticleSystem sys; 
    private HingeJoint _leverHJ;
    private float _minLimUp;
    private float _minLim; 
    private float _minLimDown;

    private bool entered = false; 
    // Start is called before the first frame update
    void Start()
    {
        _leverHJ = gameObject.GetComponent<HingeJoint>();
        _minLim = (360 + _leverHJ.limits.min); // Is a "+" because limits.min is a negative number
        _minLimUp = _minLim + ActivationThreshold;
        _minLimDown = _minLim - ActivationThreshold;
        sys = ActivationObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {


        if(transform.eulerAngles.z < _minLimUp && transform.eulerAngles.z > _minLimDown && !entered )
        {
            sys.Play();
            entered = true; 
        }
        //Check if the lever have exited the activation zone beign grater than the up limit
        if(transform.eulerAngles.z > _minLimUp)
        {
            entered = false; 
        }


        
    }
}
