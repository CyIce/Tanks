using UnityEngine;
using System.Collections;

public class Attact : MonoBehaviour {

    public KeyCode shot;

    public Transform firePosition;

    public GameObject bullet;

    private GameObject shell;
    private Rigidbody shellRg;

    public float shellSpeed;

    //让炮弹呈抛物线运动；
    public float shellAngular;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        attact();
	}

    /// <summary>
    /// 控制player发射炮弹；
    /// </summary>
    void attact()
    {
        if (Input.GetKeyDown(shot))
        {
            shell = Instantiate(bullet, firePosition.position, firePosition.rotation) as GameObject;

            shellRg = shell.GetComponent<Rigidbody>();

            shellRg.velocity = (transform.forward+new Vector3(0,shellAngular,0))* shellSpeed;
        }

        if(shell!=null)
        {
            shellRg.angularVelocity = transform.right;
        }

        
    }
}
