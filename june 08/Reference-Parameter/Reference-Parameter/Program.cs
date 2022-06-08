// See https://aka.ms/new-console-template for more information
int i = 0;
Console.WriteLine("Before using Reference Parameter {0} ", i);
ReferenceParameter(ref i);
Console.WriteLine($"After using Reference Parameter : {i}");
static void ReferenceParameter(ref int j)
{
    j = 120;
}
