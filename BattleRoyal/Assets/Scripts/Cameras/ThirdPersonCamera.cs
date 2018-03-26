using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField]
    Vector3 offset;
    [SerializeField]
    float damping;

    Transform cameraLockTarget;

    public Player localPlayer;
	// Use this for initialization
	void Awake ()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;; 
	}
    void Update()
    {
        Vector3 targetPosition = cameraLockTarget.position +
            localPlayer.transform.forward * offset.z +
            localPlayer.transform.up * offset.y +
            localPlayer.transform.right * offset.x;

        Quaternion targetRotation = Quaternion.LookRotation(cameraLockTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
    }

    private void HandleOnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
        cameraLockTarget = localPlayer.transform.Find("cameraLookTarget");

        if (cameraLockTarget == null)
            cameraLockTarget = localPlayer.transform;
    }
    
}
