using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorOpenAction", menuName = "FSM/Actions/OpenDoor")]

public class ActionOpenDoor : Action
{
    public override void Act(Controller controller)
    {
        DoorController door = controller as DoorController;
        if (door != null)
        {
            door.OpeningOver();
            if (door.doorObject != null)
            {
                door.DoorOpening();
            }
        }
    }
}
