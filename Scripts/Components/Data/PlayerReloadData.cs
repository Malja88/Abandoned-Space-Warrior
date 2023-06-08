using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReloadData : MonoBehaviour, IAbility
{
    public PlayerShootData shootData;
    public AmmoBar ammoBar;
    public GameObject reloadingIcon;
    [SerializeField] public float reloadingTime;
    public void Execute()
    {
        if (shootData.currentAmmo <= 0)
        {
            StartCoroutine(RealoadTime());
        }
    }

    private IEnumerator RealoadTime()
    {
        reloadingIcon.SetActive(true);
        yield return new WaitForSeconds(reloadingTime);
        ammoBar.SetMaxAmmo(shootData.maxAmmo);
        shootData.currentAmmo = shootData.maxAmmo;
        shootData.shootDelay = 0.3f;
        reloadingIcon.SetActive(false);
    }
}
