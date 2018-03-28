using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    private CombatAim m_playerAim;
    private CombatAim playerAim
    {
        get
        {
            if (m_playerAim == null)
                m_playerAim = GameManager.Instance.LocalPlayer.playerAim;

            return m_playerAim;
        }
    }

    
    
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("Vertical", GameManager.Instance.InputController.Vertical);
        anim.SetFloat("Horizontal", GameManager.Instance.InputController.Horizontal);

        anim.SetBool("IsSprinting", GameManager.Instance.InputController.IsSprinting);
        anim.SetBool("IsCrouching", GameManager.Instance.InputController.IsCrouched);

        anim.SetFloat("AimAngle", playerAim.GetAngle());
        anim.SetBool("IsAiming", GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMING ||
            GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMEDFIRING);
    }
}
