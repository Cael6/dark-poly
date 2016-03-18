using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {
    enum TurnPhase { start, income, upkeep, purchase, main, end };
    enum MovementPhase { start, move, stop };
    enum AttackPhase { start, calculateHit, calculateDamage, retaliationHit, retaliationDamage, end };

	void Start () {
	
	}
	
	void Update () {
	
	}
}
