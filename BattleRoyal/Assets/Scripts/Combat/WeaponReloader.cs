using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour {

    [SerializeField] internal int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] int clipSize;
    [SerializeField] Container Inventory;
    
    public int shotsFiredInClip;
    bool isReloading;

    System.Guid containerItemId;

    public event System.Action OnAmmoChanged;

    private void Awake()
    {
        Inventory.OnContainerReady += () =>
        {
            containerItemId = Inventory.Add(this.name, maxAmmo);
        };
        
    }

    public int RoundsRemainingInClip
    {
        get
        {
            return clipSize - shotsFiredInClip;
        }
    }
    public int RoundsRemainingInInventory
    {
        get
        {
            return Inventory.GetAmountRemaining(containerItemId);
        }
    }

    public bool IsReloading
    {
        get
        {
            return isReloading;
        }
    }

    public void Reload()
    {
        if (isReloading)
            return;

        isReloading = true;

        GameManager.Instance.Timer.Add(() => {
            ExecuteReload(Inventory.TakeFromContainer(containerItemId, clipSize - RoundsRemainingInClip));
        }, reloadTime);
        
    }

    private void ExecuteReload(int amount)
    {        
        isReloading = false;
        shotsFiredInClip -= amount;
        if (OnAmmoChanged != null)
            OnAmmoChanged();
    }

    public void TakeFromClip(int amount)
    {
        shotsFiredInClip += amount;
        if (OnAmmoChanged != null)
            OnAmmoChanged();
    }
}
