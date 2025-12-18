using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInventory
{
    public abstract class PlayerBuilder
    {
        public Player player = new Player();

        public PlayerBuilder SetName(string name)
        {
            player.Name = name;
            return this;
        }

        public PlayerBuilder SetBalance(int balance)
        {
            player.Balance = balance;
            return this;
        }

        public PlayerBuilder SetStrength(int strenght)
        {
            player.Strength = strenght;
            return this;
        }

        public PlayerBuilder SetIntelligence(int intelligence)
        {
            player.Intelligence = intelligence;
            return this;
        }

        public PlayerBuilder SetHealth(int health)
        {
            player.Health = health;
            return this;
        }

        public void PrintPlayerInfo()
        {
            player.PrintPlayerInfo();
        }

        public abstract Player Build();
    }

    public class BasicPlayerBuilder : PlayerBuilder
    {
        public BasicPlayerBuilder(string name)
        {
            SetName(name);
            SetBalance(200);
            SetStrength(0);
            SetIntelligence(0);
            SetHealth(0);
        }

        public override Player Build()
        {
            return player;
        }

    }

    public class ImprovedPlayerBuilder : PlayerBuilder
    {
        public ImprovedPlayerBuilder(string name)
        {
            SetName(name);
            SetBalance(500);
            SetStrength(100);
            SetIntelligence(100);
            SetHealth(100);
        }

        public override Player Build()
        {
            return player;
        }

    }
}
