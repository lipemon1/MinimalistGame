using System.Collections.Generic;

namespace MinimalGame.Data
{
    public class UserData
    {
        public List<Level> PlayerLevels;

        public UserData()
        {
            PlayerLevels = new List<Level>();
        }
        
        public UserData(List<Level> levels)
        {
            PlayerLevels = levels;
        }
    }
}
