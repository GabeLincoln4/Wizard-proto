using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueCaster : MonoBehaviour
{
    [SerializeField] private GameObject _enemySpell;
    [SerializeField] private float _fireRate;
    private float _nextFire;

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
        if (Time.time > _nextFire)
        {
            Instantiate(_enemySpell, transform.position, Quaternion.identity);
            _nextFire = Time.time + _fireRate;
        }
    }

}
