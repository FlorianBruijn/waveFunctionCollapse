using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runMult;
    [SerializeField] private float gravity = 9.807f;
    [SerializeField] private float jump;
    private bool onGround = false;
    private bool jumping = false;
    private float downVel;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f, LayerMask.GetMask("ground"))) onGround = true;
        else onGround = false;

        if (onGround) downVel -= Time.deltaTime * gravity;
        else if (!jumping) 
        { 
            downVel = -5f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                downVel = jump;
                StartCoroutine(Jump());
            }
        }


        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector2 normal = new Vector2 (x , z);
        normal.Normalize();

        Vector3 move = Vector3.zero;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            move = ((transform.right * normal.x * speed + transform.forward * normal.y * speed) * runMult + transform.up * downVel) * Time.deltaTime;
        }
        else
        {
            move = (transform.right * normal.x * speed + transform.forward * normal.y * speed + transform.up * downVel) * Time.deltaTime;
        }

        characterController.Move(move);
    }
    private IEnumerator Jump()
    {
        jumping = true;
        yield return new WaitForSeconds(0.5f);
        jumping = false;
    }
}
