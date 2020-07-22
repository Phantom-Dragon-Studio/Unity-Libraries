namespace PhantomDragonStudio.Projectiles
{
    
    [System.Serializable]
    public struct ProjectileData
    {
        private float value;
        private float lifetime;
        private float speed;

        public ProjectileData(float value, float lifetime, float speed)
        {
            this.value = value;
            this.lifetime = lifetime;
            this.speed = speed;
        }

        public float Speed => speed;
        public float Lifetime => lifetime;
        public float Value => value;
    }
}
