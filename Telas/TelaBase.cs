using System;

namespace TrabBackEndFinal.Telas
{
    public class TelaBase
    {
        /// <summary>
        /// Método que escreve em tela as informações
        /// </summary>
        /// <param name="mensagem"></param>
        protected void Escrever(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        /// <summary>
        /// Método que retorna dado em formato string
        /// </summary>
        /// <returns></returns>
        protected string LerString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Metodo que retorna dados
        /// </summary>
        /// <returns></returns>
        protected int LerInt()
        {
            int retorno = 0;
            string mensagem = "";
            bool executando = true;
            do
            {
                if(!string.IsNullOrWhiteSpace(mensagem)) {
                    Escrever(mensagem);
                    mensagem = "";
                }

                try {
                    retorno = int.Parse(Console.ReadLine());
                    executando = false;
                }  
                catch  {
                    mensagem = "Opção inválida. Digite novamente.";
                }
            } while (executando);

            return retorno;
        }

        /// <summary>
        /// Limpa a tela
        /// </summary>
        protected void LimparTela()
        {
            Console.Clear();
        }

        /// <summary>
        /// Aguarda qualquer tela ser pressionada 
        /// </summary>
        protected void AguardarTecla()
        {
            Console.ReadKey();
        }

        protected void AguardarTecla(string mensagem)
        {
            Escrever(mensagem);

            AguardarTecla();
        }

        protected string EscreverLerString(string mensagem)
        {
            Escrever(mensagem);

            return LerString();
        }

        protected int EscreverLerInt(string mensagem)
        {
            Escrever(mensagem);

            return LerInt();
        }
    }
}