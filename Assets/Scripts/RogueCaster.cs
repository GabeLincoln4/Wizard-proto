using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueCaster : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    [SerializeField] LeverManager _leverManager;

    private bool _isPoisoned = false;
    private float _elapsed;
    private float _timerSpeed = 3f;
    private List<float> _pingsList;
    private float _pingLimit = 3f;

    private void Awake()
    {
        
    }

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // if (_enemySpellSpawner._readyToFire == true)
        // {
        //     Debug.Log("Caster is ready to fire"); 
        //     _meshRenderer.material.SetColor("_Color", Color.red);
        //     StartCoroutine(TurnRogueCasterBlue());
        // }

        if(_isPoisoned)
        {
            StartTimer(_timerSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _pingsList = new List<float>();
        _isPoisoned = true;
    }

    private void StartTimer(float timerSpeed)
    {
        _elapsed += Time.deltaTime;
        if(_elapsed >= timerSpeed)
        {
            _elapsed = 0f;
            _pingsList.Add(0f);
            Debug.Log("Caster takes two damage");
            if (_pingsList.Count >= _pingLimit)
            {
                _isPoisoned = false;
                _pingsList.Clear();
            }
        }
    }
}
