using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ERP.Agendamento.Dados;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ERP.Agendamento.Dados
{
    class VisualizadorRelatorioPDF
    {

        public static void Agenda(GerenciadorRelatórios.AgendaMédica agenda)
        {
            Document relatorio = new Document();
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(relatorio, new FileStream("relatoagenda.pdf", FileMode.Create));
                relatorio.Open();

                PdfPTable table = new PdfPTable(5);
                table.TotalWidth = relatorio.PageSize.Width;
                table.LockedWidth = false;
                table.AddCell("HORÁRIO");
                table.AddCell("DESCRIÇÃO");
                table.AddCell("ESPECIALIDADE");
                table.AddCell("PACIENTE");
                table.AddCell("SALA");

                foreach (KeyValuePair<int,List<AgendamentoSet>> mesAgendamento in agenda.Agenda)
                {
                    foreach (AgendamentoSet agendamento in mesAgendamento.Value)
                    {
                        table.AddCell(agendamento.Datahora.ToString());
                        table.AddCell(agendamento.Descricao);
                        table.AddCell(agendamento.Especialidade);
                        table.AddCell(agendamento.PacienteSet.Nome);
                        table.AddCell(agendamento.Sala_Id.ToString());
                    }
                }

                relatorio.Add(table);
            }
            catch (DocumentException de)
            {
                //yaya
            }
            catch (IOException ioe)
            {
                //yaya2
            }
            relatorio.Close();
        }


        public static void AgendamentosSetores(GerenciadorRelatórios.AgendamentosSetores agendamentosSetores)
        {
            Document relatorio = new Document();
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(relatorio, new FileStream("relatosetores.pdf", FileMode.Create));
                relatorio.Open();

                PdfPTable table = new PdfPTable(2);
                table.TotalWidth = relatorio.PageSize.Width;
                table.LockedWidth = false;
                table.AddCell("SETOR");
                table.AddCell("NÚMERO DE AGENDAMENTOS");

                foreach (KeyValuePair<string, float> agendamentoSetor in agendamentosSetores.AgendamentosSetor.ToList())
                {
                    table.AddCell(agendamentoSetor.Key);
                    table.AddCell(agendamentoSetor.Value.ToString());
                }

                relatorio.Add(table);
            }
            catch (DocumentException de)
            {
                //yaya
            }
            catch (IOException ioe)
            {
                //yaya2
            }
            relatorio.Close();
        }



        public static void EstatisticasAgendamento(GerenciadorRelatórios.AgendamentosEstatísticas agendamentosEstatisticas)
        {
            Document relatorio = new Document();
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(relatorio, new FileStream("relatoestatistica.pdf", FileMode.Create));
                relatorio.Open();

                Paragraph paragraph = new Paragraph("Porcentagem de agendamentos cancelados:   " + agendamentosEstatisticas.PorcentagemCancelados);
                paragraph.SpacingAfter = 20;
                relatorio.Add(paragraph);

                PdfPTable table = new PdfPTable(2);
                table.TotalWidth = relatorio.PageSize.Width;
                table.LockedWidth = false;
                table.AddCell("MÊS");
                table.AddCell("NÚMERO DE AGENDAMENTOS");

                foreach (KeyValuePair<int, int> agendamentoMes in agendamentosEstatisticas.AgendamentosMes.ToList())
                {
                    table.AddCell(agendamentoMes.Key.ToString());
                    table.AddCell(agendamentoMes.Value.ToString());
                }

                relatorio.Add(table);
            }
            catch (DocumentException de)
            {
                //yaya
            }
            catch (IOException ioe)
            {
                //yaya2
            }

            relatorio.Close();

        }
    }
}
