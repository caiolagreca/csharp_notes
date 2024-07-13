using System;
using System.Collections.Generic;
using System.Numerics;

namespace Queue
{
    class Program
    {

        private const int DEFAULT_HEALTH_AMOUNT = 100;

        private enum UnitType
        {
            Melee,
            Ranged,
            Wizard,
        }
        private static void Main(string[] args)
        {
            SpawUnit(new Vector3(0, 0, 3), UnitType.Melee, Quaternion.Identity, 56);
            SpawUnit(new Vector3(10, 5, 0), UnitType.Ranged, Quaternion.Identity);
            SpawUnit(healthAmount: 56, unitType: UnitType.Wizard);

            Console.ReadKey();
        }

        private static void SpawUnit(
            Vector3 spawnPosition = default,
            UnitType unitType = UnitType.Melee,
            Quaternion spawnRotation = default,
            int healthAmount = DEFAULT_HEALTH_AMOUNT
        )
        {
            Console.WriteLine($"Spawn type {unitType} with health: {healthAmount} at {spawnPosition} and {spawnRotation}");
        }
    }
}
