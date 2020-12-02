using UnityEngine;


namespace Labyrinth
{
    public static class BuilderExtension
    {
        public static GameObject AddTag(this GameObject gameObject, string tag)
        {
            gameObject.tag = tag;
            return gameObject;
        }
        public static GameObject AddName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddTransforn(this GameObject gameObject, Transform transform)
        {
            gameObject.transform.position = transform.position;
            return gameObject;
        }

        public static GameObject AddMesh(this GameObject gameObject, Mesh mesh)
        {
            var component = GetOrAddComponent<MeshFilter>(gameObject);
            component.mesh = mesh;
            return gameObject;
        }
       
        public static GameObject AddRigidbody(this GameObject gameObject, float mass)
        {
            var component = GetOrAddComponent<Rigidbody>(gameObject);
            component.mass = mass;
            return gameObject;
        }
        
        public static GameObject AddSphereCollider(this GameObject gameObject)
        {
            GetOrAddComponent<SphereCollider>(gameObject);
            return gameObject;
        }
        
        public static GameObject AddMaterial(this GameObject gameObject, Material material)
        {
            GetOrAddComponent<MeshRenderer>(gameObject).material = material;
            return gameObject;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
        
            return result;
        }
    }
}
