using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 50.0f;

    public float JumpForce = 10.0f;
    public float RotateSpeed = 10.0f;
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * RotateSpeed * Time.deltaTime, Space.World);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * MoveSpeed * Time.deltaTime, Space.Self);

        Animator.SetFloat("Speed", verticalInput);

        Debug.DrawRay(transform.position, Vector3.down, Color.red, 0.51f);
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
