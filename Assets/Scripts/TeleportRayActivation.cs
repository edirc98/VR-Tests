using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; 

public class TeleportRayActivation : MonoBehaviour
{
    #region Public PARAMETERS
    public XRController teleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;
    #endregion

    public bool enabledTeleport { get; set; } = true; 
    // Update is called once per frame
    void Update()
    {
        if (teleportRay)
        {
            teleportRay.gameObject.SetActive(enabledTeleport && CheckIfRayActive(teleportRay));
        }
    }

    #region FUNCTIONS

    private bool CheckIfRayActive(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActive, activationThreshold);
        return isActive; 
    }
    #endregion
}
