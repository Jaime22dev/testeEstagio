using System.Text.Json;

class Program
{
    public static void Main(string[] args)
    {
        // Questão 1
        Console.WriteLine("Questão 1:\nValor da variável soma: " + Soma());

        // Questão 2
        Console.WriteLine();
        Console.WriteLine("Questão 2:");
        Console.Write("Informe um número: ");
        int numero = int.Parse(Console.ReadLine());

        if (PertenceAFibonacci(numero))
        {
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"O número {numero} não pertence à sequência de Fibonacci.");
        }

        // Questão 3
        Console.WriteLine();
        Console.WriteLine("Questão 3:");
        FaturamentoDiarioDistribuidora();

        // Questão 4
        Console.WriteLine();
        Console.WriteLine("Questão 4:");
        FaturamentoPorEstado();

        // Questão 5
        Console.WriteLine();
        Console.WriteLine("Questão 5:");
        Console.Write("Informe uma string para inverter: ");        
        string input = Console.ReadLine();
        InversaoString(input);
    }

    // Questão 1
    public static int Soma()
    {
        int indice = 13;
        int soma = 0;
        int k = 0;

        while (k < indice)
        {
            k++;

            soma += k;
        }

        return soma;
    }

    // Questão 2
    public static bool PertenceAFibonacci(int numero)
    {
        int a = 0;
        int b = 1;

        if (numero == a || numero == b)
        {
            return true;
        }

        int c = a + b;

        while (c <= numero)
        {
            if (c == numero)
            {
                return true;
            }

            a = b;
            b = c;
            c = a + b;
        }

        return false;
    }

    // Questão 3
    class FaturamentoDiario
    {
        public int dia { get; set; }
        public double valor { get; set; }
    }

    public static void FaturamentoDiarioDistribuidora()
    {
        string json = File.ReadAllText("faturamento.json");
        List<FaturamentoDiario> faturamentos = JsonSerializer.Deserialize<List<FaturamentoDiario>>(json);

        double menorValor = double.MaxValue;
        double maiorValor = double.MinValue;
        double soma = 0;
        int diasComFaturamento = 0;

        foreach (var faturamento in faturamentos)
        {
            if (faturamento.valor > 0)
            {
                if (faturamento.valor < menorValor)
                {
                    menorValor = faturamento.valor;
                }

                if (faturamento.valor > maiorValor)
                {
                    maiorValor = faturamento.valor;
                }

                soma += faturamento.valor;

                diasComFaturamento++;
            }
        }

        double mediaMensal = soma / diasComFaturamento;

        int diasAcimaDaMedia = 0;

        foreach (var faturamento in faturamentos)
        {
            if (faturamento.valor > mediaMensal)
            {
                diasAcimaDaMedia++;
            }
        }

        Console.WriteLine($"Menor valor de faturamento: {menorValor}");
        Console.WriteLine($"Maior valor de faturamento: {maiorValor}");
        Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");
    }

    // Questão 4
    public static void FaturamentoPorEstado()
    {
        double faturamentoSP = 67836.43;
        double faturamentoRJ = 36678.66;
        double faturamentoMG = 29229.88;
        double faturamentoES = 27165.48;
        double faturamentoOutros = 19849.53;

        double faturamentoTotal = faturamentoSP + faturamentoRJ + faturamentoMG + faturamentoES + faturamentoOutros;

        double percentualSP = (faturamentoSP / faturamentoTotal) * 100;
        double percentualRJ = (faturamentoRJ / faturamentoTotal) * 100;
        double percentualMG = (faturamentoMG / faturamentoTotal) * 100;
        double percentualES = (faturamentoES / faturamentoTotal) * 100;
        double percentualOutros = (faturamentoOutros / faturamentoTotal) * 100;

        Console.WriteLine($"Percentual de representação por estado:");
        Console.WriteLine($"SP: {percentualSP:F2}%");
        Console.WriteLine($"RJ: {percentualRJ:F2}%");
        Console.WriteLine($"MG: {percentualMG:F2}%");
        Console.WriteLine($"ES: {percentualES:F2}%");
        Console.WriteLine($"Outros: {percentualOutros:F2}%");
    }

    // Questão 5
    public static void InversaoString(string str){
        string stringInvertida = "";

        for (int i = str.Length - 1; i >= 0; i--)
        {
            stringInvertida += str[i];
        }

        Console.WriteLine($"String invertida: {stringInvertida}");
    }
}