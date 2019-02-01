using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    class DecoratorProgram
    {
        static void Main(string[] args)
        {
            var client = new DecoratorClient();

            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a sumple component:");
            client.ClientCode(simple);
            Console.WriteLine();

            ConcreteDecoratorA d1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB d2 = new ConcreteDecoratorB(d1);
            Console.WriteLine("Client: Now I get a decorated component:");
            client.ClientCode(d2);
        }
    }

    public class DecoratorClient
    {
        public void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

    public abstract class Component
    {
        public abstract string Operation();
    }

    class ConcreteComponent : Component
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public Decorator(Component component)
        {
            this.component = component;
        }

        public override string Operation()
        {
            if (component != null)
            {
                return component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return "ConcreteDecoratorA(" + base.Operation() + ")";
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return "ConcreteDecoratorB(" + base.Operation() + ")";
        }
    }
}
