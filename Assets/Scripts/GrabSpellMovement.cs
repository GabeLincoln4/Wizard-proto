using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSpellMovement : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _endPos;
    private float _fractionOfTheWay;
    [SerializeField] float _destructionDelay;
    [SerializeField] float _spellDistance;
    private BoxCollider _boxCollider;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    void Start()
    {
        _startPos = transform.position;
        _endPos =  transform.position + (transform.right * _spellDistance);
    }

    void Update()
    {
        StartCoroutine(SpellMovementDelay());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Grab spell has touched enemy spell");
        Destroy(other.gameObject);
    }

    IEnumerator SpellMovementDelay()
    {
        _boxCollider.enabled = false;
        yield return new WaitForSeconds(1);
        _boxCollider.enabled = true;
        _fractionOfTheWay += 0.01f;
        transform.position = Vector3.Lerp(_startPos, _endPos, _fractionOfTheWay);
        Destroy(gameObject, _destructionDelay);
        
    }

    IEnumerator DestroySpell()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}