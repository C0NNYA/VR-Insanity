using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float damageCooldown = 2f;
    private bool canTakeDamage = true;

    public bool CanBeDamaged()
    {
        return canTakeDamage;
    }

    public void TakeDamage(int dmg)
    {
        if (canTakeDamage)
        {
            PlayerTakeDmg(dmg);
            StartCoroutine(DamageCooldown());
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager.playerHealth.DmgUnit(dmg);
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager.playerHealth.HealUnit(healing);
    }

    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }
}
