﻿Assembly? thisAssembly = Assembly.GetEntryAssembly();

if (thisAssembly is null)
{
    WriteLine("Could not get the entry assembly.");
    return;
}

OutputAssemblyInfo(thisAssembly);

WriteLine("Creating load context for:\n  {0}\n", Path.GetFileName(thisAssembly.Location));

DemoAssemblyLoadContext loadContext = new(thisAssembly.Location);

string assemblyPath = Path.Combine(Path.GetDirectoryName(thisAssembly.Location) ?? "", "DynamicLoad.Library.dll");

WriteLine("Loading:\n  {0}\n", Path.GetFileName(assemblyPath));

Assembly dogAssembly = loadContext.LoadFromAssemblyPath(assemblyPath);

OutputAssemblyInfo(dogAssembly);

Type? dogType = dogAssembly.GetType("DynamicLoad.Library.Dog");

if (dogType is null)
{
    WriteLine("Could not get the Dog type.");
    return;
}

MethodInfo? method = dogType.GetMethod("Speak");

if (method is not null)
{
    object? dog = Activator.CreateInstance(dogType);

    for (int i = 0; i < 10; i++)
    {
        method.Invoke(dog, new object[] { "Ozzy" });
    }
}

WriteLine();
WriteLine("Unloading context and assemblies.");
loadContext.Unload();
