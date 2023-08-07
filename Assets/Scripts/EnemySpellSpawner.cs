using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemySpell;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _telegraphDuration;
    private Material _material;
    private RogueCaster _rogueCaster;
    private bool _casterLeverIsActive;
    [SerializeField] private GameObject _currentTarget;
    [SerializeField] private float _projectileSpeed;
    private float _nextFire;
    private MeshRenderer _meshRenderer;
    [SerializeField] private bool _isTelegraphing = false;

    void Awake()
    {
        _material = GetComponentInParent<MeshRenderer>().material;
        _enemySpell.GetComponent<EnemySpell>()._target = _currentTarget;
        //_casterLeverIsActive = _rogueCaster.GetComponent<RogueCaster>()._leverIsActive;
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
        SetColor("_Color", Color.red);
        _isTelegraphing = true;
        yield return new WaitForSeconds(_telegraphDuration);
        SetColor("_Color", Color.blue);
        _isTelegraphing = false;
        var projectileObj = Instantiate(_enemySpell, transform.position, Quaternion.identity);
        projectileObj.GetComponent<Rigidbody>().velocity = (_currentTarget.transform.position - transform.position).normalized * _projectileSpeed;
        _nextFire = Time.time + _fireRate;
    }

    private void SetColor(string materialType, Color color)
    {
        _material.SetColor(materialType, color);
    }
}
