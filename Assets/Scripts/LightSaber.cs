using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _saberAnimator; 
    void Start()
    {
         _saberAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void TriggerSaber()
    {
        bool isOpen = _saberAnimator.GetBool("IsOpen");
        _saberAnimator.SetBool("IsOpen",!isOpen);
    }
}
