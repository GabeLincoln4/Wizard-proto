using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellSpawner : MonoBehaviour
{
    private Material _material;
    private RogueCaster _rogueCaster;
    private bool _casterLeverIsActive;
    private float _nextFire;
    private MeshRenderer _meshRenderer;
    private LeverManager _leverManager;
    [SerializeField] private SpellSpawner _spellSpawner;

    private void CreateSpell(GameObject spell, float distanceFromCaster, float rateOfCreation)
    {
        
    }
}
