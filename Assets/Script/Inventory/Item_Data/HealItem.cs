using UnityEngine;

[CreateAssetMenu(fileName = "HealItem", menuName = "Scriptable Objects/HealItem")]
public class HealItem : Item
{
    public int healthValue;

    public override void Use(Transform tf)
    {
        if(tf.GetComponent<PlayerC>().MaxHealth< 100 + healthValue)
        {
            tf.GetComponent<PlayerC>().MaxHealth = 100 + healthValue;
            tf.GetComponent<PlayerC>().health += healthValue;
        }
        else
        {
            tf.GetComponent<PlayerC>().health += healthValue;
        }

    }   
}
