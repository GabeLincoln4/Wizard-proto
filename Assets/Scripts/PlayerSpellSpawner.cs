using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellSpawner : MonoBehaviour
{
    public GameObject _projectile;

    [SerializeField] private float _fireDelta = 0.5f;
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _LHFirePoint, _RHFirePoint;
    [SerializeField] private float _projectileSpeed = 30;
    [SerializeField] private bool _otherSpellIsBeingCast = false;

    private float _nextFire = 0.5f;
    private GameObject _newAttackSpell;
    private float _myTime = 0.0f;
    private Vector3 _destination;
    private bool _leftHand = false;
    

    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !_otherSpellIsBeingCast)
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        Ray ray = _cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
            _destination = hit.point;
        else 
            _destination = ray.GetPoint(1000);

        if(_leftHand)
        {
            _leftHand = false;
            InstantiateProjectile(_LHFirePoint);
        }
        else
        {
            _leftHand = true;
            InstantiateProjectile(_RHFirePoint);
        }
        
    }

    private void InstantiateProjectile(Transform firePoint)
    {
        var capturedSpell = GetComponentInParent<GrabSpellSpawner>()._grabSpell.GetComponent<GrabSpellMovement>()._capturedSpell;
        if(capturedSpell != null)
        {
            _projectile = capturedSpell;
        }

        var projectileObj = Instantiate(_projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (_destination - firePoint.position).normalized * _projectileSpeed;
    }

    private void DetectOtherSpell()
    {
        _otherSpellIsBeingCast = GetComponentInParent<GrabSpellSpawner>()._isCasting;
    }
}
