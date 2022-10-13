using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class ContinuousMovement : MonoBehaviour
{
    #region public PARAMETERS
    [Header("Input Source")]
    public XRNode inputSource;
    [Header("Parameters")]
    public float movementSpeed = 1.0f;
    public float gravity = -10.0f;
    public float additionalHeigh = 0.2f;
    public LayerMask groundLayer; 
    #endregion

    #region private PARAMETERS
    private Vector2 _inputAxis;
    private CharacterController _character;
    private XRRig _rig;
    private float _fallingSpeed; 
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<XRRig>();
        _character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out _inputAxis);
    }
    private void FixedUpdate()
    {
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0, _rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 dir = headYaw * new Vector3(_inputAxis.x, 0, _inputAxis.y);
        _character.Move(dir * Time.fixedDeltaTime * movementSpeed);

        //Gravity Falling
        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
        {
            _fallingSpeed = 0;

        }
        else
        {
            _fallingSpeed += gravity * Time.fixedDeltaTime;
        }

        _character.Move(Vector3.up * _fallingSpeed * Time.fixedDeltaTime);
    }

    #region FUNCTIONS
    private bool CheckIfGrounded()
    {
        //Make sphere cast to see if have to fall
        Vector3 rayStart = transform.TransformPoint(_character.center);
        float raylength = _character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, _character.radius, Vector3.down, out RaycastHit hitInfo, raylength, groundLayer);
        return hasHit; 
    }

    private void CapsuleFollowHeadset()
    {
        _character.height = _rig.cameraInRigSpaceHeight + additionalHeigh;
        Vector3 capsuleCenter = transform.InverseTransformPoint(_rig.cameraGameObject.transform.position);
        _character.center = new Vector3(capsuleCenter.x, _character.height / 2, capsuleCenter.z);
    }
    #endregion
}
