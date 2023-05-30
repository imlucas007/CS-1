namespace Aula10DB.Models;

class Pedido
{
    public int PedidoId { get; set; }
    public int EmpregadoId { get; set; }
    public string DataPedido { get; set; }
    public string Peso { get; set; }
    public int CodTransportadora { get; set; }
    public int PedidoClienteId { get; set; }

    public Pedido(int pedidoid, int empregadoid, string datapedido, string peso, int codtransportadora, int pedidoclienteid)
    {
        PedidoId = pedidoid;
        EmpregadoId = empregadoid;
        DataPedido = datapedido;
        Peso = peso;
        CodTransportadora = codtransportadora;
        PedidoClienteId = pedidoclienteid;
    }  
}