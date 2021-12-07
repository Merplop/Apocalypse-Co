using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Follow : MonoBehaviour
{
    public Rigidbody2D Player_Body;
    public Vector3 Start_Position;
    public Rigidbody2D Camera;

    public float Blend = 0.3f;
    public float Blend_Speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDir = (((Player_Body.transform.position + Start_Position) * Blend) - Camera.transform.position).normalized;

        Camera.MovePosition(Camera.transform.position + MoveDir*Blend_Speed);
    }
}
