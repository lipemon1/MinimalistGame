namespace MinimalGame.Data
{
    [System.Serializable]
    public class Level
    {
        public int Id;
        public bool IsDone;

        public Level(int id, bool isDone)
        {
            this.Id = id;
            this.IsDone = isDone;
        }
    }   
}