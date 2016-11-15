using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public GameObject shellExplosion;


    public float lifeTime;

    void OnTriggerEnter(Collider collider)
    {
        if(collider!=null&&collider.tag!="Shell")
        {
            GameObject explosion = Instantiate(shellExplosion,
                                   gameObject.transform.position,
                                   Quaternion.identity) as GameObject;

            Destroy(explosion,lifeTime);

            Destroy(gameObject);
        }
    }
	
}
