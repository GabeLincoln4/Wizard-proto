using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 15f;
    private Rigidbody _rigidbody;
    private MouseLook _target;
    private Vector3 _moveDirection;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _target = GameObject.FindObjectOfType<MouseLook>();
        Debug.Log(_target);
        _moveDirection = (_target.transform.position - transform.position.normalized + transform.up) * _moveSpeed * Time.deltaTime;
        _rigidbody.velocity = new Vector3(_moveDirection.x + .5f, 0, _moveDirection.z);
    }
}
