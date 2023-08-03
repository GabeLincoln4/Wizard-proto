using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueCaster : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    [SerializeField] private EnemySpellSpawner _enemySpellSpawner;
    [SerializeField] private bool _spellSpawnToggle;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _enemySpellSpawner = _enemySpellSpawner.GetComponent<EnemySpellSpawner>();
    }

    void Update()
    {
        // if (_enemySpellSpawner._readyToFire == true)
        // {
        //     Debug.Log("Caster is ready to fire"); 
        //     _meshRenderer.material.SetColor("_Color", Color.red);
        //     StartCoroutine(TurnRogueCasterBlue());
        // }
    }
}
