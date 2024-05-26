using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform weaponToHold;
    [SerializeField] private Gun startingGun;
    private Gun equippedGun;

    private void Start()
    {
        if(startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    public void EquipGun(Gun gunToEquip)
    {
        if(equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, weaponToHold.position, weaponToHold.rotation) as Gun;
        equippedGun.transform.parent = weaponToHold.transform;
    }

    public void Shoot()
    {
        if(equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}
