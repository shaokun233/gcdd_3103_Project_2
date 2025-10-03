using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Items/Weapon")]

public class Weapon : Item
{
    public int Danmage;
    
    public override void Use(Transform tf)
    {
        GameObject temp = Instantiate(item, tf.position, tf.rotation);
        temp.GetComponent<bullet>().weapon_data = this;
    }
   
}
