using System.Collections.Generic;
using System.Linq;
using MinimalGame.Gameplay.Connections;
using MinimalGame.View;

namespace MinimalGame.GameFlow
{
    public static class LevelEnderController
    {
        static List<IEnergyPoint> _energyPointsToFollow = new List<IEnergyPoint>();

        public static void PrepareForLevel()
        {
            _energyPointsToFollow = new List<IEnergyPoint>();
            
            ConnectionsObservable.OnConnectionChanged += OnConnectionChanged;
        }

        static void OnConnectionChanged(int amountWithEnergy)
        {
            if(_energyPointsToFollow.Count(ep => ep.HasEnergy()) == _energyPointsToFollow.Count)
                OnEndLevel();
        }

        static void OnEndLevel()
        {
            ConnectionsObservable.GameOver();
            ViewController.OpenView(ViewKeys.Endgame);
        }

        public static void RegisterEnergyPoint(IEnergyPoint newEnergyPoint)
        {
            _energyPointsToFollow.Add(newEnergyPoint);
        }
    }
}