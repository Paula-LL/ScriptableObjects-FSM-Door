using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorOpenDecision", menuName = "FSM/Decisions/OpenDoorDecision")]

public class OpenedDoorDecision : Decision
{
    public override bool Decide(Controller controller)
    {
        DoorController door = controller as DoorController;
        return door != null && door.Open;
    }
}
