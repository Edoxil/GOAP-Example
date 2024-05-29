using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP
{
    public class WanderTargetSensor : LocalTargetSensorBase
    {
        public override void Created()
        {

        }

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            Vector3 randomPos = GetRandomPosition(agent);

            return new PositionTarget(randomPos);
        }

        public override void Update()
        {

        }

        private Vector3 GetRandomPosition(IMonoAgent agent)
        {
            bool isOnNavMesh = false;
            Vector3 position = agent.transform.position;
            NavMeshHit hit;

            do
            {
                Vector2 random = Random.insideUnitCircle * 5f;
                position = agent.transform.position + new Vector3(random.x, 0f, random.y);

                if (NavMesh.SamplePosition(position, out hit, position.magnitude, NavMesh.AllAreas))
                {
                    position = hit.position;
                    position.y = 0f;

                    isOnNavMesh = true;
                }
                else
                {
                    isOnNavMesh = false;
                }

            } while (isOnNavMesh == false);

            return position;
        }
    }
}