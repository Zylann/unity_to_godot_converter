using System.Collections.Generic;
using UnityEngine;

namespace Godot
{
    // Class names must match exactly

    class Node : Godot.Object
    {
        public string name;
        public List<Node> children = new List<Node>();

        public void AddChild(Node newChild)
        {
            string uniqueName = newChild.name;
            bool conflict = true;
            int i = 1;

            while(conflict)
            {
                conflict = false;
                foreach(var existingChild in children)
                {
                    if(existingChild.name == uniqueName)
                    {
                        conflict = true;
                        ++i;
                        uniqueName = newChild.name + i;
                        break;
                    }
                }
            }

            newChild.name = uniqueName;
            children.Add(newChild);
        }
    }



    class CanvasLayer : Node
    {
        public int layer = 0;
        public bool fwEnabled = true;
        public float fwScale = 1.0f;
        public override Dictionary<string, object> GetData()
        {
            var d = base.GetData();
            d.Add("layer", layer);
            d.Add("follow_viewport_enabled", fwEnabled);
            d.Add("follow_viewport_scale", fwScale);
            return d;
        }

    }


    class CanvasItem : Node
    {
        public Color selfModulate = Color.white;
        public bool visible = true;

        public bool zRelative = true;
        public int zIndex = 0;

        public override Dictionary<string, object> GetData()
        {
            var d = base.GetData();
            d.Add("self_modulate", selfModulate);
            d.Add("visible", visible);
            d.Add("z_as_relative", zRelative);
            d.Add("z_index", zIndex);

            return d;
        }
    }



    class Node2D : CanvasItem
    {
        public Vector2 position;
        public Vector2 scale = new Vector2(1, 1);
        public float rotation;

        public override Dictionary<string, object> GetData()
        {
            var d = base.GetData();
            d.Add("position", position);
            d.Add("scale", scale);
            d.Add("rotation", rotation);
            return d;
        }
    }

    class Sprite : Node2D
    {
        public Texture texture;
        public bool flipH = false;
        public bool flipV = false;

        public override Dictionary<string, object> GetData()
        {
            var d = base.GetData();
            d.Add("texture", texture);
            d.Add("flip_h", flipH);
            d.Add("flip_v", flipV);
            return d;
        }
    }


    class ParallaxLayer : Node2D
    {
        public Vector2 motionScale = Vector2.one;

        public override Dictionary<string, object> GetData()
        {
            var d = base.GetData();
            d.Add("motion_scale", motionScale);
            return d;
        }
    }


    class CollisionObject2D : Node2D
    { }

    class PhysicsBody2D : Node2D
    {
        public int collisionLayer = 1;

        public override Dictionary<string, object> GetData()
        {
            var d = base.GetData();
            d.Add("collision_layer", collisionLayer);
            return d;
        }
    }

    class KinematicBody2D : PhysicsBody2D
    { }

    class RigidBody2D : PhysicsBody2D
    { }

    class CollisionShape2D : Node2D
    { }

    class Camera2D : Node2D
    {
        public bool current = false;

        public override Dictionary<string, object> GetData()
        {
            var d = base.GetData();
            d.Add("current", current);
            return d;
        }
    }

    class Control : CanvasItem
    { }

    class Spatial : Node
    { }
}
