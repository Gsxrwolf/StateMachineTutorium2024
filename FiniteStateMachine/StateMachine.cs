namespace FiniteStateMachine
{
    internal class StateMachine
    {
        private IState curState = null;

        public StateMachine()
        {
            Start();
        }
        private void Start()
        {
            curState = new Awake();
        }
        public void Update()
        {
            IState nextState = curState.Check();
            if (nextState != null)
            {
                curState.EndState();
                curState = nextState;
                curState.StartState();
            }
            curState.Update();
        }
    }
}
