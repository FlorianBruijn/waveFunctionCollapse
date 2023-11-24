using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    [SerializeField] private float speed;
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
            downVel = -0.05f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                downVel = jump;
                StartCoroutine(Jump());
            }
        }


        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);

        Vector3 move = new Vector3(Time.deltaTime * speed * Input.GetAxis("Horizontal"), downVel, Time.deltaTime * speed * Input.GetAxis("Vertical"));

        characterController.Move(move);
    }
    private IEnumerator Jump()
    {
        jumping = true;
        yield return new WaitForSeconds(0.5f);
        jumping = false;
    }
}
