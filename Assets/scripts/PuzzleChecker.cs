using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleChecker : MonoBehaviour
{
  public static PuzzleChecker Instance { get; private set; }

    public PuzzleManager manager;
    public PuzzlePiece[] pieces;

    void Awake() {
        Instance = this;
    }

    void OnEnable() {
        // Optional: randomize pieces when puzzle opens
        foreach (var p in pieces) p.Randomize();
    }

    public void CheckSolved() {
        foreach (var piece in pieces) {
            if (!piece.IsCorrect()) return;
        }
        manager.PuzzleSolved();
    }

}
