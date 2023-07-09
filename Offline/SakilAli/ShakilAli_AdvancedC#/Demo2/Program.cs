using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Demo2
{
    //interface IShape
    //{
    //    void Draw();
    //}
    //class Circle : IShape
    //{
    //    public void Draw()
    //    {
    //        Console.WriteLine("Circle");
    //    }
    //}

    //class Rectangle : IShape
    //{
    //    public void Draw()
    //    {
    //        Console.WriteLine("Rectangle");
    //    }
    //}

    class MyExpandoObject : DynamicObject
    {
        private Dictionary<string, object> dict = new Dictionary<string, object>();

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dict[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (dict.ContainsKey(binder.Name))
            {
                result = dict[binder.Name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
    }

    class Program
    {
        //static void CallDraw(IShape d)
        //{
        //    d.Draw();
        //}

        static void Main(string[] args)
        {
            dynamic d = new MyExpandoObject();

            d.X1 = 100; // TrySetMember
            d.Y1 = 200; // TrySetMember
            d.dsjfhdjfhjdhjfhj = 80; // TrySetMember
            d.Z1 = 400;

            Console.WriteLine(d.Z2); // TryGetMember

            //CallDraw(new Rectangle());
            //CallDraw(new Circle());
        }
    }
}
