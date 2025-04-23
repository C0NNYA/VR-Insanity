using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager.playerHealth.DmgUnit(dmg);
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager.playerHealth.HealUnit(healing);
    }
}
