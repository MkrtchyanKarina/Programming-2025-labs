using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInventory
{
    internal abstract class PlayerBuilder
    {
        internal Player player = new Player();

        internal PlayerBuilder SetName(string name)
        {
            player.Name = name;
            return this;
        }

        internal PlayerBuilder SetBalance(int balance)
        {
            player.Balance = balance;
            return this;
        }

        internal PlayerBuilder SetStrength(int strenght)
        {
            player.Strength = strenght;
            return this;
        }

        internal PlayerBuilder SetIntelligence(int intelligence)
        {
            player.Intelligence = intelligence;
            return this;
        }

        internal PlayerBuilder SetHealth(int health)
        {
            player.Health = health;
            return this;
        }

        internal void PrintPlayerInfo()
        {
            player.PrintPlayerInfo();
        }

        internal abstract Player Build();
    }

    internal class BasicPlayerBuilder : PlayerBuilder
    {
        internal BasicPlayerBuilder(string name)
        {
            SetName(name);
            SetBalance(200);
            SetStrength(0);
            SetIntelligence(0);
            SetHealth(0);
        }

        internal override Player Build()
        {
            return player;
        }

    }

    internal class ImprovedPlayerBuilder : PlayerBuilder
    {
        internal ImprovedPlayerBuilder(string name)
        {
            SetName(name);
            SetBalance(500);
            SetStrength(100);
            SetIntelligence(100);
            SetHealth(100);
        }

        internal override Player Build()
        {
            return player;
        }

    }
}
