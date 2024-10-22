using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        // Leitura da entrada do usuário
        Console.WriteLine("Digite os departamentos dos funcionários separados por vírgula:");

        string input = Console.ReadLine();

        // Processamento da entrada
        List<string> departamentos = input.Split(',').ToList();
        
        // Contagem de funcionários por departamento
        Dictionary<string, int> contagemDepartamentos = ContarFuncionariosPorDepartamento(departamentos);

        // Formatação da saída
        var resultado = string.Join(
            Environment.NewLine, 
            contagemDepartamentos.OrderBy(depto => depto.Key)
            .Select(depto => $"{depto.Key}: {depto.Value}")
        );

        Console.WriteLine(resultado);
    }

    static string RemoverEspacosDesnecessarios(string input){
        // Remover espaços no início e no final
        input = input.Trim();

        // Remover espaços extras entre palavras
        string[] palavras = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", palavras);
    }

		// Método que conta o número de funcionários em cada departamento.
    static Dictionary<string, int> ContarFuncionariosPorDepartamento(List<string> departamentos) {
        var contagem = new Dictionary<string, int>();
        
		// Iterar sobre cada departamento na lista 'departamentos'
        foreach (var departamento in departamentos)
        {
            // Se o departamento já existe no dicionário, incrementar a contagem
            if (contagem.ContainsKey(departamento)) {
                contagem[departamento]++;

            } else { // Caso contrário, adicionar o departamento ao dicionário com contagem inicial de 1
                contagem[departamento] = 1;

            }
        }
				
        return contagem;
    }
}