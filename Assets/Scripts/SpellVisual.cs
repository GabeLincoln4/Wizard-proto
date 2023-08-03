using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Visual", menuName = "Spells/Visual")]
public class SpellVisual : ScriptableObject
{
    public Material _color;
    public Mesh _shape;
}
