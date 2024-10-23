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

        // Remover espaços desnecessários de cada departamento
        List<string> departamentosLimpos = RemoverEspacosDesnecessarios(departamentos);
        
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

    static List<string> RemoverEspacosDesnecessarios(List<string> departamentos) {
        List<string> resultado = new List<string>();

        foreach (var item in departamentos)
        {
            // Remover espaços no início e no final
            string itemLimpo = item.Trim();

            // Adicionar o item limpo à lista de resultados
            resultado.Add(itemLimpo);
        }

        return resultado;
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