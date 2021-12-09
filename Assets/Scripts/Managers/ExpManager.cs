using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ExpManager
{
public static int CalculateXP(Enemy e)

    {
    // XP = char level times 5 plus 45 where car level = mob level for mbs
    int baseXP = (Player.MyInstance.MyLevel* 5) +45;
    
    return baseXP;
    
    }

}
