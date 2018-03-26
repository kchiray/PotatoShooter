using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

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
    }
}
