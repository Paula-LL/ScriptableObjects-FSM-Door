using System.Collections;using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] Transform openDoorTransform; //Variable archiveing the position for when door is open. 
    Vector3 originalTransformPosition; //Variable archiveing the initial position of the door (closed).
    public enum DoorStates {OPEN, OPENING, CLOSED, CLOSING};
    public DoorStates currentState;
    float currentStateTime;
    [SerializeField] float idleDuration, movingDuration;

    public List <GameObject> doorPointsObject;
    public Vector3[] doorPoints;

    public int currentTargetPoint = 0; 

    void Start()
    {
        doorPoints = new Vector3[doorPointsObject.Count];
        for(int i = 0; i < doorPointsObject.Count; i++)
        {
            doorPoints[i] = doorPointsObject[i].transform.position;
            Destroy(doorPointsObject[i]);
        }
        doorPointsObject.Clear();
    }

    void Update()
    {
        transform.LookAt(openDoorTransform);
        currentStateTime += Time.deltaTime;
        UpdateState(); 
    }

    void ChangeState(DoorStates newState) {

        ExitState();
        EnterState(newState);

        switch (currentState)
        {
            case DoorStates.OPEN:
                break;
            case DoorStates.CLOSED:
                break;
            case DoorStates.CLOSING:
                break;
            case DoorStates.OPENING:
                break;
        }
    }

    void EnterState(DoorStates newState) {
        currentState = newState;
        currentStateTime = 0; 

        switch (currentState)
        {
            case DoorStates.OPEN:
                break;
            case DoorStates.CLOSED:
                break;
            case DoorStates.CLOSING:
                break;
            case DoorStates.OPENING:
                originalTransformPosition = openDoorTransform.position;
                currentTargetPoint = (currentTargetPoint + 1) % doorPoints.Length;
                break;
        }
    }

    void UpdateState() {
        switch (currentState)
        {
            case DoorStates.OPEN:
                if (currentStateTime >= idleDuration)
                {
                    ChangeState(DoorStates.OPENING);
                }
                break;
            case DoorStates.CLOSED:
                break;
            case DoorStates.CLOSING:
                break;
            case DoorStates.OPENING:
                if (currentStateTime <= movingDuration)
                {
                    Vector3 originalPos = originalTransformPosition;
                    Vector3 targetPos = doorPoints[currentTargetPoint];
                    float progress = currentStateTime / movingDuration;
                    openDoorTransform.position = Vector3.Lerp(originalPos, targetPos, progress);
                }
                else
                {
                    ChangeState(DoorStates.OPEN);
                }
             break;
        }
    }

    void ExitState() {
        switch (currentState) { 
            case DoorStates.OPEN:
                break; 
            case DoorStates.CLOSED:
                break; 
            case DoorStates.CLOSING:
                break;
            case DoorStates.OPENING:
                break; 
        }
    }
}
