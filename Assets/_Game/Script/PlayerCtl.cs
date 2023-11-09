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
        animator.Play("Run");
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Roll();
        }

        rb.AddForce(Vector3.down / 5f, ForceMode.Impulse);
    }

    void Move()
    {
        transform.position += Vector3.right * (speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    void Jump()
    {
        if (_isJump) return;
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        _isJump = true;
    }

    void Roll()
    {
        if (_isJump)
        {
        }
        else
        {
            var rollColliderCenter = new Vector3(0, 0.751587f, 0);
            var rollColliderHeight = 1.547814f;
            animator.Play("Roll");
            (collider.center, rollColliderCenter) = (rollColliderCenter, collider.center);
            (collider.height, rollColliderHeight) = (rollColliderHeight, collider.height);
            StartCoroutine(WaitUntilEndAnim((1 + 5 / 60f) / 1.5f, rollColliderCenter, rollColliderHeight));
        }
    }

    IEnumerator WaitUntilEndAnim(float timeWait, Vector3 rollColliderCenter, float rollColliderHeight)
    {
        yield return new WaitForSeconds(timeWait);
        (collider.center, rollColliderCenter) = (rollColliderCenter, collider.center);
        (collider.height, rollColliderHeight) = (rollColliderHeight, collider.height);
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