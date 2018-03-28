using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [System.Serializable]
    public class CameraRig
    {
        public Vector3 CameraOffset;
        public float CrouchHeight;
        public float Daming;
    }
    
    [SerializeField] CameraRig defaultCamera;
    [SerializeField] CameraRig aimCamera;
    //[SerializeField] CameraRig crouchCamera;

    Transform cameraLockTarget;
    Player localPlayer;


	// Use this for initialization
	void Awake ()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;; 
	}
    void Update()
    {
        if (localPlayer == null)
            return;

        CameraRig cameraRig = defaultCamera;

        if(localPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMING || localPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMEDFIRING)
        {
            cameraRig = aimCamera;
        }

        float targetHeight = cameraRig.CameraOffset.y + (localPlayer.PlayerState.MoveState == PlayerState.EMoveState.CROUCHING ? cameraRig.CrouchHeight : 0);
        Vector3 targetPosition = cameraLockTarget.position +
            localPlayer.transform.forward * cameraRig.CameraOffset.z +
            localPlayer.transform.up * targetHeight +
            localPlayer.transform.right * cameraRig.CameraOffset.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLockTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraRig.Daming * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraRig.Daming * Time.deltaTime);
    }

    private void HandleOnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
        cameraLockTarget = localPlayer.transform.Find("cameraLookTarget");

        if (cameraLockTarget == null)
            cameraLockTarget = localPlayer.transform;
    }
    
}
