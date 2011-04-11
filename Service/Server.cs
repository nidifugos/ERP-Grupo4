using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using ERP.Agendamento.Dados;


namespace Microsoft.ServiceModel.Samples
{
    class Server
    {
        static void Main(string[] args)
        {
            // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/Service");

            // Step 2 of the hosting procedure: Create ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(FornecedorServiços), baseAddress);

            try
            {


                // Step 3 of the hosting procedure: Add a service endpoint.
                selfHost.AddServiceEndpoint(
                    typeof(IProvedorServiços),
                    new WSHttpBinding(),
                    "FornecedorServiços");


                // Step 4 of the hosting procedure: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                ServiceDebugBehavior behaviour = selfHost.Description.Behaviors.Find<ServiceDebugBehavior>();

                if (behaviour != null)
                {
                    behaviour.IncludeExceptionDetailInFaults = true;
                }
                else
                {
                    selfHost.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
                }

                // Step 5 of the hosting procedure: Start (and then stop) the service.
                selfHost.Open();
                Console.WriteLine("Serviço de agendamento e testes rodando.");
                Console.WriteLine("Pressione <ENTER> para desativar o serviço.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                Console.ReadLine();
                selfHost.Abort();
            }

        }
    }

    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IProvedorServiços
    {
        [OperationContract]
        PacienteSet Agendamento_Paciente(int id);
        [OperationContract]
        List<string> RH_Medicos();
        [OperationContract]
        int RH_MedicoId(string nome);
        [OperationContract]
        List<string> RH_Especialidade();
        [OperationContract]
        List<string> Administracao_PlanoSaude();
        [OperationContract]
        int Financeiro_SolicitarPagamento();
    }

    public class FornecedorServiços : IProvedorServiços
    {

        public PacienteSet Agendamento_Paciente(int id)
        {
            PacienteSet paciente = GerenciadorBanco.GetPacienteById(id);
            Console.WriteLine("Recebeu Id({0})", id);
            //informações para debug e log
            Console.WriteLine("Nome: {0}", paciente.Nome);
            Console.WriteLine("RG: {0}", paciente.Rg);
            return paciente;
        }

        public List<string> RH_Medicos()
        {
            List<string> medicos = new List<string>();            
            medicos.Add("Kleber");
            medicos.Add("Gusmão");
            medicos.Add("Roberval");
            medicos.Add("Camila");
            medicos.Add("Alice");
            return medicos;
        }

        public int RH_MedicoId(string nome)
        {
            Dictionary<string, int> ids = new Dictionary<string, int>();
            ids["Kleber"] = 1;
            ids["Gusmão"] = 2;
            ids["Roberval"] = 3;
            ids["Camila"] = 4;
            ids["Alice"] = 5;
            return ids[nome];
        }

        public List<string> RH_Especialidade()
        {
            List<string> especialidades = new List<string>();
            especialidades.Add("Odontologia");
            especialidades.Add("Oncologia");
            especialidades.Add("Otorrino");
            especialidades.Add("Pediatria");
            especialidades.Add("Obstetria");
            Console.WriteLine("Enviando lista de especialidades.");
            return especialidades;
        }

        public List<string> Administracao_PlanoSaude()
        {
            List<string> planos = new List<string>();
            planos.Add("Amil");
            planos.Add("Golden Cross");
            planos.Add("Medial");
            Console.WriteLine("Enviando lista de planos de saúde.");
            return planos;
        }

        public int Financeiro_SolicitarPagamento()
        {
            Console.WriteLine("Enviando resposta da solicitação de pagamento.");
            return 42;
        }

    }

}
