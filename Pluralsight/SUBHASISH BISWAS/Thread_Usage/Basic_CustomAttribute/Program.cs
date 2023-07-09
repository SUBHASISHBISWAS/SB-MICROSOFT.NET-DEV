using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CustomAttribute
{

    /*
     * Custom attributes allow you to declaratively annotate your code constructs, thereby enabling special features
     * Custom attributes allow information to be defined and applied to almost any metadata table entry. This extensible metadata information
       can be queried at runtime to dynamically alter the way code executes
     * 
     * Attributes, such as public, private, static, and so on, can be applied to types and members
     * 
     * the compiler simply detects the attributes in the source code and emits the corresponding metadata.
     * 
     * StructLayout attribute is applied to the OSVERSIONINFO [class], 
     * the MarshalAs attribute is applied to the CSDVersion [field], 
     * the DllImport attribute is applied to the GetVersionEx [method], and 
     * the In and Out attributes are applied to GetVersionEx’s ver [parameter].
     * 
     * C# allows you to apply an attribute only to source code that defines
       any of the following targets: assembly, module, type (class, struct, enum, interface, delegate),
       field, method (including constructors), method parameter, method return value, property,
       event, and generic type parameter
     
     custom attribute classes must be derived, directly or indirectly, from the public abstract System.Attribute class.
     * 
     
     * 
     * The AttributeUsageAttribute class offers two additional public properties that can
       optionally be set when the attribute is applied to an attribute class: AllowMultiple and
       Inherited.
     * 
     * [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
     * 
     *  If you examine the DllImportAttribute class in the
        documentation, you’ll see that its [constructor requires a single String parameter]. In this
        example, "Kernel32" is being passed for this parameter. A constructor’s parameters are
        called [positional parameters] and are [mandatory]; the parameter must be specified when the
        attribute is applied.
     
     * What are the other two “parameters”? This special syntax allows you to [set any public fields
       or properties of the DllImportAttribute] object after the object is constructed
       The “parameters” that set fields or properties are called [named parameters] and are optional 
       because the parameters don’t have to be specified when you’re applying an instance of the attribute.
     
     *  As I mentioned earlier, an attribute is an instance of a class. The class must have a public
        constructor so that instances of it can be created. So when you apply an attribute to a target,
        the syntax is similar to that for [calling one of the class’s instance constructors]. In addition, a
        language might permit some special syntax to allow you to set any public fields or properties
        associated with the attribute class.
     
     * 
     * To tell the compiler where this attribute can legally be applied, you apply an instance of the 
     * System.AttributeUsageAttribute class to the attribute class.
     * 
     * AttributeUsage class can be applied in class method event field return type etc
     * 
     * The AttributeUsageAttribute class offers two additional public properties that can
       optionally be set when the attribute is applied to an attribute class: AllowMultiple and
       Inherited.
     * 
     * If you want to allow same attribute multiple time in same target the use AllowMultiple=true for AttributeUsage
     * If you don’t explicitly set AllowMultiple to true, your attribute can be applied no more than once to a selected target.
     * 
     * AttributeUsageAttribute’s other property, [Inherited], indicates if the attribute should be applied to derived classes
     * and overriding methods when applied on the base class.
     * 
     * 
     * If you define your own attribute class and forget to apply an AttributeUsage attribute
       to your class, the compiler and the CLR will assume that your attribute can be applied to all targets,
       can be applied only once to a single target, and is inherited
     * 
     * Attribute class defines three static methods for retrieving the attributes associated with a target: IsDefined, 
     * GetCustomAttributes, and GetCustomAttribute.
     */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method |AttributeTargets.ReturnValue |AttributeTargets.Parameter |
     AttributeTargets.Property |AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Constructor, Inherited = true,AllowMultiple=true)]
    public class AuthorAttribute : System.Attribute
    {
        private string myString;

        public String Author
        {
            get
            {
                return myString;
            }
        }

        public Double Version
        {
            get;
            set;
        }

        public AuthorAttribute()
        {

        }
        public AuthorAttribute(String aString)
        {
            this.myString = aString;
           
        }

        
    }

    /*
     * * AttributeUsageAttribute’s other property, [Inherited], indicates if the attribute should be applied to derived classes
     * and overriding methods when applied on the base class.
     * 
     * In this code, DerivedType and its DoSomething method are both considered Tasty because
       the TastyAttribute class is marked as inherited. However, DerivedType is not serializable
       because the FCL’s SerializableAttribute class is marked as a noninherited attribute.
     */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    internal class TastyAttribute : Attribute
    {

    }
    [Tasty]
    [Serializable]
    internal class BaseType
    {
        [Tasty]
        protected virtual void DoSomething() { }
    }
    internal class DerivedType : BaseType
    {
        protected override void DoSomething() { }
    }

    [type:Tasty]
    [type: Author("SUBHASISH", Version = 1.0)]
    internal sealed class Program
    {
        [field: Author("SUBHASISH", Version = 1.0)] // Applied to field
        public Int32 SomeField = 0;

        [event: Author("SUBHASISH", Version = 1.0)] // Applied to event
        [field: Author("SUBHASISH", Version = 1.0)] // Applied to compiler-generated field
        [method: Author("SUBHASISH", Version = 1.0)] // Applied to compiler-generated add & remove methods
        public event EventHandler SomeEvent;

        [property: Author("SUBHASISH", Version = 1.0)] // Applied to property
        public String SomeProp
        {
            [method: Author] // Applied to get accessor method
            get { return null; }
        }

        [Tasty]
        [return: Author] // Applied to return value
        [method: Author("SUBHASISH",Version=1.0)]// Applied to method
        [method:Author("ASMITA",Version=2.0)]
        public static Int32 SomeMethod([param: Author] Int32 someParam) // Applied to parameter
        {
            return someParam;
        }

        [method: Author("SUBHASISH", Version = 1.0)]
        public Program()
        {

        }
        static void Main(string[] args)
        {
          
            MemberInfo[] info = typeof(Program).FindMembers(MemberTypes.Constructor | MemberTypes.Field | MemberTypes.Method |MemberTypes.All,BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static,Type.FilterName,"*");
            foreach (var member in info)
            {
                ShowAttributes(member);
            }
            
            //Console.WriteLine("LET ME LIVE STRESS FREE....");


        }

        private static void ShowAttributes(MemberInfo attributeTarget)
        {
            Attribute[] aAttributes = Attribute.GetCustomAttributes(attributeTarget);

            foreach (var aAttribute in aAttributes)
            {
                if (aAttribute is AuthorAttribute)
                {
                    Console.WriteLine(" MemberName={0}", ((AuthorAttribute)aAttribute).Author);

                    Console.WriteLine(" MemberName={0}", ((AuthorAttribute)aAttribute).Version);
                }

                if (aAttribute is TastyAttribute)
                {
                    Console.WriteLine(" MemberName={0}", ((TastyAttribute)aAttribute).TypeId);
                }
            }

        }
    }


    
}
