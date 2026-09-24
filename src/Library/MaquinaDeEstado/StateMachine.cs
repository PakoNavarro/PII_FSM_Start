using System.Collections.Generic;
public class StateMachine
{
    private List<State> states;
    public State CurrentState { get; private set; } 

    public StateMachine()
    {
        this.states = new List<State>();
    }

    public void AddState(State state)
    {
        if (states == null)
        {
            throw new ArgumentNullException(nameof(state));
        }

        if (!this.states.Contains(state))
        {
            this.states.Add(state);
        }

        if (this.CurrentState == null)
        {
            this.CurrentState = state;
        }
    }

    public bool ProcessInput(Input input)
    {
        if (this.CurrentState == null)
        {
            return false;
        }

        State nextState = this.CurrentState.GetNextState(input);

        if (nextState == null)
        {
            return false;
        }

        this.CurrentState = nextState;
        return true;
    }

    public bool ProcessInputs(Input[] inputs)
    {
        if (inputs == null)
    {
        throw new ArgumentNullException(nameof(inputs));
    }

    foreach (Input input in inputs)
    {
        if (!this.ProcessInput(input))
        {
            return false;
        }
    }

    return true;
    }
}
