using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField]Text text;
    
    PlayerShoot playerShoot;
    WeaponReloader reloader;
	// Use this for initialization
	void Awake ()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
	}

    private void HandleOnLocalPlayerJoined(Player player)
    {
        playerShoot = player.PlayerShoot;
        playerShoot.OnWeaponSwitch += HandleOnWeaponSwitch;
    }

    private void HandleOnWeaponSwitch(Shooter activeWeapon)
    {
        reloader = activeWeapon.reloader;
        reloader.OnAmmoChanged += HandleOnAmmoChanged;
        HandleOnAmmoChanged();
    }

    private void HandleOnAmmoChanged()
    {
        int amountInInventory = reloader.RoundsRemainingInInventory;
        int amountInClip = reloader.RoundsRemainingInClip;
        text.text = (amountInClip.ToString() + " | " + amountInInventory.ToString());
    }

    // Update is called once per frame
    void Update () {
		
	}
}
