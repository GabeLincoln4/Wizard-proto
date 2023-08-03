using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCreation : MonoBehaviour
{
    public Spell _spell;

    void Awake()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = _spell._isEthereal;
        gameObject.GetComponent<MeshRenderer>().material = _spell._spellVisual._color;
        gameObject.GetComponent<MeshFilter>().mesh = _spell._spellVisual._shape;
    }
}
