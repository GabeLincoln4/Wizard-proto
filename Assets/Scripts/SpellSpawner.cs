using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell Spawner")]
public class SpellSpawner : ScriptableObject
{
    public GameObject _enemySpell;
    public float _fireRate;
    public float _telegraphDuration;
    public GameObject _currentTarget;
    public float _projectileSpeed;
    public bool _isTelegraphing;
}
