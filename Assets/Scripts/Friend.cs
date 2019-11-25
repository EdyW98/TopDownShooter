using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Friend : Entity
{
    public int dmgOnDeath;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void Die()
    {
        player.addPlayerHP(dmgOnDeath);
        player.takeDamage(dmgOnDeath);
        base.Die();
    }
}
