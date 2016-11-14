using UnityEngine;
using System.Collections;

public class EnemyControy : MonoBehaviour {

    public GameObject enemy;

    public Transform player1;
    public Transform player2;

    private Rigidbody enemyRg;

    //enmey的运动速度；
    public float speed;

	void Start ()
    {
        enemyRg = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        followPlayer();
	}

    void followPlayer()
    {
        //储存player和enemy的最短距离的向量；
        Vector3 distance;
        float a, b;

        //记录enemy和两个玩家的距离；
        a = Vector3.Magnitude(player1.position - transform.position);
        b = Vector3.Magnitude(player2.position - transform.position);

        if (a <= b)
        {
            distance = player1.position - transform.position;
        }
        else
        {
            distance = player2.position - transform.position;
        }


        enemyRg.velocity = Vector3.Normalize(distance) * speed;


    }
}
