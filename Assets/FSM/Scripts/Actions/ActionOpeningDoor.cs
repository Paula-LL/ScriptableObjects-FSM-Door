using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorOpeningAction", menuName = "FSM/Actions/OpeningDoor")]

public class ActionOpeningDoor : Action
{
    public override void Act(Controller controller)
    {
        DoorController door = controller as DoorController;
        if (door != null)
        {
            door.OpeningStart();
            door.DoorOpening();
        }
    }
}
