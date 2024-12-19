using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankIO.Exercicios.enumerador;
enum CoresBotao
{
    Azul,
    Vermelho,
    Verde
}

class Botao
{
    public String Texto { get; set; }
    public String Cor { get; set; }

    public void CriarBotao()
    {
        var btnCancelar = new Botao
        {
            Texto = "Cancelar",
            Cor = CoresBotao.Azul.ToString()
        };
    }
}