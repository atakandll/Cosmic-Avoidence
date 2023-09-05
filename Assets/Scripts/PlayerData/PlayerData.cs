using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PlayerData/PowerUpSpawner", fileName = "Spawner")]
public class PlayerData :ScriptableObject
{
   public int spawnTreshold;
   public GameObject[] powerUp;

   public void SpawnPowerUp(Vector3 spawnPos)
   {
      int randomChance = Random.Range(0, 100);
      if (randomChance > spawnTreshold)
      {
         int randomPowerUp = Random.Range(0, powerUp.Length);
      
         Instantiate(powerUp[randomPowerUp], spawnPos, Quaternion.identity);
      }
     
   }
}
