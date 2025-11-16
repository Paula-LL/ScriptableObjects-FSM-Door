using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorClosedDecision", menuName = "FSM/Decisions/ClosedDoorDecision")]

public class ClosedDoorDecision : Decision
{
   public override bool Decide(Controller controller)
    {
        DoorController door = controller as DoorController;
        return door != null && !door.Open && !door.Opening && !door.Closing;
    }
}
