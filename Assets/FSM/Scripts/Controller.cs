using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se encargará de gestionar Estado actual, 
/// Las acciones a realizar del estado actual, y a evaluar 
/// las decisiones que provocarán transiciones entre estados
/// </summary>
public abstract class Controller : MonoBehaviour {
    public abstract void UpdateStateActions();
    public abstract void EvaluateStateTransitions();
}
