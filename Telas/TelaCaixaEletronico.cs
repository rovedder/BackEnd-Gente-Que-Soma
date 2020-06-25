using TrabBackEndFinal.Entidades;

namespace TrabBackEndFinal.Telas
{
    public class TelaCaixaEletronico : TelaBase
    {
        protected CaixaEletronico Caixa = new CaixaEletronico();

        /// <summary>
        /// Executa a tela principal do caixa eletronico
        /// </summary>
        public void Executar()
        {
            bool executando = true;

            int opcao = default(int);

            do 
            {
                LimparTela();

                Escrever("1 - Depositar");
                Escrever("2 - Sacar");
                Escrever("3 - Verificar Saldo");
                Escrever("4 - Sair");
                opcao = EscreverLerInt("Escolha uma opcao");

                switch(opcao) 
                {
                    case 1:
                        Depositar();
                        break;

                    case 2:
                        Sacar();
                        break;

                    case 3:
                        VerificarSaldo();
                        break;

                    case 4:
                        executando = false;
                        break;

                    default:
                        Escrever("Opcao invalida.");
                        break;
                }
            } while(executando);
        }

        /// <summary>
        /// Tela de depositos
        /// </summary>
        private void Depositar()
        {
            LimparTela();

            int quantidade = default(int);

            Escrever("Informe quantas notas deseja depositar");

            quantidade = EscreverLerInt("Notas de 50:");
            Caixa.DepositarNotas(50, quantidade);

            quantidade = EscreverLerInt("Notas de 20:");
            Caixa.DepositarNotas(20, quantidade);

            quantidade = EscreverLerInt("Notas de 10:");
            Caixa.DepositarNotas(10, quantidade);

            quantidade = EscreverLerInt("Notas de 5:");
            Caixa.DepositarNotas(5, quantidade);

            quantidade = EscreverLerInt("Notas de 2:");
            Caixa.DepositarNotas(2, quantidade);

            Escrever("Deposito efetuado com sucesso!");
            AguardarTecla("Aperte qualquer tecla para voltar.");
        }

        /// <summary>
        /// Tela para realizacao de saques
        /// </summary>
        private void Sacar()
        {
            LimparTela();

            int valor = default(int);

            Escrever(Caixa.RetornarNotasDisponiveis());

            valor = EscreverLerInt("Informe o valor que deseja sacar - 0 para voltar");

            if(valor == 0)
            {
                return;
            }
            else if(valor < 0) 
            {
                Escrever("Valor invalido.");
                AguardarTecla("Aperte qualque tecla para voltar.");
                return;
            }
            else if(valor > Caixa.RetornarSaldo()) 
            {
                Escrever("Saldo insuficiente.");
                AguardarTecla("Aperte qualque tecla para voltar.");
                return;
            }
            else 
            {

                int valorAux = valor;

                int quantidadeNotasCinquenta = default(int);
                int quantidadeNotasVinte = default(int);
                int quantidadeNotasDez = default(int);
                int quantidadeNotasCinco = default(int);
                int quantidadeNotasDois = default(int);

                if(Caixa.NotaCinquenta != 0) 
                {
                    quantidadeNotasCinquenta = (valorAux / 50);
                    valorAux -= quantidadeNotasCinquenta * 50;
                }
                
                if(Caixa.NotaVinte != 0) 
                {
                    quantidadeNotasVinte = (valorAux / 20);
                    valorAux -= quantidadeNotasVinte * 20;
                }
                
                if(Caixa.NotaDez != 0) 
                {
                    quantidadeNotasDez = (valorAux / 10);
                    valorAux -= quantidadeNotasDez * 10;
                }
                
                if(Caixa.NotaCinco != 0)
                {
                    quantidadeNotasCinco = (valorAux / 5);
                    valorAux -= quantidadeNotasCinco * 5;
                }
                
                if(Caixa.NotaDois != 0)
                {
                    quantidadeNotasDois = (valorAux / 2);
                    valorAux -= quantidadeNotasDois * 2;
                }

                if(valorAux != 0)
                {
                    Escrever("Operacao nao pode ser efetuada.");
                    AguardarTecla("Aperte qualquer tecla para voltar.");
                    return;
                }
                else
                {
                    Caixa.SacarNotas(50, quantidadeNotasCinquenta);
                    Caixa.SacarNotas(20, quantidadeNotasVinte);
                    Caixa.SacarNotas(10, quantidadeNotasDez);
                    Caixa.SacarNotas(5, quantidadeNotasCinco);
                    Caixa.SacarNotas(2, quantidadeNotasDois);

                    Escrever("Saque efetuado com sucesso!");
                    Escrever($"50 - {quantidadeNotasCinquenta} | 20 - {quantidadeNotasVinte} | 10 - {quantidadeNotasDez} | 5 - {quantidadeNotasCinco} | 2 - {quantidadeNotasDois}");
                    AguardarTecla("Aperte qualquer tecla para voltar");
                    return;
                }
            }
        }

        /// <summary>
        /// Tela para verificar saldo e quatidade de notas disponiveis
        /// </summary>
        private void VerificarSaldo()
        {
            LimparTela();

            Escrever($"Saldo total {Caixa.RetornarSaldo()}");
            Escrever(Caixa.RetornarQuantidadeNotas());

            AguardarTecla("Aperte qualquer tecla para voltar.");
        }
    }
}