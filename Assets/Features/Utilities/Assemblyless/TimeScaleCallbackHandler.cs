﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Perrinn424.Utilities
{
    internal class TimeScaleCallbackHandler : MonoBehaviour
    {
        [SerializeField]
        private TimeScaleController timeScaleController;

        [SerializeField]
        private Behaviour[] behaviourEnabledOnlyInRealTime;

        [SerializeField]
        private GameObject[] gameObjectsActiveOnlyInRealTime;

        [SerializeField]
        private UnderFloor underfloor;

        private void OnEnable()
        {
            if (underfloor == null)
                underfloor = FindObjectOfType<UnderFloor>();

            timeScaleController.onTimeScaleChanged += OnTimeScaleChangedEventHandler;
        }

        private void OnDisable()
        {
            timeScaleController.onTimeScaleChanged -= OnTimeScaleChangedEventHandler;
        }

        private void OnTimeScaleChangedEventHandler(float obj)
        {
            bool isRealTime = timeScaleController.IsRealTime;
            
            foreach (var behaviour in behaviourEnabledOnlyInRealTime)
            {
                behaviour.enabled = isRealTime;
            }

            foreach (var go in gameObjectsActiveOnlyInRealTime)
            {
                go.SetActive(isRealTime);
            }

            underfloor.isAudioEnabled = isRealTime;
        }

    } 
}