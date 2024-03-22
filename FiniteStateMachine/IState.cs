namespace FiniteStateMachine
{
    internal interface IState
    {
        public void Update();
        public IState Check();
        public void StartState();

        public void EndState();
        
    }
    public class InputManager
    {
        static Queue<ConsoleKeyInfo> inputBuffer = new Queue<ConsoleKeyInfo>();
        static object inputLock = new object();
        static int maxBufferSize = 2;

        public InputManager()
        {
            Thread inputThread = new Thread(ReadInput);
            inputThread.Start();
        }

        private void ReadInput()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    lock (inputLock)
                    {
                        inputBuffer.Enqueue(key);
                        while (inputBuffer.Count > maxBufferSize)
                        {
                            inputBuffer.Dequeue();
                        }
                    }
                }
            }
        }

        public bool KeyPressed()
        {
            lock (inputLock)
            {
                return inputBuffer.Count > 0;
            }
        }

        public ConsoleKeyInfo ReadKey()
        {
            lock (inputLock)
            {
                if (inputBuffer.Count > 0)
                {
                    return inputBuffer.Dequeue(); // Rückgabe von key
                }
                else
                {
                    return new ConsoleKeyInfo(); // Rückgabe leer wenn kein key 
                }
            }
        }
    }
}
