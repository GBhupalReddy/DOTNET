// See https://aka.ms/new-console-template for more information
int i = 12, j = 30, sum = 0, prod = 0;
Console.WriteLine($"Before Using Out Parameter i = {i} j = {j} sum = {sum} prod = {prod}");
SumProd(i, j, out sum, out prod);
Console.WriteLine($"After Using Out Parameter i = {i} j = {j} sum = {sum} prod = {prod} ");
static void SumProd(int i, int j, out int sum, out int prod)
{
    sum = i+j;
    prod =i * j;
}