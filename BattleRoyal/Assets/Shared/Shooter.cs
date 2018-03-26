using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float rateOfFire;
    [SerializeField] Projectile projectile;
    [SerializeField] public Transform hand;
    [SerializeField] SoundController audioReload;
    [SerializeField] SoundController audioFire;

    float nextFireAllowed;
    public bool canFire;

    public WeaponReloader reloader;
    Transform muzzle;

    

    private void Awake()
    {
        muzzle = transform.Find("Model/Muzzle");
        if(muzzle == null)
        {
            print("muzzle not found");
        }
        reloader = GetComponent<WeaponReloader>();
       
    }

    public void Reload()
    {
        if (reloader == null)
            return;
        reloader.Reload();
        audioReload.Play();
    }
    public virtual void Fire()
    {
        canFire = false;

        if (Time.time < nextFireAllowed)
            return;

        if (reloader != null)
        {
            if (reloader.IsReloading)
                return;
            if (reloader.RoundsRemainingInClip == 1)
                Reload();

            reloader.TakeFromClip(1);
        }

        nextFireAllowed = Time.time + rateOfFire;

        //instantiate the projectile
        Instantiate(projectile, muzzle.position, muzzle.rotation);
        audioFire.Play();
        canFire = true;
    }
    public void Equip()
    {
        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    
}
