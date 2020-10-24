using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    private SpriteRenderer cellSpriteRenderer;

    private void Awake()
    {
        cellSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseEnter()
    {
        cellSpriteRenderer.color = Color.black;
    }

    private void OnMouseExit()
    {
        cellSpriteRenderer.color = Color.white;
    }
}
