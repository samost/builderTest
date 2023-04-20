using UnityEngine;

namespace BuilderGame.Gameplay.Farms.Data
{
    [CreateAssetMenu(fileName = nameof(SeedData))]
    public class SeedData: ScriptableObject
    {
        public float TimeGrowth;
        public GameObject ResultPlant;
        public GameObject Fetus;
        public float FetusCount;
    }
}