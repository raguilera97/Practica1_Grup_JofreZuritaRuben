using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatTrigger : MonoBehaviour
{
    public BattleSystem batSys;

    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc;
        pc = other.gameObject.GetComponent<PlayerController>();
        if (pc)
        {
            batSys.state = BattleState.START;
            batSys.battleStarts();
            Destroy(this.gameObject);
        }
    }
}
