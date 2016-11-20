using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public GameObject shellExplosion;

    public AudioClip shellExposionSource;

    public float lifeTime;

    void OnTriggerEnter(Collider collider)
    {
        if(collider!=null&&collider.tag!="Shell")
        {
            AudioSource.PlayClipAtPoint(shellExposionSource, transform.position);

            GameObject explosion = Instantiate(shellExplosion,
                                   gameObject.transform.position,
                                   Quaternion.identity) as GameObject;

            Destroy(explosion,lifeTime);

            Destroy(gameObject);
        }
    }
	
}
