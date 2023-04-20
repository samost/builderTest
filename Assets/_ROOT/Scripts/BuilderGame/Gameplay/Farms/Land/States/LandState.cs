
using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.States;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States
{
    public abstract class LandState: IState
    {
        protected LandStateMachine _landStateMachine;

        protected LandState(LandStateMachine landStateMachine)
        {
            _landStateMachine = landStateMachine;
        }

        public virtual void Enter()
        {
            _landStateMachine.LandPiece.WeaponType = GetValidWeaponType();
            Debug.Log(string.Format("Enter into state: {0}", this.GetType()));
        }

        public virtual void Exit()
        {
            
        }

        public virtual void Update()
        {
           
        }

        public abstract WeaponType GetValidWeaponType();
    }
}