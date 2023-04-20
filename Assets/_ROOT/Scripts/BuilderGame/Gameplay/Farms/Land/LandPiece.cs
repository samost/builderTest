using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States.Types;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms
{
    public class LandPiece: MonoBehaviour
    {
        public WeaponType WeaponType
        {
            get;
            set;
        }
        
        private LandStateMachine _landStateMachine;

        private void Awake()
        {
            _landStateMachine = new LandStateMachine(this);
            _landStateMachine.ChangeState(_landStateMachine.GrassLandState);
        }

        public void Hit()
        {
            _landStateMachine.Hit();
        }

    }
}