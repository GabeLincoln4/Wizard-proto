using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSpellMovement : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _endPos;
    private float _fractionOfTheWay;
    [SerializeField] float _destructionDelay;

    void Start()
    {
        _startPos = transform.position;
        _endPos =  transform.position + (transform.right * -2);
    }

    void Update()
    {
        StartCoroutine(SpellMovementDelay());
    }

    IEnumerator SpellMovementDelay()
    {
        Debug.Log("Spell forming...");
        yield return new WaitForSeconds(1);
        Debug.Log("Spell formed.");
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
