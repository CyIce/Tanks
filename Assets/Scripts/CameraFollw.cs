using UnityEngine;
using System.Collections;

public class CameraFollw : MonoBehaviour {

    //两个玩家的中心；
    private Vector3 playerCenter;

    //相机和玩家中心的距离；
    private Vector3 distance;

    //获得相机组件；
    private Camera camera;

    //控制相机视野的缩放；
    private float cameraScale;

    //两个玩家的位置；
    public Transform player1;
    public Transform player2;



	void Start ()
    {
        camera = GetComponent<Camera>();

        playerCenter = (player1.position + player2.position) / 2;

        distance = transform.position - playerCenter;

        cameraScale = Vector3.Magnitude(player1.position - player2.position) / camera.orthographicSize;
    }
	
	void Update ()
    {
        playerCenter = (player1.position + player2.position) / 2;

        camera.orthographicSize = Vector3.Magnitude(player1.position - player2.position) / cameraScale;

        transform.position = distance + playerCenter;
	}
}
