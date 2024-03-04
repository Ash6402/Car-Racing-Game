using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
   public float offset = 0;
   public GameObject gameOverScreen;

   public float getOffset()
   {
      offset += 400;
      return offset;
   }

   public void Restart()
   {
      SceneManager.LoadScene("SampleScene");
   }

   public void GameOver()
   {
      gameOverScreen.SetActive(true);
   }
}
