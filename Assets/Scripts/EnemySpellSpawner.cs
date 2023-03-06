using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemySpell;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _telegraphDuration;
    private Material _material;
    [SerializeField] private GameObject _currentTarget;
    private float _nextFire;
    private MeshRenderer _meshRenderer;
    [SerializeField] private bool _isTelegraphing = false;

    void Awake()
    {
        _material = GetComponentInParent<MeshRenderer>().material;
        _enemySpell.GetComponent<EnemySpell>()._target = _currentTarget;
    }

    void Start()
    {
        _nextFire = Time.time;
        transform.localPosition = new Vector3(0, .5f, 0);
    }

    void Update()
    {
        CheckIfTimeToFire(); 
    }

    private void CheckIfTimeToFire()
    {
        if ((Time.time > _nextFire) && !_isTelegraphing)
        {
            StartCoroutine(TurnRogueCasterBlue());
        }
    }

    IEnumerator TurnRogueCasterBlue()
    {
        _material.SetColor("_Color", Color.red);
        _isTelegraphing = true;
        yield return new WaitForSeconds(_telegraphDuration);
        _material.SetColor("_Color", Color.blue);
        _isTelegraphing = false;
        Instantiate(_enemySpell, transform.position, Quaternion.identity);
        _nextFire = Time.time + _fireRate;
    }
}
