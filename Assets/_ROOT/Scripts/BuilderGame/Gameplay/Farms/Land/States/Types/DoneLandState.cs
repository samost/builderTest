using System.Collections;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using BuilderGame.Gameplay.Farms.Data;
using DG.Tweening;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Land.States.Types
{
    public class DoneLandState : LandState
    {
        private SeedData _seedData;

        private int _fetusCounter;


        public DoneLandState(LandStateMachine landStateMachine) : base(landStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _landStateMachine.LandPiece.StartCoroutine(IngatheringRoutine());
        }

        public override WeaponType GetValidWeaponType()
        {
            return WeaponType.Hands;
        }


        public void AddSeedData(SeedData seedData)
        {
            _seedData = seedData;
        }

        private IEnumerator IngatheringRoutine()
        {
            while (_fetusCounter < _seedData.FetusCount)
            {
                if (_landStateMachine.LandPiece.Fitter != null)
                {
                    var instance = GameObject.Instantiate(_seedData.Fetus,
                        _landStateMachine.LandPiece.transform.position + Vector3.up, Quaternion.identity);
                    instance.transform.DOMove(_landStateMachine.LandPiece.Fitter.transform.position, 0.5f)
                        .OnComplete((() => instance.SetActive(false)));

                    yield return new WaitForSeconds(0.2f);

                    _fetusCounter++;
                }

                yield return null;
            }
        }
    }
}