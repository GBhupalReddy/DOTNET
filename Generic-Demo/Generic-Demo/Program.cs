// See https://aka.ms/new-console-template for more information

using Generic_Demo.Core;
using System.Collections;
using System.Diagnostics;

Comparision cm = new Comparision();
Console.WriteLine(cm.Compar<int>(3,5));
Console.WriteLine(cm.Compar<string>("",""));
var nonGenericList = new ArrayList { 1, 2, 3, 4, 5 };
Stopwatch nonstopwatch= Stopwatch.StartNew();
nonstopwatch.Start();
nonGenericList.Sort();
nonstopwatch.Stop();
Console.WriteLine(nonstopwatch.Elapsed.TotalMilliseconds);
var GenericList =new List<int> { 1, 2, 3, 4, 5 };
Stopwatch GenericStopwatch = Stopwatch.StartNew();
GenericStopwatch.Start();
GenericList.Sort();
GenericStopwatch.Stop();
Console.WriteLine(GenericStopwatch.Elapsed.TotalMilliseconds);
