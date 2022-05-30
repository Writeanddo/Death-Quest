using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHealth;
    [SerializeField] int CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

   public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if(CurrentHealth <= 0)
        {
            DIE();
        }
    }


   void DIE()
    {
        Destroy(gameObject.transform.parent.gameObject);
        AudioManager.instance.playsound(7);
    }

}
