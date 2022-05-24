using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] int Damage;
    [SerializeField] int range;
    private RaycastHit Hit;
    [SerializeField] GameObject Bulletimpact;



    [SerializeField] Camera camera;

    [SerializeField] float Firerate;
    [SerializeField] float nexttimetofire;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nexttimetofire)
        {
            shoot();
            nexttimetofire = Time.time + 1f/ Firerate;
        }
      
    }

    private void shoot()
    {
      if(Physics.Raycast(camera.transform.position, camera.transform.forward, out Hit, range))
      {
          GameObject bulletimpact = Instantiate(Bulletimpact, Hit.point, Quaternion.identity);
          

        if (Hit.transform.gameObject.tag == "Enemy")
        {
            Hit.transform.gameObject.GetComponent<EnemyHealth>().TakeDamage(Damage);
            bulletimpact.transform.SetParent(Hit.transform);
        }

            

      }
    }
}
