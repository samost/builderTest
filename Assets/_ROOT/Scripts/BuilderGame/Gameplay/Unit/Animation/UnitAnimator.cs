using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Unit.Animation;
using UnityEngine;

namespace BuilderGame.Gameplay.Unit.Animation
{
    public class UnitAnimator : MonoBehaviour
    {
        private const int HandLayerIndex = 1;
        private readonly int movementParameter = Animator.StringToHash("Movement");
        private readonly int hoeWorkParam = Animator.StringToHash("HoeWork");
        private readonly int plantingSeedsParam = Animator.StringToHash("PlantingSeeds");

        [SerializeField] 
        private float damp = 0.15f;
        [SerializeField]
        private UnitMovement unitMovement;
        [SerializeField]
        private Animator animator;

        private UnitAnimationEventEmitter _eventEmitter;

        public UnitAnimationEventEmitter AnimationEventEmitter => _eventEmitter;
        

        private void OnValidate()
        {
            unitMovement = GetComponentInParent<UnitMovement>();
            animator = GetComponentInChildren<Animator>();
            _eventEmitter = animator.gameObject.GetComponent<UnitAnimationEventEmitter>();
        }

        private void Update()
        {
            var velocityMagnitude = unitMovement.Direction.normalized.sqrMagnitude;

            animator.SetFloat(movementParameter, velocityMagnitude, damp, Time.deltaTime);
        }

        private void SetHandLayerWeight(float weight)
        {
            animator.SetLayerWeight(HandLayerIndex, weight);
        }

        
        

        public void ToggleWorkAnimation(WeaponType weaponType)
        {
            animator.SetLayerWeight(HandLayerIndex, 0.8f);
            
            switch (weaponType)
            {
                case WeaponType.Hoe:
                    
                    animator.SetTrigger(hoeWorkParam);
                    break;
                case WeaponType.Seeds:
             
                    animator.SetTrigger(plantingSeedsParam);
                    break;
                case WeaponType.Hands:
             
                    animator.SetLayerWeight(HandLayerIndex, 0f);
                    break;
            }
            
            
        }
    }
}