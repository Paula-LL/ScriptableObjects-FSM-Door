using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorCloseAction", menuName = "FSM/Actions/CloseDoor")]

public class ActionCloseDoor : Action
{
    public override void Act(Controller controller)
    {
        DoorController door = controller as DoorController;
        if (door != null)
        {
            door.ClosingOver();
            if (door.doorObject != null)
            {
                door.DoorClosing();
            }
        }
    }
}
