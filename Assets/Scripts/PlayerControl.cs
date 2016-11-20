using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


    private Rigidbody player;

    //坦克停止的声音；
    public AudioClip tankIdleAudio;
    //坦克移动时的声音；
    public AudioClip tankDrivingAudio;

    
    private AudioSource audio;

    //player的移动速度；
    public float moveSpeed;

    //旋转的角速度；
    public  float angularSpeed;


    public int playerTag;

    //用于储存前进和转向；
    private float h;
    private float v;

	void Start ()
    {
        audio = GetComponent<AudioSource>();

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

        if (Mathf.Abs(v) >= 0.1) 
        {
            audio.clip = tankDrivingAudio;
            audio.Play();
        }
        else
        {
            audio.clip = tankIdleAudio;
            audio.Play();
        }

    }


    /// <summary>
    /// 控制player转向；
    /// </summary>
    void turning()
    {
        h = Input.GetAxis("HorizontalPlayer" + playerTag);

        player.angularVelocity = transform.up * h * angularSpeed;
    }

   

    
}
