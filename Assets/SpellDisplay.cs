using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDisplay : MonoBehaviour
{
    public Spell _spell;
    public Collider _collisionDetection;
    public Rigidbody _rigidbody;
    public MeshRenderer _meshRenderer;
    public MeshFilter _meshFilter;

    void Awake()
    {

        _collisionDetection.isTrigger = _spell._isEthereal;

    }
}
