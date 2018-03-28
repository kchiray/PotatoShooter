using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : PickupItem {

    [SerializeField] EWeaponType weaponType;
    [SerializeField] float respawnerTime;
    [SerializeField] int amount;
    public override void OnPickup(Transform item)
    {
        base.OnPickup(item);
        var playerInventory = item.GetComponentInChildren<Container>();
        GameManager.Instance.Respawner.Despawn(gameObject, respawnerTime);
        playerInventory.Put(weaponType.ToString(), amount);

        item.GetComponent<Player>().PlayerShoot.ActiveWeapon.reloader.HandleOnAmmoChanged();
    }
}
