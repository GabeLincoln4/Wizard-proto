using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSpellMovement : MonoBehaviour
{
    public GameObject _capturedSpell = null;
    public bool _spellCaught = false;

    private Vector3 _startPos;
    private Vector3 _endPos;
    private float _fractionOfTheWay;
    [SerializeField] float _destructionDelay;
    [SerializeField] float _spellDistance;
    [SerializeField] float _spellIdleDuration;
    [SerializeField] private bool _collisionReactionDebugger = false;
    private BoxCollider _boxCollider;
    private GameObject _projectileSlot;

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
        CollisionReaction(other);
    }

    IEnumerator SpellMovementDelay()
    {
        _boxCollider.enabled = false;
        yield return new WaitForSeconds(_spellIdleDuration);
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

    private void CollisionReaction(Collider other)
    {
        if(_collisionReactionDebugger)
        {
            Debug.Log(other.gameObject);
        }
        
    }
}
