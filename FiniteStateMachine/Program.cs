namespace FiniteStateMachine
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            StateMachine stateMachine = new StateMachine();
            while(true)
            {
                stateMachine.Update();
            }
        }
    }
}