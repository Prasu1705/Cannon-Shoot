using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime = 0.7f;
    
    // Update is called once per frame
    void Update()
    {
        if(lifeTime>0)
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime<=0)
            {
                Destruction();
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            Update();
        }
    }
    void Destruction()
    {
        Destroy(this.gameObject);
    }
}
