using UnityEngine;

public class Wood : Material
{
   public void Start()
   {
      materialName = "Wood";
 
   }
   public override void Activate(){
      Debug.Log("Wood activated");
   }
}
