using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Minion")]
public class Spell : ScriptableObject
{
    public bool _isEthereal;
    public SpellVisual _spellVisual;
}
