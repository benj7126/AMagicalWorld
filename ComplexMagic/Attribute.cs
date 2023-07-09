using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic
{
    public abstract class Attribute
    {
        public static Attribute[] Attributes =
        {
            new Others.Error(), // 0 is fallback

            new Behaviours.Forward(),
            new Casts.PlayerCenter(),
            new Forms.Bolt(),
            new Trails.Glimmer(),

            new Colors.AmethystColor(),
            new Colors.TopazColor(),
            new Colors.SapphireColor(),
            new Colors.EmeraldColor(),
            new Colors.RubyColor(),
            new Colors.AmberColor(),
            new Colors.DiamondColor(),
        };

        public static Attribute Get(int AttributeIDX)
        {
            if (AttributeIDX > Attributes.Length)
                return Attributes[0];

            return Attributes[AttributeIDX];
        }
        public static AttributeTypes Type(int AttributeIDX)
        {
            if (AttributeIDX > Attributes.Length)
                return AttributeTypes.Other;

            return Attributes[AttributeIDX].AttributeType;
        }

        public virtual string Name => "";
        public virtual string Description => "";
        public abstract AttributeTypes AttributeType { get; }

        public virtual Dictionary<Modifiers, modifier> AModifiers => new Dictionary<Modifiers, modifier>();
    }

    public abstract class AForm : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.Form;
        public abstract void Setup(projSpell spell);
        public abstract void Draw(projSpell spell, ref Color color);
    }
    public abstract class ACast : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.Cast;
        public abstract Vector2 Position(Player player);
        public abstract Vector2 Direction(Player player);

    }
    public abstract class ABehaviour : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.Behaviour;

        public abstract bool Update(projSpell spell);

    }
    public abstract class ATrail : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.Trail;

        public abstract void TrailAI(projSpell spell);

    }
    public abstract class AColor : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.Color;

        public abstract Color MainColor(projSpell spell);
        public abstract Color SubColor(projSpell spell);
    }
    public abstract class APreCast : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.PreCast;

    }
    public abstract class AStatusEffect : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.StatusEffect;

    }
    public abstract class AHitTile : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.HitTile;

    }
    public abstract class ATimed : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.Timed;

    }
    public abstract class AConstApplication : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.ConstApplication;

    }
    public abstract class AOther : Attribute
    {
        public override AttributeTypes AttributeType => AttributeTypes.Other;

    }
}
