namespace FiniteStateMachine
{
    internal class Awake : IState
    {
        static InputManager inputManager = new InputManager();
        public void Update()
        {
            Thread.Sleep(100);
            Console.WriteLine("Awake");
        }

        public IState Check()
        {
            if (inputManager.KeyPressed() && inputManager.ReadKey().Key == ConsoleKey.S)
            {
                return new Sleep();
            }
            return null;
        }

        public void StartState()
        {
            Console.WriteLine("Im awake");
        }
        public void EndState()
        {
            Console.WriteLine("Im not awake anymore");
        }
    }
}
