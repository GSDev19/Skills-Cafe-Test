using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newGameData", menuName = "Data/Game Data/ New Game Data")]
public class GameData : ScriptableObject
{
    public int correctActionScore = 10;
    public List<ActionType> actionsCardOrder = new List<ActionType>();
}
