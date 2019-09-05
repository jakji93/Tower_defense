using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreatDefenderParent();
    }

    private void CreatDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    public void SetDefender(Defender defender)
    {
        this.defender = defender;
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefender();
    }

    private void SpawnDefender()
    {
        var newDefender = Instantiate(defender, SnapToGrid(GetSquareClicked()), Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;
    }

    private void AttemptToPlaceDefender()
    {
        var starText = FindObjectOfType<StarText>();
        int defenderCost = defender.GetStarCost();
        if (starText.SpendStar(defenderCost)) {
            SpawnDefender();
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
}
