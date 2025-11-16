using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Decision.asset", menuName = "FSM/Decision")]
public abstract class Decision : ScriptableObject {
    public abstract bool Decide(Controller controller);
}
