using UnityEngine;
using UnityEngine.UI;

public class DoorController : Controller
{
    //movement valiables
    public GameObject doorObject;
    public Vector3 openingOrientation = Vector3.up;
    public float openGap = 1f;
    public float speedOpening = 1f;

    public State initialState;

    public bool Open { get; set; }
    public bool Closing { get; set; }
    public bool Opening { get; set; }

    public Button pressButton;

    private bool pressButtonCurrent = false;
    private Vector3 openPos;
    private Vector3 closePos;
    private State currentState; 


    private void Start()
    {
        if (doorObject == null) { 
            doorObject = this.gameObject;
        }

        closePos = doorObject.transform.position;
        openPos = closePos + openingOrientation.normalized * openGap;

        if (pressButton != null) {
            pressButton.onClick.AddListener(OnButtonClick);
        }

        if (initialState != null) {
            ChangeState(initialState);
        }
    }

    public void OnButtonClick() { 
        pressButtonCurrent = true;
    }

    private void ChangeState(State newState) {
        if (newState == null) {
            return;
        }

        if (currentState != null && currentState.exitActions != null) {
            foreach (Action action in currentState.exitActions) {
                if (action != null) {
                    action.Act(this);
                }
            }
        }

        State prevousState = currentState;
        currentState = newState;

        if (currentState.enterActions != null) {
            foreach (Action action in currentState.enterActions) {
                if (action!= null) {
                    action.Act(this);
                }
            }
        }
    }

    private void Update()
    {
        UpdateStateActions();
        EvaluateStateTransitions();
        pressButtonCurrent = false;
    }

    public override void UpdateStateActions() {
        if (currentState == null || currentState.actions == null) { 
            return ;
        }

        foreach (Action action in currentState.actions) {
            if (action != null) {
                action.Act(this);
            }
        }
    }

    public override void EvaluateStateTransitions()
    {
        if (currentState == null || currentState.transitions == null) {
            return;
        }

        State newState = null;

        for (int i = 0; i < currentState.transitions.Length && newState == null; i++) { 
            Transition transition = currentState.transitions[i];

            if (transition != null && transition.decision != null) {
                if (transition.decision.Decide(this)) {
                    newState = transition.trueState;
                } else
                {
                    newState = transition.falseState;
                }
            }
        }

        if (newState != null &&newState != currentState)
        {
            ChangeState(newState);
        }
    }

    public bool ButtonPressedCheck() {
        return pressButtonCurrent;
    }

    public void OpeningOver() {
        Open = true; 
        Opening = false;
        if (doorObject != null) { 
            doorObject.transform.position = openPos;
        }
    }

    public void ClosingOver()
    {
        Open = false;
        Closing = false;

        if (doorObject != null) { 
            doorObject.transform.position = closePos;
        }
    }

    public void OpeningStart() {
        Opening = true;
        Closing = false;
        Open = false; 
    }

    public void ClosingStart() { 
        Closing = true;
        Opening = false;
        Open = false; 
    }

    public void DoorOpening()
    {
        if (doorObject != null && Opening) {
            doorObject.transform.position = Vector3.MoveTowards(doorObject.transform.position, 
                closePos, 
                speedOpening * Time.deltaTime);

            if (Vector3.Distance(doorObject.transform.position, closePos) < 0.01f) {
                ClosingOver();
            }
        }
    }

    public void DoorClosing() {
        if (doorObject != null && Closing) {
            doorObject.transform.position = Vector3.MoveTowards(doorObject.transform.position, 
                closePos,
                speedOpening * Time.deltaTime);

            if (Vector3.Distance(doorObject.transform.position, closePos) < 0.01f) {
                ClosingOver();
            }
        }
    }
}
