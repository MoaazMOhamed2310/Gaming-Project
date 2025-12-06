using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
   public GameObject puzzleCanvas;        // Assign your Puzzle Canvas
    public MonoBehaviour nakhnokh; // Drag your player movement script here
    private MoneySafe currentSafe;

    public void ShowPuzzle(MoneySafe safe) {
        currentSafe = safe;
        puzzleCanvas.SetActive(true);
        if (nakhnokh) nakhnokh.enabled = false;
    }

    public void PuzzleSolved() {
        puzzleCanvas.SetActive(false);
        if (nakhnokh) nakhnokh.enabled = true;
        if (currentSafe) currentSafe.OpenSafe();
    }

    public void CloseWithoutReward() {
        puzzleCanvas.SetActive(false);
        if (nakhnokh) nakhnokh.enabled = true;
        currentSafe = null;
    }
}


