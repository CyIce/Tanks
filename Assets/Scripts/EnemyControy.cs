﻿using UnityEngine;
using System.Collections;

public class EnemyControy : MonoBehaviour {

    public GameObject enemy;

    public GameObject bullet;

    public Transform firePosition;

    public Transform player1;
    public Transform player2;

    private Rigidbody shellRg;

    private Rigidbody enemyRg;

    private float fireTime=0;

    //控制enemy旋转的速读；
    private float rotationSpeed = 5;


    //让炮弹呈抛物线运动；
    public float shellAngular;

    //enemy的攻击范围；
    public float attactArea;

    public float shellSpeed;

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
        Vector3 vecDistance;

        float distance;

        float a, b;

        //记录enemy和两个玩家的距离；

        if (player1 != null && player2 != null) 
        {
            a = Vector3.Magnitude(player1.position - transform.position)-shellSpeed;
            b = Vector3.Magnitude(player2.position - transform.position)-shellSpeed;
         }
        else
        {
            
            return ;
        }





        if (Mathf.Abs(a) < Mathf.Abs(b)) 
        {
            vecDistance = player1.position - transform.position;
            distance = a;
        }
        else
        {
            vecDistance = player2.position - transform.position;
            distance = b;
        }

        if (distance > attactArea) 
        {
            distance /= Mathf.Abs(distance);

            enemyRg.velocity = Vector3.Normalize(vecDistance) * speed * distance;

            //enemyRg.velocity = Vector3.Normalize(vecDistance) * speed * distance;
            enemyRg.velocity = transform.forward * speed * distance;
        }
        else
        {
            enemyRg.velocity = new Vector3(0, 0, 0);

            //攻击玩家；
            attact();
        }


        //使enemy指向player；
        Quaternion rotation = Quaternion.LookRotation(vecDistance);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

    }


    //发射炮弹；
    void attact()
    {
        fireTime += Time.deltaTime;

        if (fireTime > 0.5f)
        {
            fireTime = 0;

            GameObject shell = Instantiate(bullet, firePosition.position, firePosition.rotation) as GameObject;

            shellRg = shell.GetComponent<Rigidbody>();

            shellRg.velocity = (transform.forward + new Vector3(0, shellAngular, 0)) * shellSpeed;

            shellRg.angularVelocity = transform.right;
        }


    }
}
