using UnityEngine;
using System.Collections;

public class TanksHp : MonoBehaviour {


    //坦克爆炸的效果；
    public GameObject tankExplosion;

    //表示player的生命值；
    public int hp;

    private float explosionLifeTime = 1;

    public AudioClip tankExplosionSource;

    void OnTriggerEnter(Collider collider)
    {


        //收到伤害，hp下降；
        if (collider.tag == "Shell")
        {
            hp -= Random.Range(10, 20);
        }

        if (hp <= 0)
        {
            GameObject explosion = Instantiate(tankExplosion,
                                   transform.position + new Vector3(0, 2, 0),
                                   transform.rotation) as GameObject;
            AudioSource.PlayClipAtPoint(tankExplosionSource, transform.position);

            Destroy(explosion, explosionLifeTime);

            Destroy(gameObject);
        }
    }
}
