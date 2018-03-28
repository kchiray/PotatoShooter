using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField] Texture2D imageAfter;
    [SerializeField] Texture2D imageBefore;
    [SerializeField] int size;
    
    private void OnGUI()
    {
        if(GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMING || 
            GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMEDFIRING)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            screenPosition.y = Screen.height - screenPosition.y;
            GUI.DrawTexture(new Rect(screenPosition.x - size / 2, screenPosition.y - size / 2, size, size), imageAfter);
        }

        Vector3 screenPositionBefore = Camera.main.WorldToScreenPoint(transform.position);
        screenPositionBefore.y = Screen.height - screenPositionBefore.y;
        GUI.DrawTexture(new Rect(screenPositionBefore.x - size / 2, screenPositionBefore.y - size / 2, size, size), imageBefore);


    }
}
