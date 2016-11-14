using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    //坦克爆炸的效果；
    public GameObject tankExplosion;

    private Rigidbody player;

    //player的移动速度；
    public float moveSpeed;

    //旋转的角速度；
    public  float angularSpeed;

    private float explosionLifeTime=1;

    public int playerTag;

    //表示player的生命值；
    private int hp;

    //用于储存前进和转向；
    private float h;
    private float v;

	void Start ()
    {
        //初始化玩家的生命值；
        hp = 100;

        player = gameObject.GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        move();

        turning();
	}

    /// <summary>
    /// 控制player前进与后退；
    /// </summary>
    void move()
    {
        v = Input.GetAxis("VerticalPlayer" + playerTag);

        player.velocity = transform.forward * v * moveSpeed;

    }


    /// <summary>
    /// 控制player转向；
    /// </summary>
    void turning()
    {
        h = Input.GetAxis("HorizontalPlayer" + playerTag);

        player.angularVelocity = transform.up * h * angularSpeed;
    }

    void OnTriggerEnter(Collider collider)
    {

        //收到伤害，hp下降；
        if(collider.tag=="Shell")
        {
            hp -= Random.Range(10, 20);
        }

        if(hp<=0)
        {
            GameObject explosion = Instantiate(tankExplosion,
                                   transform.position + new Vector3(0, 2, 0), 
                                   transform.rotation) as GameObject;

            Destroy(explosion,explosionLifeTime);

            Destroy(gameObject);
        }
    }
}
