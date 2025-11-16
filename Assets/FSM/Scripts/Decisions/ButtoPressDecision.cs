using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PressedKeyDecision", menuName = "FSM/Decisions/ButtonPressDecision")]

public class ButtoPressDecision : Decision
{
    public override bool Decide(Controller controller)
    {
        DoorController door = controller as DoorController;
        return door != null && door.ButtonPressedCheck();
    }
}
