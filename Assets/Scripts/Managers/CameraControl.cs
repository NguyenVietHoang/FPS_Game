using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CAMERA_MODE
{
    TOP_DOWN,
    SIDE,
}

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private CameraPivot PlayerCamera;

    [Range (0.5f, 5f)]
    public float transitionSpeed = 2.0f;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerCamera.sideView;
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerCamTr = PlayerCamera.mainCamera.transform;
        playerCamTr.position = Vector3.Lerp(playerCamTr.position, target.position, Time.deltaTime * transitionSpeed);
        playerCamTr.transform.rotation = Quaternion.Slerp(playerCamTr.rotation, target.rotation, Time.deltaTime * transitionSpeed);
    }

    /// <summary>
    /// Switch Camera mode to Top down or Side View
    /// </summary>
    /// <param name="mode"></param>
    public void SwitchCameraMode(CAMERA_MODE mode)
    {
        switch (mode)
        {
            case CAMERA_MODE.TOP_DOWN:
                target = PlayerCamera.topdownView;
                break;
            case CAMERA_MODE.SIDE:
                target = PlayerCamera.sideView;
                break;
            default:
                target = PlayerCamera.sideView;
                break;
        }
    }
}
