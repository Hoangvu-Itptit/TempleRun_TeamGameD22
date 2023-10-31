using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtl : MonoBehaviour
{
    public Rigidbody rb;
    public CapsuleCollider collider;
    public float speed;
    public float jumpPower;
    public Animator animator;
    public Transform skinParent;

    private bool _isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = skinParent.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        rb.AddForce(Vector3.down / 5f, ForceMode.Impulse);
    }

    void Move()
    {
        transform.position += Vector3.right * (speed * Time.deltaTime);
        animator.Play("Run");
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    void Jump()
    {
        if (_isJump) return;
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        _isJump = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            _isJump = false;
            GameCtl.Instance.InstanceNewRoad();
        }
    }
}