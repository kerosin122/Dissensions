namespace TaskSystemMain.Task
{
    [System.Serializable]
    public abstract class Task
    {
        protected int Id;

        public abstract void RemoveTask();
    }
}