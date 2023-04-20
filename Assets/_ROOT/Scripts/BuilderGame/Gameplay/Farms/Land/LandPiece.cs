using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using BuilderGame.Gameplay.Farms.Data;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms
{
    public class LandPiece: MonoBehaviour
    {
        [SerializeField]
        private GameObject _seedsRoot;
        [SerializeField]
        private MeshRenderer _meshRenderer;

        public WeaponType WeaponType
        {
            get;
            set;
        }

        public GameObject SeedRoot => _seedsRoot;

        public MeshRenderer MeshRenderer => _meshRenderer;
        public UnitFarmController Fitter { get; set; }

        private LandStateMachine _landStateMachine;

        private void Awake()
        {
            _landStateMachine = new LandStateMachine(this);
            _landStateMachine.ChangeState(_landStateMachine.GrassLandState);
            SeedRoot.SetActive(false);
            
        }

        public void Hit()
        {
            _landStateMachine.Hit();
        }


        public void SendSeedData(SeedData seedData)
        {
            _landStateMachine.SeedLandState.AddSeedData(seedData);
            _landStateMachine.DoneLandState.AddSeedData(seedData);
        }
    }
}