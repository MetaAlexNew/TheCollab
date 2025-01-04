using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Photon.Realtime;

public class FingerAnimations : MonoBehaviour
{
    [Header("Original script made by HuhMonke, edited by Felipe404")]
    public XRNode hand = XRNode.RightHand;
    public float thumbMoveSpeed = 0.1f;

    private Animator animator;
    private InputDevice inputDevice;

    public string TriggerR = "pose1";
    public string GripR = "pose2";
    public string ThumbR = "pose3";
    [Header("For Left Hand")]
    public string TriggerL = "pose4";
    public string GripL = "pose5";
    public string ThumbL = "pose6";

    private float pose1Value;
    private float pose2Value;
    private float pose3Value;
    private float pose4Value;
    private float pose5Value;
    private float pose6Value;


    public bool testAnimations = false;
    [Range(0, 1)]
    [SerializeField] private float test1;
    [Range(0, 1)]
    [SerializeField] private float test2;
    [Range(0, 1)]
    [SerializeField] private float test3;
    [Range(0, 1)]
    [SerializeField] private float test4;
    [Range(0, 1)]
    [SerializeField] private float test5;
    [Range(0, 1)]
    [SerializeField] private float test6;

    public PhotonView view;

    void Start()
    {
        animator = GetComponent<Animator>();
        inputDevice = GetInputDevice();

        if(TriggerR == null)
        {
            Debug.Log("Not Set" + TriggerR);
        }
        if (GripR == null)
        {
            Debug.Log("Not Set" + GripR);
        }
        if (ThumbR == null)
        {
            Debug.Log("Not Set" + ThumbR);
        }
        if (TriggerL == null)
        {
            Debug.Log("Not Set" + TriggerL);
        }
        if (GripL == null)
        {
            Debug.Log("Not Set" + GripL);
        }
        if (ThumbL == null)
        {
            Debug.Log("Not Set" + ThumbL);
        }
    }

    void Update()
    {
        if (view.IsMine && hand == XRNode.RightHand)
        {
            AnimateHand();
        }
        if (!PhotonNetwork.InRoom && hand == XRNode.RightHand)
        {
            AnimateHand();
        }

        if (view.IsMine && hand == XRNode.LeftHand)
        {
            AnimateHandL();
        }
        if (!PhotonNetwork.InRoom && hand == XRNode.LeftHand)
        {
            AnimateHandL();
        }
        if (view.IsMine && testAnimations == true)
        {
            TestHand();
        }
        if (!PhotonNetwork.InRoom && testAnimations == true)
        {
            TestHand();
        }
    }

    InputDevice GetInputDevice()
    {
        InputDeviceCharacteristics controllerCharacteristic = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller;

        if (hand == XRNode.LeftHand)
        {
            controllerCharacteristic |= InputDeviceCharacteristics.Left;
        }
        else if (hand == XRNode.RightHand)
        {
            controllerCharacteristic |= InputDeviceCharacteristics.Right;
        }

        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristic, inputDevices);

        if (inputDevices.Count > 0)
        {
            return inputDevices[0];
        }
        else
        {
            return default;
        }
    }

    void AnimateHand()
    {
        if (inputDevice.isValid)
        {
            inputDevice.TryGetFeatureValue(CommonUsages.trigger, out pose1Value);
            inputDevice.TryGetFeatureValue(CommonUsages.grip, out pose2Value);

            inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton);
            inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButton);

            if (primaryButton || secondaryButton)
            {
                pose3Value += thumbMoveSpeed;
            }
            else
            {
                pose3Value -= thumbMoveSpeed;
            }

            pose3Value = Mathf.Clamp(pose3Value, 0, 1);

            animator.SetFloat(TriggerR, pose1Value);
            animator.SetFloat(GripR, pose2Value);
            animator.SetFloat(ThumbR, pose3Value);

        }
    }

    void AnimateHandL()
    {
        if (inputDevice.isValid)
        {
            inputDevice.TryGetFeatureValue(CommonUsages.trigger, out pose4Value);
            inputDevice.TryGetFeatureValue(CommonUsages.grip, out pose5Value);

            inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton);
            inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButton);

            if (primaryButton || secondaryButton)
            {
                pose6Value += thumbMoveSpeed;
            }
            else
            {
                pose6Value -= thumbMoveSpeed;
            }

            pose6Value = Mathf.Clamp(pose6Value, 0, 1);

            animator.SetFloat(TriggerL, pose4Value);
            animator.SetFloat(GripL, pose5Value);
            animator.SetFloat(ThumbL, pose6Value);

        }
    }

    void TestHand()
    {
        
            animator.SetFloat(TriggerR, test1);
            animator.SetFloat(GripR, test2);
            animator.SetFloat(ThumbR, test3);


            animator.SetFloat(TriggerL, test4);
            animator.SetFloat(GripL, test5);
            animator.SetFloat(ThumbL, test6);
        
        
    }
}
