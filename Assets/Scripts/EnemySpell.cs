using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 30f;
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    public GameObject _target;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        // Debug.Log(_target);
        // _moveDirection = (_target.transform.position - transform.position.normalized + transform.up) * _moveSpeed * Time.deltaTime;
        // _rigidbody.velocity = new Vector3(_moveDirection.x + 1f, 0, _moveDirection.z);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy Spell hit " + other.gameObject.name + " !");
    }
}
