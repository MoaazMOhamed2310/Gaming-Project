using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IPointerClickHandler
{
    public int targetState = 0; // Correct state for this piece
    public int maxStates = 4;   // e.g., 4 rotations (0, 90, 180, 270)
    private int currentState = 0;

    public void OnPointerClick(PointerEventData eventData) {
        currentState = (currentState + 1) % maxStates;
        transform.rotation = Quaternion.Euler(0, 0, -90f * currentState);
        PuzzleChecker.Instance.CheckSolved();
    }

    public bool IsCorrect() {
        return currentState == targetState;
    }

    public void Randomize() {
        currentState = Random.Range(0, maxStates);
        transform.rotation = Quaternion.Euler(0, 0, -90f * currentState);
    }

}
