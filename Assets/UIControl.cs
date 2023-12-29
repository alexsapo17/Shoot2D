using UnityEngine;
public class UIControl : MonoBehaviour
{
    private WeaponController weaponController;
    private PlayerController playerController;

    void Update()
    {
        if (weaponController == null)
        {
            weaponController = FindObjectOfType<WeaponController>();
        }
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }
    } 

    public void OnShootButtonPressed()
    {
        if (weaponController != null && weaponController.bulletManager.CanShoot())
        {
            weaponController.ShootButtonPressed();
        }
    }

    public void OnFlipButtonPressed()
    {
        if (playerController != null)
        {
            playerController.FlipButtonPressed();
        }
    }
}
