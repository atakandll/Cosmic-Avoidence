using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathState : BossBaseState
{
   public override void RunState()
   {
      EndGameManager.instance.possibleWin = true;
      EndGameManager.instance.StartResolveSequence();
      Destroy(gameObject);
   }
}
