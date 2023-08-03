using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellSpawner : MonoBehaviour
{
    public GameObject _projectile;

    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _LHFirePoint, _RHFirePoint;
    [SerializeField] private float _projectileSpeed = 30;
    [SerializeField] private bool _otherSpellIsBeingCast = false;

    private GameObject _newAttackSpell;
    private Vector3 _destination;
    private bool _leftHand = false;
    

    void Awake()
    {
        // _projectile = _spell._gameObject;
        // _projectileSpeed = _spell._spellVelocity;   
    }

    void Update()
    {
        // if (_projectile == null)
        // {
        //     FillSpellSlot();
        //}

        if (Input.GetButtonDown("Fire1") && !_otherSpellIsBeingCast)
        {
            ShootProjectile();
        }
        else
        {
            DetectOtherSpell();
        }
    }

    

    private void ShootProjectile()
    {
        Ray ray = _cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (_projectile == null)
        {
            
        }

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

    private void FillSpellSlot()
    {
        // _projectile = _spell._gameObject;
        // _projectileSpeed = _spell._spellVelocity;
    }
}
