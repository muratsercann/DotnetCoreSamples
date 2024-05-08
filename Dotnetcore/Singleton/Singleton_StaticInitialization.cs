using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    /// <summary>
    /// In this strategy, the instance is created 
    /// the first time any member of the class is referenced. 
    /// 
    /// The common language runtime takes care of the variable initialization.
    /// 
    /// In addition, the variable is marked readonly, 
    /// which means that it can be assigned only during 
    /// static initialization (which is shown here) or in a class constructor.
    /// 
    /// The only potential downside of this approach is that 
    /// you have less control over the mechanics of the instantiation. 
    /// In the Design Patterns form, you were able to use 
    /// a nondefault constructor or perform other tasks before the instantiation.
    /// Because the .NET Framework performs the initialization in this solution, 
    /// you do not have these options. 
    /// In most cases, static initialization is the 
    /// preferred approach for implementing a Singleton in .NET.
    /// </summary>
    public sealed class Singleton_StaticInitialization //Most Preferred
    {
        private static readonly Singleton_StaticInitialization instance = new Singleton_StaticInitialization();

        private Singleton_StaticInitialization(){}

        public static Singleton_StaticInitialization Instance
        {
            get
            {
                return instance;
            }
        }


    }
}
