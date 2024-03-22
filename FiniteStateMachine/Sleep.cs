using System.ComponentModel.Design;
using static FiniteStateMachine.IState;

namespace FiniteStateMachine
{

    internal class Sleep : IState
    {
        static InputManager inputManager = new InputManager();
        public void Update()
        {
            Thread.Sleep(100);
            Console.WriteLine("Sleep");
        }
        public IState Check()
        {
            if (inputManager.KeyPressed() && inputManager.ReadKey().Key == ConsoleKey.A)
            {
                return new Awake();
            }
            return null;
        }
        public void StartState()
        {
            Console.WriteLine("Im tired");
        }
        public void EndState()
        {
            Console.WriteLine("Im not tired anymore");
        }

    }
}
