using System.Collections.Generic;

namespace MinimalGame.Data
{
    public class UserData
    {
        public List<Level> PlayerLevels = new List<Level>();

        public UserData(List<Level> levels)
        {
            PlayerLevels = levels;
        }
    }
}
