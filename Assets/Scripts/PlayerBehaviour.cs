using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float damageCooldown = 2f;
    public float regenDelay = 10f; // Time before regen starts
    public float regenRate = 5f;  // Health per second

    private bool canTakeDamage = true;
    private bool isRegenerating = false;
    private float timeSinceLastHit = 0f;

    void Update()
    {
        // Track time since last hit
        timeSinceLastHit += Time.deltaTime;

        // Start regenerating if not already doing so and enough time has passed
        if (!isRegenerating && timeSinceLastHit >= regenDelay)
        {
            StartCoroutine(RegenHealth());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && canTakeDamage)
        {
            TakeDamage(20); // Calls both damage + cooldown logic
        }
    }

    public void TakeDamage(int dmg)
    {
        PlayerTakeDmg(dmg);
        StartCoroutine(DamageCooldown());

        // Reset regen delay
        timeSinceLastHit = 0f;

        if (isRegenerating)
        {
            StopCoroutine(RegenHealth());
            isRegenerating = false;
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

    public bool CanBeDamaged()
    {
        return canTakeDamage;
    }

    private IEnumerator RegenHealth()
    {
        isRegenerating = true;

        while (GameManager.gameManager.playerHealth.Health < GameManager.gameManager.playerHealth.MaxHealth)
        {
            PlayerHeal(1);
            yield return new WaitForSeconds(1f / regenRate); // Control regen speed
        }

        isRegenerating = false;
    }
}