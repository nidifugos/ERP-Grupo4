using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Agendamento.Dados
{
    class BancoTest
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Executando testes de relatórios.");

            GerenciadorRelatórios.AgendaMédica agenda = new GerenciadorRelatórios.AgendaMédica(1, 6);

            VisualizadorRelatorioPDF.Agenda(agenda);

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Buscando agenda do médico 1 para 6 meses");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------");

            foreach(KeyValuePair<int, List<AgendamentoSet>> agendamentoMes in agenda.Agenda.ToList())
            {
                Console.WriteLine("Mes {0}", agendamentoMes.Key);
                foreach (AgendamentoSet agendamento in agendamentoMes.Value)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Agendamento: {0}", agendamento.Id);
                    Console.WriteLine("Paciente: {0}", agendamento.PacienteSet.Nome);
                    Console.WriteLine("Especialidade: {0}", agendamento.Especialidade);
                    Console.WriteLine("Descrição: {0}", agendamento.Descricao);
                    Console.WriteLine("=====================");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Buscando agendamentos por setor");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------");

            GerenciadorRelatórios.AgendamentosSetores estatisticaSetor = new GerenciadorRelatórios.AgendamentosSetores();

            VisualizadorRelatorioPDF.AgendamentosSetores(estatisticaSetor);

            foreach (KeyValuePair<string, float> agendamentoSetor in estatisticaSetor.AgendamentosSetor.ToList())
            {
                Console.WriteLine("Setor: {0} - Agendamentos: {1}", agendamentoSetor.Key, agendamentoSetor.Value);
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Gerando estatísticas de agendamento");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------");

            GerenciadorRelatórios.AgendamentosEstatísticas agendamentoEstatistica = new GerenciadorRelatórios.AgendamentosEstatísticas();

            VisualizadorRelatorioPDF.EstatisticasAgendamento(agendamentoEstatistica);

            Console.WriteLine("");
            Console.WriteLine("Porcentagem de agendamentos cancelados: {0}", agendamentoEstatistica.PorcentagemCancelados);

            foreach (KeyValuePair<int, int> agendamentoMes in agendamentoEstatistica.AgendamentosMes.ToList())
            {
                Console.WriteLine("Mes: {0} - Agendamentos: {1}", agendamentoMes.Key, agendamentoMes.Value);
            }

            Console.ReadLine();
        }
    }
}
