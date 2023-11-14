using UnityEngine;

namespace SABI.Helper
{
    public static class Chance
    {
        public static bool GetRandomChance(float probability) => (Random.Range(0f, 1f) <= probability);
    }
}