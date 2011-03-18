using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Agendamento.Dados;

namespace ERP.Agendamento.Serviços.Utils
{
    class ServiceTest
    {
        static ProvedorServiçosClient client = new ProvedorServiçosClient();

        static void Main(string[] args)
        {
            try
            {

                //Teste do serviço de pacientes
                Console.WriteLine("Buscando paciente com id 15");
                Console.WriteLine("");
                PacienteSet paciente = SolicitadorServiços.AccessAgendamento_Paciente(15);
                Console.WriteLine("Nome: {0}", paciente.Nome);
                Console.WriteLine("Peso: {0}", paciente.Peso);
                Console.WriteLine("Altura: {0}", paciente.Altura);
                Console.WriteLine("Rg: {0}", paciente.Rg);
                Console.WriteLine("Sexo: {0}", paciente.Sexo);
                Console.WriteLine("TelefoneCel: {0}", paciente.TelefoneCelular);
                Console.WriteLine("TelefoneCom: {0}", paciente.TelefoneComercial);
                Console.WriteLine("TelefoneRes: {0}", paciente.TelefoneResidencial);
                Console.WriteLine("Tipo Sanguineo: {0}", paciente.TipoSanguineo);
                Console.WriteLine("Mae: {0}", paciente.AfiliacaoMae);
                Console.WriteLine("Pai: {0}", paciente.AfiliacaoPai);
                Console.WriteLine("");
                Console.WriteLine("");

                //Teste do serviço de médicos por especialidade
                Console.WriteLine("Listando médicos por especialidade:");
                Console.WriteLine("");
                foreach (string medico in SolicitadorServiços.AccessRH_MedicoEspecialidade(1))
                {
                    Console.WriteLine("{0}", medico);
                }
                Console.WriteLine("");
                Console.WriteLine("");

                //Teste do serviço de especialidades
                Console.WriteLine("Listando especialidades:");
                Console.WriteLine("");
                foreach(string especialidade in SolicitadorServiços.AccessRH_Especialidade())
                {
                    Console.WriteLine("{0}", especialidade);
                }
                Console.WriteLine("");
                Console.WriteLine("");

                //Teste do serviço de planos de saúde
                Console.WriteLine("Listando planos de saude:");
                Console.WriteLine("");
                foreach (string plano in SolicitadorServiços.AccessAdministracao_PlanoSaude())
                {
                    Console.WriteLine("{0}", plano);
                }
                Console.WriteLine("");
                Console.WriteLine("");

                //Teste do serviço de solicitação de pagamentos
                Console.WriteLine("Solicitando pagamento:");
                Console.WriteLine("");
                Console.WriteLine("Resposta: {0}", SolicitadorServiços.AccessFinanceiro_SolicitarPagamento());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
