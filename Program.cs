using System.Runtime.InteropServices;
using System.Text.Json;

Console.WriteLine(Problema4());

int Problema1()
{
    int idx = 13, sum = 0, k = 0;

    while (k < idx)
    {
        k++;
        sum += k;
    }

    return sum;
}

string Problema2(int n)
{
    string success = $"{n} pertence à sequência de Fibonacci";
    string failure = $"{n} não pertence à sequência de Fibonacci";

    if (n == 0)
    {
        return success;
    }

    int a = 0, b = 1;

    Console.WriteLine(a);
    while (b < n)
    {
        Console.WriteLine(b);
        int aux = b;
        b = a + b;
        a = aux;

        if (b == n)
        {
            return success;
        }
    }

    return failure;
}

List<Faturamento> LoadJson(string filename)
{
    JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

    var json = File.ReadAllText(filename);
    var data = JsonSerializer.Deserialize<List<Faturamento>>(json, options);

    if (data == null)
    {
        return Enumerable.Empty<Faturamento>().ToList();
    }

    return data;
}

(float, float, int) Problema3()
{
    List<Faturamento> faturamentos = LoadJson("dados.json");
    float min = faturamentos.Min((f) => f.Valor);
    float max = faturamentos.Max((f) => f.Valor);

    IEnumerable<Faturamento> faturamentosGT0 = faturamentos.Where(f => f.Valor > 0f);
    float avg = faturamentosGT0.Average((f) => f.Valor);
    int goodDays = faturamentos.Count((f) => f.Valor > avg);

    return (min, max, goodDays);
}

(double, double, double, double, double) Problema4()
{
    double SP = 67836.43, RJ = 36678.66, MG = 29229.88, ES = 27165.48, outros = 19849.53;

    double sum = SP + RJ + MG + ES + outros;

    return (100 * SP / sum, 100 * RJ/ sum, 100 * MG / sum, 100 * ES / sum, 100 * outros / sum);
}

string Problema5(string s)
{
    string rev = "";
    int len = s.Length;
    for (int i = len - 1; i >= 0; i--)
    {
        rev += s[i];
    }

    return rev;
}

class Faturamento
{
    public int Dia { get; set; }
    public float Valor { get; set; }

    public override string ToString()
    {
        return $"Dia {Dia}: {Valor}";
    }
}
