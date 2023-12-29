using UnityEngine;
using TMPro;

public class BulletManager : MonoBehaviour
{
    public int maxBullets = 5;
    private int currentBullets;
    public TextMeshProUGUI bulletText; 

    void Start()
    {
         ResetBullets();
         
    }

    public bool CanShoot()
    {
        return currentBullets > 0;
    }

public void ShootBullet()
{
    if (currentBullets > 0)
    {
        currentBullets--;
        UpdateBulletText(); // Aggiungi questa chiamata
    }
}

public void ReloadBullet(int amount = 3)
{
    currentBullets = Mathf.Min(currentBullets + amount, maxBullets);
    UpdateBulletText(); // Aggiungi questa chiamata
}

public void ResetBullets()
{
    currentBullets = maxBullets;
    UpdateBulletText(); // Aggiungi questa chiamata
}
public void UpdateBulletText()
{
    if (bulletText != null)
    {
        bulletText.text = "Bullets: " + currentBullets.ToString();
    }
}


}
