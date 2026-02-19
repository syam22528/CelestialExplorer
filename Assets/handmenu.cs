using Oculus.Interaction.Input;
using System.Collections.Generic;
using UnityEngine;

namespace Oculus.Interaction.Samples.PalmMenu
{
    public class HandMenu : MonoBehaviour, IGameObjectFilter
    {
        [SerializeField, Interface(typeof(IHand))]
        private Object _leftHand;

        [SerializeField, Interface(typeof(IHand))]
        private Object _rightHand;

        [SerializeField]
        private GameObject[] _leftHandedGameObjects;

        [SerializeField]
        private GameObject[] _rightHandedGameObjects;

        private IHand LeftHand { get; set; }
        private IHand RightHand { get; set; }

        private readonly HashSet<GameObject> _leftHandedGameObjectSet = new HashSet<GameObject>();
        private readonly HashSet<GameObject> _rightHandedGameObjectSet = new HashSet<GameObject>();

        protected virtual void Start()
        {
            foreach (var go in _leftHandedGameObjects)
            {
                _leftHandedGameObjectSet.Add(go);
            }

            foreach (var go in _rightHandedGameObjects)
            {
                _rightHandedGameObjectSet.Add(go);
            }

            LeftHand = _leftHand as IHand;
            RightHand = _rightHand as IHand;
        }

        public bool Filter(GameObject go)
        {
            // Check if hand tracking is active
            bool isHandTrackingActive = OVRInput.GetActiveController() == OVRInput.Controller.Hands;

            if (isHandTrackingActive)
            {
                // Hand Tracking: Use the existing hand logic
                if (LeftHand.IsDominantHand)
                {
                    return _leftHandedGameObjectSet.Contains(go);
                }
                else if (RightHand.IsDominantHand)
                {
                    return _rightHandedGameObjectSet.Contains(go);
                }
            }
            else
            {
                // Controller Mode: Check dominant controller
                OVRInput.Controller dominantController = OVRInput.GetActiveController();

                if (dominantController == OVRInput.Controller.LTouch)
                {
                    return _leftHandedGameObjectSet.Contains(go);
                }
                else if (dominantController == OVRInput.Controller.RTouch)
                {
                    return _rightHandedGameObjectSet.Contains(go);
                }
            }

            return false;
        }
    }
}
