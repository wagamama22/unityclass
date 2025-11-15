using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    //return the damage value of this damageDealer

    public int GetDamage() 
    {
        return damage;
    }
    //destroys the game object this script is attached to

    public void Hit() 
    {
        Destroy(gameObject);
    }
}
