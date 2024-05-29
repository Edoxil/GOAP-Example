﻿using CrashKonijn.Goap.Behaviours;
using UnityEngine;

namespace GOAP.Example
{
    public class AgentBrain : MonoBehaviour
    {
        private AgentBehaviour agent;

        private void Awake()
        {
            this.agent = this.GetComponent<AgentBehaviour>();
        }

        private void Start()
        {
            this.agent.SetGoal<WanderGoal>(false);
        }
    }
}