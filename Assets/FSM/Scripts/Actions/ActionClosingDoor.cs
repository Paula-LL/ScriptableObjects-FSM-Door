using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorClosingAction", menuName = "FSM/Actions/ClosingDoor")]

public class ActionClosingDoor : Action
{
    public override void Act(Controller controller)
    {
        DoorController door = controller as DoorController;
        if (door != null)
        {
            door.ClosingStart();
            door.DoorClosing();
        }
    }
}
