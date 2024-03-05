using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
   public float offset = 0;
   public GameObject gameOverScreen;
   public Text gameOverMsg;

   public float getOffset()
   {
      offset += 400;
      return offset;
   }

   public void Restart()
   {
      SceneManager.LoadScene("SampleScene");
   }

   public void GameOver(int type)
   {
      if (type == 1)
         gameOverMsg.text = "Out of fuel!!!";
      else
         gameOverMsg.text = "You Crashed!!!";
      gameOverScreen.SetActive(true);
   }
}
