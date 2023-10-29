using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    [SerializeField] private GemType _gemType;
    [SerializeField] private Image _displayIcon;
    [SerializeField] private Sprite[] _icons;

    public Vector2 Size = new Vector2(100, 100);

    public void Setup(GemType type)
    {
        _gemType = type;
        _displayIcon.sprite = _icons[(int)type];
    }
}
