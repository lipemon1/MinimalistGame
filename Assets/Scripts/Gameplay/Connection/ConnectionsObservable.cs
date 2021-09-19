using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimalGame.Gameplay.Connections
{
    public static class ConnectionsObservable
    {
        static IEnergyStart _energyPoint ;
        static List<IConnection> _connections = new List<IConnection>();

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
            foreach (IConnection connection in _connections)
            {
                connection.DisableEnergy();
                connection.CalculatePoints();
            }
            
            _energyPoint.CalculateEnergyPointsToConduct();

            _energyPoint.TryEmitEnergy();
        }
    }
}
