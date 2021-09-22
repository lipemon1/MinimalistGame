using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MinimalGame.Audio;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public static class ConnectionsObservable
    {
        static IEnergyStart _energyPoint ;
        static List<IConnection> _connections = new List<IConnection>();
        public static bool CanRotateConnections;
        
        public delegate void OnConnectionChangeDelegate(int amountWithEnergy);
        public static OnConnectionChangeDelegate OnConnectionChanged;

        public static void RegisterConnections(IConnection newConnection)
        {
            _connections.Add(newConnection);
        }

        public static void RegisterEnergyPoints(IEnergyStart newEnergyPoint)
        {
            _energyPoint = newEnergyPoint;
        }

        public static void ConnectionRotated(IConnection connection)
        {
            OnAnyConnectionRotated(connection);
        }

        static void OnAnyConnectionRotated(IConnection connectionChanged)
        {
            SfxEmitter.Instance.PlaySfx(SfxKey.ChangeConductor);
            
            foreach (IConnection connection in _connections)
            {
                connection.DisableEnergy();
                connection.CalculatePoints();
            }
            
            _energyPoint.CalculateEnergyPointsToConduct();

            _energyPoint.TryEmitEnergy();
            
            OnConnectionChanged?.Invoke(AmountOfEnergyConnections());
        }

        public static void GameOver()
        {
            CanRotateConnections = false;
        }

        public static void ResetForNewLevel()
        {
            CanRotateConnections = true;
            _energyPoint = null;
            _connections = new List<IConnection>();
        }

        static int AmountOfEnergyConnections()
        {
            return _connections.Count(c => c.HasEnergy());
        }
    }
}
