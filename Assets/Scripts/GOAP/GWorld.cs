using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public sealed class GWorld
    {
        private static readonly GWorld instance = new GWorld();
        private static WorldStates world;
        private static Queue<GameObject> patients;
        private static Queue<GameObject> cubicles;
        private static Queue<GameObject> receptions;

        static GWorld()
        {
            world = new WorldStates();
            patients = new Queue<GameObject>();
            cubicles = new Queue<GameObject>();
            receptions = new Queue<GameObject>();

            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
            foreach (GameObject c in cubes)
                cubicles.Enqueue(c);

            if (cubes.Length > 0)
                world.ModifyState("FreeCubicle", cubes.Length);


            GameObject[] rcp = GameObject.FindGameObjectsWithTag("Reception");
            foreach (GameObject r in rcp)
                receptions.Enqueue(r);

            if (rcp.Length > 0)
                world.ModifyState("FreeReception", rcp.Length);

        }

        private GWorld() {}

        public void AddPatient(GameObject p)
        {
            patients.Enqueue(p);
        }

        public GameObject RemovePatient()
        {
            if (patients.Count == 0)
                return null;
            else
                return patients.Dequeue();
        }

        public void AddCubicle(GameObject p)
        {
            cubicles.Enqueue(p);
        }
        public GameObject RemoveCubicle()
        {
            if (cubicles.Count == 0)
                return null;
            else
                return cubicles.Dequeue();
        }

        public void AddReception(GameObject p)
        {
            receptions.Enqueue(p);
        }

        public GameObject RemoveReception()
        {
            if (receptions.Count == 0)
                return null;
            else
                return receptions.Dequeue();
        }

        public static GWorld Instance
        {
            get { return instance; }
        }

        public WorldStates GetWorld()
        {
            return world;
        }
    }
}
