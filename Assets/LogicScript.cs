using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
   public float offset = 0;

   public float getOffset()
   {
      offset += 100;
      return offset;
   }
}
