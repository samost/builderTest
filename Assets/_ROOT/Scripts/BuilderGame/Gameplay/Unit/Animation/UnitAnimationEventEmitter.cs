using System;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Unit.Animation
{
    [RequireComponent(typeof(Animator))]
    public class UnitAnimationEventEmitter: MonoBehaviour
    {
        public event Action OnTriggered;
        
        #region InspectorMethods

        public void OnAnimationEventTriggered()
        {
            OnTriggered?.Invoke();
        }

        #endregion
       
    }
}