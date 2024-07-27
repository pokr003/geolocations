using System.Reflection;

namespace Geolocations.Persistence.EntityConfigurations;

public static class AssemblyReference
{
    public static Assembly GetAssembly() => typeof(AssemblyReference).Assembly;
}