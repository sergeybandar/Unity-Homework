using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

  
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            _rigidbody.velocity = Vector3.forward * _speed;
            _animator.SetBool("isWalkForward", true);

        }
        if(Input.GetKeyUp(KeyCode.W)){
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("isWalkForward", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = Vector3.back * _speed / 1.5f;
            _animator.SetBool("isWalkBack", true);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("isWalkBack", false);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            _animator.SetTrigger("jump");
                    
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity = Vector3.left * _speed;
            _animator.SetBool("isWalkLeft", true);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("isWalkLeft", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity = Vector3.right * _speed;
            _animator.SetBool("isWalkRight", true);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.SetBool("isWalkRight", false);
        }
        if (Input.GetMouseButtonDown(0))
        {        
            _animator.SetTrigger("attack");
        }
        if (Input.GetMouseButton(1))
        {
            _animator.SetBool("isBlock", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            _animator.SetBool("isBlock", false);
        }


    }
}
