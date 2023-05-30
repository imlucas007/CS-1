namespace Aula10DB.Models;

class Cliente
{
    public int ClienteId { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Regiao { get; set; }
    public string CodigoPostal { get; set; }
    public string Pais { get; set; }
    public string Telefone { get; set; }

    public Cliente(int clienteid, string endereco, string cidade, string regiao, string codigopostal, string pais, string telefone)
    {
        ClienteId = clienteid;
        Endereco = endereco;
        Cidade = cidade;
        Regiao = regiao;
        CodigoPostal = codigopostal;
        Pais = pais;
        Telefone = telefone;
    }  
}
