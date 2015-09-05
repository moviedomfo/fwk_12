using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;

namespace X.pro.a.BackEnd.BusinessEntities
{

    public class AutorizacionBECollection : Entities<AutorizacionBE>
    {


        
    }
    public class PautaProductoFechaTarifaBECollection : Entities<PautaProductoFechaTarifaBE>
    {


        
    }
    public class PautaProductoFechaBECollection : Entities<PautaProductoFechaBE>
    {


        
    }
    public class ProductoCatalogoBECollection : Entities<ProductoCatalogoBE>
    {


        
    }
    public class TarifaFichaBECollection : Entities<TarifaFichaBE>
    {


        
    }
    public class TelefonoLlamadorBECollection : Entities<TelefonoLlamadorBE>
    {


        
    }
    public class TelefonosBECollection : Entities<TelefonosBE>
    {


        
    }

    [XmlInclude(typeof(TelefonoPagadorBE)), Serializable]
    public class TelefonoPagadorBE : Entity
    {
        #region [Private Members]
        private int? mi_Id;

        private int? mi_IdOriginal;

        private int? mi_IdEmpresaTelefonica;

        private String msz_CodigoArea;

        private String msz_Numero;


        #endregion



        #region [Properties]

        #region [Id]
        [XmlElement(ElementName = "Id", DataType = "int")]
        public int? Id
        {
            get { return mi_Id; }
            set { mi_Id = value; }
        }
        #endregion

        #region [IdOriginal]
        [XmlElement(ElementName = "IdOriginal", DataType = "int")]
        public int? IdOriginal
        {
            get { return mi_IdOriginal; }
            set { mi_IdOriginal = value; }
        }
        #endregion

        #region [IdEmpresaTelefonica]
        [XmlElement(ElementName = "IdEmpresaTelefonica", DataType = "int")]
        public int? IdEmpresaTelefonica
        {
            get { return mi_IdEmpresaTelefonica; }
            set { mi_IdEmpresaTelefonica = value; }
        }
        #endregion

        #region [CodigoArea]
        [XmlElement(ElementName = "CodigoArea", DataType = "string")]
        public String CodigoArea
        {
            get { return msz_CodigoArea; }
            set { msz_CodigoArea = value; }
        }
        #endregion

        #region [Numero]
        [XmlElement(ElementName = "Numero", DataType = "string")]
        public String Numero
        {
            get { return msz_Numero; }
            set { msz_Numero = value; }
        }
        #endregion

        #endregion

        
    }



    [XmlInclude(typeof(AutorizacionBE)), Serializable]
    public class AutorizacionBE : Entity
    {
        #region [Private Members]
        private int? mi_IdAutorizacion;


        #endregion



        #region [Properties]

        #region [IdAutorizacion]
        [XmlElement(ElementName = "IdAutorizacion", DataType = "int")]
        public int? IdAutorizacion
        {
            get { return mi_IdAutorizacion; }
            set { mi_IdAutorizacion = value; }
        }
        #endregion

        #endregion

        
    }



    [XmlInclude(typeof(AutorizacionesBE)), Serializable]
    public class AutorizacionesBE : Entity
    {
        #region [Private Members]
        private AutorizacionBECollection m_AutorizacionBECollection = new AutorizacionBECollection();

        #endregion



        #region [Properties]

        #region [AutorizacionBECollection]
        public AutorizacionBECollection AutorizacionBECollection
        {
            get { return m_AutorizacionBECollection; }
            set { m_AutorizacionBECollection = value; }
        }
        #endregion
        #endregion

        
    }



    [XmlInclude(typeof(ReclamoBE)), Serializable]
    public class ReclamoBE : Entity
    {
        #region [Private Members]
        private int? mi_IdReclamo;

        private int? mi_IdPDCausa;

        private int? mi_IdPDSubCausa;

        private String msz_ComentarioReclamo;

        private int? mi_IdPACSituacion;

        private String msz_ComentarioResolucion;

        private String msz_Responsable;


        #endregion



        #region [Properties]

        #region [IdReclamo]
        [XmlElement(ElementName = "IdReclamo", DataType = "int")]
        public int? IdReclamo
        {
            get { return mi_IdReclamo; }
            set { mi_IdReclamo = value; }
        }
        #endregion

        #region [IdPDCausa]
        [XmlElement(ElementName = "IdPDCausa", DataType = "int")]
        public int? IdPDCausa
        {
            get { return mi_IdPDCausa; }
            set { mi_IdPDCausa = value; }
        }
        #endregion

        #region [IdPDSubCausa]
        [XmlElement(ElementName = "IdPDSubCausa", DataType = "int")]
        public int? IdPDSubCausa
        {
            get { return mi_IdPDSubCausa; }
            set { mi_IdPDSubCausa = value; }
        }
        #endregion

        #region [ComentarioReclamo]
        [XmlElement(ElementName = "ComentarioReclamo", DataType = "string")]
        public String ComentarioReclamo
        {
            get { return msz_ComentarioReclamo; }
            set { msz_ComentarioReclamo = value; }
        }
        #endregion

        #region [IdPACSituacion]
        [XmlElement(ElementName = "IdPACSituacion", DataType = "int")]
        public int? IdPACSituacion
        {
            get { return mi_IdPACSituacion; }
            set { mi_IdPACSituacion = value; }
        }
        #endregion

        #region [ComentarioResolucion]
        [XmlElement(ElementName = "ComentarioResolucion", DataType = "string")]
        public String ComentarioResolucion
        {
            get { return msz_ComentarioResolucion; }
            set { msz_ComentarioResolucion = value; }
        }
        #endregion

        #region [Responsable]
        [XmlElement(ElementName = "Responsable", DataType = "string")]
        public String Responsable
        {
            get { return msz_Responsable; }
            set { msz_Responsable = value; }
        }
        #endregion

        #endregion

        
    }



    [XmlInclude(typeof(PautaProductoFechaTarifaBE)), Serializable]
    public class PautaProductoFechaTarifaBE : Entity
    {
        #region [Private Members]
        private int? mi_IdPDTipoValorizacion;

        private int? mi_IdPTFTipoTarifa;

        private int? mi_IdPTFTipoValorTarifa;

        private Double? md_Valor;

        private int? mi_IdMValor;

        private String msz_NombreFactor;


        #endregion



        #region [Properties]

        #region [IdPDTipoValorizacion]
        [XmlElement(ElementName = "IdPDTipoValorizacion", DataType = "int")]
        public int? IdPDTipoValorizacion
        {
            get { return mi_IdPDTipoValorizacion; }
            set { mi_IdPDTipoValorizacion = value; }
        }
        #endregion

        #region [IdPTFTipoTarifa]
        [XmlElement(ElementName = "IdPTFTipoTarifa", DataType = "int")]
        public int? IdPTFTipoTarifa
        {
            get { return mi_IdPTFTipoTarifa; }
            set { mi_IdPTFTipoTarifa = value; }
        }
        #endregion

        #region [IdPTFTipoValorTarifa]
        [XmlElement(ElementName = "IdPTFTipoValorTarifa", DataType = "int")]
        public int? IdPTFTipoValorTarifa
        {
            get { return mi_IdPTFTipoValorTarifa; }
            set { mi_IdPTFTipoValorTarifa = value; }
        }
        #endregion

        #region [Valor]
        [XmlElement(ElementName = "Valor", DataType = "double")]
        public double? Valor
        {
            get { return md_Valor; }
            set { md_Valor = value; }
        }
        #endregion

        #region [IdMValor]
        [XmlElement(ElementName = "IdMValor", DataType = "int")]
        public int? IdMValor
        {
            get { return mi_IdMValor; }
            set { mi_IdMValor = value; }
        }
        #endregion

        #region [NombreFactor]
        [XmlElement(ElementName = "NombreFactor", DataType = "string")]
        public String NombreFactor
        {
            get { return msz_NombreFactor; }
            set { msz_NombreFactor = value; }
        }
        #endregion

        #endregion

        
    }



    [XmlInclude(typeof(PautaProductoFechaTarifasBE)), Serializable]
    public class PautaProductoFechaTarifasBE : Entity
    {
        #region [Private Members]
        private PautaProductoFechaTarifaBECollection m_PautaProductoFechaTarifaBECollection = new PautaProductoFechaTarifaBECollection();

        #endregion



        #region [Properties]

        #region [PautaProductoFechaTarifaBECollection]
        public PautaProductoFechaTarifaBECollection PautaProductoFechaTarifaBECollection
        {
            get { return m_PautaProductoFechaTarifaBECollection; }
            set { m_PautaProductoFechaTarifaBECollection = value; }
        }
        #endregion
        #endregion

        
    }



    [XmlInclude(typeof(PautaProductoFechaBE)), Serializable]
    public class PautaProductoFechaBE : Entity
    {
        #region [Private Members]
        private int? mi_Id;

        private int? mi_IdPautaProducto;

        private DateTime? mdt_FechaPublicacion;

        private Double? md_TarifaFinal;

        private Double? md_TarifaFinalNeto;

        private Double? md_TarifaAuditoria;

        private Double? md_TarifaPalabrasInformada;

        private int? mi_CantidadReal;

        private DateTime? mdt_FechaComprobante;

        private int? mi_IdProducto;

        private String msz_NroPedidoVentaSAP;

        private String msz_NroPedidoControlSAP;

        private String msz_NroPedidoNotaCDSAP;

        private String msz_NroPedidoNotaCDControlSAP;

        private PautaProductoFechaTarifasBE m_PautaProductoFechaTarifasBE = new PautaProductoFechaTarifasBE();

        #endregion



        #region [Properties]

        #region [Id]
        [XmlElement(ElementName = "Id", DataType = "int")]
        public int? Id
        {
            get { return mi_Id; }
            set { mi_Id = value; }
        }
        #endregion

        #region [IdPautaProducto]
        [XmlElement(ElementName = "IdPautaProducto", DataType = "int")]
        public int? IdPautaProducto
        {
            get { return mi_IdPautaProducto; }
            set { mi_IdPautaProducto = value; }
        }
        #endregion

        #region [FechaPublicacion]
        [XmlElement(ElementName = "FechaPublicacion", DataType = "dateTime")]
        public DateTime? FechaPublicacion
        {
            get { return mdt_FechaPublicacion; }
            set { mdt_FechaPublicacion = value; }
        }
        #endregion

        #region [TarifaFinal]
        [XmlElement(ElementName = "TarifaFinal", DataType = "double")]
        public double? TarifaFinal
        {
            get { return md_TarifaFinal; }
            set { md_TarifaFinal = value; }
        }
        #endregion

        #region [TarifaFinalNeto]
        [XmlElement(ElementName = "TarifaFinalNeto", DataType = "double")]
        public double? TarifaFinalNeto
        {
            get { return md_TarifaFinalNeto; }
            set { md_TarifaFinalNeto = value; }
        }
        #endregion

        #region [TarifaAuditoria]
        [XmlElement(ElementName = "TarifaAuditoria", DataType = "double")]
        public double? TarifaAuditoria
        {
            get { return md_TarifaAuditoria; }
            set { md_TarifaAuditoria = value; }
        }
        #endregion

        #region [TarifaPalabrasInformada]
        [XmlElement(ElementName = "TarifaPalabrasInformada", DataType = "double")]
        public double? TarifaPalabrasInformada
        {
            get { return md_TarifaPalabrasInformada; }
            set { md_TarifaPalabrasInformada = value; }
        }
        #endregion

        #region [CantidadReal]
        [XmlElement(ElementName = "CantidadReal", DataType = "int")]
        public int? CantidadReal
        {
            get { return mi_CantidadReal; }
            set { mi_CantidadReal = value; }
        }
        #endregion

        #region [FechaComprobante]
        [XmlElement(ElementName = "FechaComprobante", DataType = "dateTime")]
        public DateTime? FechaComprobante
        {
            get { return mdt_FechaComprobante; }
            set { mdt_FechaComprobante = value; }
        }
        #endregion

        #region [IdProducto]
        [XmlElement(ElementName = "IdProducto", DataType = "int")]
        public int? IdProducto
        {
            get { return mi_IdProducto; }
            set { mi_IdProducto = value; }
        }
        #endregion

        #region [NroPedidoVentaSAP]
        [XmlElement(ElementName = "NroPedidoVentaSAP", DataType = "string")]
        public String NroPedidoVentaSAP
        {
            get { return msz_NroPedidoVentaSAP; }
            set { msz_NroPedidoVentaSAP = value; }
        }
        #endregion

        #region [NroPedidoControlSAP]
        [XmlElement(ElementName = "NroPedidoControlSAP", DataType = "string")]
        public String NroPedidoControlSAP
        {
            get { return msz_NroPedidoControlSAP; }
            set { msz_NroPedidoControlSAP = value; }
        }
        #endregion

        #region [NroPedidoNotaCDSAP]
        [XmlElement(ElementName = "NroPedidoNotaCDSAP", DataType = "string")]
        public String NroPedidoNotaCDSAP
        {
            get { return msz_NroPedidoNotaCDSAP; }
            set { msz_NroPedidoNotaCDSAP = value; }
        }
        #endregion

        #region [NroPedidoNotaCDControlSAP]
        [XmlElement(ElementName = "NroPedidoNotaCDControlSAP", DataType = "string")]
        public String NroPedidoNotaCDControlSAP
        {
            get { return msz_NroPedidoNotaCDControlSAP; }
            set { msz_NroPedidoNotaCDControlSAP = value; }
        }
        #endregion

        #region [PautaProductoFechaTarifasBE]
        public PautaProductoFechaTarifasBE PautaProductoFechaTarifasBE
        {
            get { return m_PautaProductoFechaTarifasBE; }
            set { m_PautaProductoFechaTarifasBE = value; }
        }
        #endregion
        #endregion

        
    }



    [XmlInclude(typeof(PautaProductoFechasBE)), Serializable]
    public class PautaProductoFechasBE : Entity
    {
        #region [Private Members]
        private PautaProductoFechaBECollection m_PautaProductoFechaBECollection = new PautaProductoFechaBECollection();

        #endregion



        #region [Properties]

        #region [PautaProductoFechaBECollection]
        public PautaProductoFechaBECollection PautaProductoFechaBECollection
        {
            get { return m_PautaProductoFechaBECollection; }
            set { m_PautaProductoFechaBECollection = value; }
        }
        #endregion
        #endregion

        
    }



    [XmlInclude(typeof(ProductoCatalogoBE)), Serializable]
    public class ProductoCatalogoBE : Entity
    {
        #region [Private Members]
        private int? mi_IdProductoCatalogo;

        private int? mi_IdRubroClasificacion;

        private int? mi_Orden;

        private int? mi_IdEdicion;

        private PautaProductoFechasBE m_PautaProductoFechasBE = new PautaProductoFechasBE();

        #endregion



        #region [Properties]

        #region [IdProductoCatalogo]
        [XmlElement(ElementName = "IdProductoCatalogo", DataType = "int")]
        public int? IdProductoCatalogo
        {
            get { return mi_IdProductoCatalogo; }
            set { mi_IdProductoCatalogo = value; }
        }
        #endregion

        #region [IdRubroClasificacion]
        [XmlElement(ElementName = "IdRubroClasificacion", DataType = "int")]
        public int? IdRubroClasificacion
        {
            get { return mi_IdRubroClasificacion; }
            set { mi_IdRubroClasificacion = value; }
        }
        #endregion

        #region [Orden]
        [XmlElement(ElementName = "Orden", DataType = "int")]
        public int? Orden
        {
            get { return mi_Orden; }
            set { mi_Orden = value; }
        }
        #endregion

        #region [IdEdicion]
        [XmlElement(ElementName = "IdEdicion", DataType = "int")]
        public int? IdEdicion
        {
            get { return mi_IdEdicion; }
            set { mi_IdEdicion = value; }
        }
        #endregion

        #region [PautaProductoFechasBE]
        public PautaProductoFechasBE PautaProductoFechasBE
        {
            get { return m_PautaProductoFechasBE; }
            set { m_PautaProductoFechasBE = value; }
        }
        #endregion
        #endregion

        
    }



    [XmlInclude(typeof(ProductosCatalogoBE)), Serializable]
    public class ProductosCatalogoBE : Entity
    {
        #region [Private Members]
        private int? mi_IdCLAProductoCatalogoMIX;

        private int? mi_IdPPClaseProducto;

        private ProductoCatalogoBECollection m_ProductoCatalogoBECollection = new ProductoCatalogoBECollection();
        private Boolean? mb_EsLineaDestacada;


        #endregion



        #region [Properties]

        #region [IdCLAProductoCatalogoMIX]
        [XmlElement(ElementName = "IdCLAProductoCatalogoMIX", DataType = "int")]
        public int? IdCLAProductoCatalogoMIX
        {
            get { return mi_IdCLAProductoCatalogoMIX; }
            set { mi_IdCLAProductoCatalogoMIX = value; }
        }
        #endregion

        #region [IdPPClaseProducto]
        [XmlElement(ElementName = "IdPPClaseProducto", DataType = "int")]
        public int? IdPPClaseProducto
        {
            get { return mi_IdPPClaseProducto; }
            set { mi_IdPPClaseProducto = value; }
        }
        #endregion

        #region [ProductoCatalogoBECollection]
        public ProductoCatalogoBECollection ProductoCatalogoBECollection
        {
            get { return m_ProductoCatalogoBECollection; }
            set { m_ProductoCatalogoBECollection = value; }
        }
        #endregion
        #region [EsLineaDestacada]
        [XmlElement(ElementName = "EsLineaDestacada", DataType = "Boolean")]
        public Boolean? EsLineaDestacada
        {
            get { return mb_EsLineaDestacada; }
            set { mb_EsLineaDestacada = value; }
        }
        #endregion

        #endregion

        
    }



    [XmlInclude(typeof(TarifaFichaBE)), Serializable]
    public class TarifaFichaBE : Entity
    {
        #region [Private Members]
        private int? mi_IdPDTipoValorizacion;

        private int? mi_IdPTFTipoTarifa;

        private int? mi_IdPTFTipoValorTarifa;

        private Double? md_Valor;

        private int? mi_IdMValor;

        private String msz_NombreFactor;


        #endregion



        #region [Properties]

        #region [IdPDTipoValorizacion]
        [XmlElement(ElementName = "IdPDTipoValorizacion", DataType = "int")]
        public int? IdPDTipoValorizacion
        {
            get { return mi_IdPDTipoValorizacion; }
            set { mi_IdPDTipoValorizacion = value; }
        }
        #endregion

        #region [IdPTFTipoTarifa]
        [XmlElement(ElementName = "IdPTFTipoTarifa", DataType = "int")]
        public int? IdPTFTipoTarifa
        {
            get { return mi_IdPTFTipoTarifa; }
            set { mi_IdPTFTipoTarifa = value; }
        }
        #endregion

        #region [IdPTFTipoValorTarifa]
        [XmlElement(ElementName = "IdPTFTipoValorTarifa", DataType = "int")]
        public int? IdPTFTipoValorTarifa
        {
            get { return mi_IdPTFTipoValorTarifa; }
            set { mi_IdPTFTipoValorTarifa = value; }
        }
        #endregion

        #region [Valor]
        [XmlElement(ElementName = "Valor", DataType = "double")]
        public double? Valor
        {
            get { return md_Valor; }
            set { md_Valor = value; }
        }
        #endregion

        #region [IdMValor]
        [XmlElement(ElementName = "IdMValor", DataType = "int")]
        public int? IdMValor
        {
            get { return mi_IdMValor; }
            set { mi_IdMValor = value; }
        }
        #endregion

        #region [NombreFactor]
        [XmlElement(ElementName = "NombreFactor", DataType = "string")]
        public String NombreFactor
        {
            get { return msz_NombreFactor; }
            set { msz_NombreFactor = value; }
        }
        #endregion

        #endregion

        
    }



    [XmlInclude(typeof(TarifasFichaBE)), Serializable]
    public class TarifasFichaBE : Entity
    {
        #region [Private Members]
        private TarifaFichaBECollection m_TarifaFichaBECollection = new TarifaFichaBECollection();

        #endregion



        #region [Properties]

        #region [TarifaFichaBECollection]
        public TarifaFichaBECollection TarifaFichaBECollection
        {
            get { return m_TarifaFichaBECollection; }
            set { m_TarifaFichaBECollection = value; }
        }
        #endregion
        #endregion

        
    }



    [XmlInclude(typeof(FichaBE)), Serializable]
    public class FichaBE : Entity
    {
        #region [Private Members]
        private int? mi_IdClaProductoCatalogo;

        private DateTime? mdt_FechaPublicacion;

        private int? mi_Duracion;

        private Double? md_TarifaFinal;

        private Double? md_TarifaFinalNeto;

        private Double? md_TarifaAuditoria;

        private int? mi_IdProducto;

        private String msz_CodigoSubEdicionWeb;

        private String msz_NroPedidoVentaSAP;

        private String msz_NroPedidoControlSAP;

        private Boolean? mb_TieneFoto;

        private TarifasFichaBE m_TarifasFichaBE = new TarifasFichaBE();

        #endregion



        #region [Properties]

        #region [IdClaProductoCatalogo]
        [XmlElement(ElementName = "IdClaProductoCatalogo", DataType = "int")]
        public int? IdClaProductoCatalogo
        {
            get { return mi_IdClaProductoCatalogo; }
            set { mi_IdClaProductoCatalogo = value; }
        }
        #endregion

        #region [FechaPublicacion]
        [XmlElement(ElementName = "FechaPublicacion", DataType = "dateTime")]
        public DateTime? FechaPublicacion
        {
            get { return mdt_FechaPublicacion; }
            set { mdt_FechaPublicacion = value; }
        }
        #endregion

        #region [Duracion]
        [XmlElement(ElementName = "Duracion", DataType = "int")]
        public int? Duracion
        {
            get { return mi_Duracion; }
            set { mi_Duracion = value; }
        }
        #endregion

        #region [TarifaFinal]
        [XmlElement(ElementName = "TarifaFinal", DataType = "double")]
        public double? TarifaFinal
        {
            get { return md_TarifaFinal; }
            set { md_TarifaFinal = value; }
        }
        #endregion

        #region [TarifaFinalNeto]
        [XmlElement(ElementName = "TarifaFinalNeto", DataType = "double")]
        public double? TarifaFinalNeto
        {
            get { return md_TarifaFinalNeto; }
            set { md_TarifaFinalNeto = value; }
        }
        #endregion

        #region [TarifaAuditoria]
        [XmlElement(ElementName = "TarifaAuditoria", DataType = "double")]
        public double? TarifaAuditoria
        {
            get { return md_TarifaAuditoria; }
            set { md_TarifaAuditoria = value; }
        }
        #endregion

        #region [IdProducto]
        [XmlElement(ElementName = "IdProducto", DataType = "int")]
        public int? IdProducto
        {
            get { return mi_IdProducto; }
            set { mi_IdProducto = value; }
        }
        #endregion

        #region [CodigoSubEdicionWeb]
        [XmlElement(ElementName = "CodigoSubEdicionWeb", DataType = "string")]
        public String CodigoSubEdicionWeb
        {
            get { return msz_CodigoSubEdicionWeb; }
            set { msz_CodigoSubEdicionWeb = value; }
        }
        #endregion

        #region [NroPedidoVentaSAP]
        [XmlElement(ElementName = "NroPedidoVentaSAP", DataType = "string")]
        public String NroPedidoVentaSAP
        {
            get { return msz_NroPedidoVentaSAP; }
            set { msz_NroPedidoVentaSAP = value; }
        }
        #endregion

        #region [NroPedidoControlSAP]
        [XmlElement(ElementName = "NroPedidoControlSAP", DataType = "string")]
        public String NroPedidoControlSAP
        {
            get { return msz_NroPedidoControlSAP; }
            set { msz_NroPedidoControlSAP = value; }
        }
        #endregion

        #region [TieneFoto]
        [XmlElement(ElementName = "TieneFoto", DataType = "Boolean")]
        public Boolean? TieneFoto
        {
            get { return mb_TieneFoto; }
            set { mb_TieneFoto = value; }
        }
        #endregion

        #region [TarifasFichaBE]
        public TarifasFichaBE TarifasFichaBE
        {
            get { return m_TarifasFichaBE; }
            set { m_TarifasFichaBE = value; }
        }
        #endregion
        #endregion

        
    }



    [XmlInclude(typeof(TelefonoLlamadorBE)), Serializable]
    public class TelefonoLlamadorBE : Entity
    {
        #region [Private Members]
        private int? mi_Id;

        private String msz_CodigoPais;

        private String msz_CodigoArea;

        private String msz_Numero;

        private Boolean? mb_EstaBloqueado;

        private String msz_MedioBloqueo;


        #endregion



        #region [Properties]

        #region [Id]
        [XmlElement(ElementName = "Id", DataType = "int")]
        public int? Id
        {
            get { return mi_Id; }
            set { mi_Id = value; }
        }
        #endregion

        #region [CodigoPais]
        [XmlElement(ElementName = "CodigoPais", DataType = "string")]
        public String CodigoPais
        {
            get { return msz_CodigoPais; }
            set { msz_CodigoPais = value; }
        }
        #endregion

        #region [CodigoArea]
        [XmlElement(ElementName = "CodigoArea", DataType = "string")]
        public String CodigoArea
        {
            get { return msz_CodigoArea; }
            set { msz_CodigoArea = value; }
        }
        #endregion

        #region [Numero]
        [XmlElement(ElementName = "Numero", DataType = "string")]
        public String Numero
        {
            get { return msz_Numero; }
            set { msz_Numero = value; }
        }
        #endregion

        #region [EstaBloqueado]
        [XmlElement(ElementName = "EstaBloqueado", DataType = "Boolean")]
        public Boolean? EstaBloqueado
        {
            get { return mb_EstaBloqueado; }
            set { mb_EstaBloqueado = value; }
        }
        #endregion

        #region [MedioBloqueo]
        [XmlElement(ElementName = "MedioBloqueo", DataType = "string")]
        public String MedioBloqueo
        {
            get { return msz_MedioBloqueo; }
            set { msz_MedioBloqueo = value; }
        }
        #endregion

        #endregion

        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto TelefonoLlamadorBE apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>TelefonoLlamadorBE</returns>
        public static TelefonoLlamadorBE GetTelefonoLlamadorFromXml(String pXml)
        {
            return Entity.GetFromXml<TelefonoLlamadorBE>(pXml);
        }
        #endregion
    }



    [XmlInclude(typeof(TelefonosLlamadorBE)), Serializable]
    public class TelefonosLlamadorBE : Entity
    {
        #region [Private Members]
        private TelefonoLlamadorBECollection m_TelefonoLlamadorBECollection = new TelefonoLlamadorBECollection();

        #endregion



        #region [Properties]

        #region [TelefonoLlamadorBECollection]
        public TelefonoLlamadorBECollection TelefonoLlamadorBECollection
        {
            get { return m_TelefonoLlamadorBECollection; }
            set { m_TelefonoLlamadorBECollection = value; }
        }
        #endregion
        #endregion

        
    }



    [XmlInclude(typeof(DatosIVRBE)), Serializable]
    public class DatosIVRBE : Entity
    {
        #region [Private Members]
        private String msz_CodigoComercio;

        private String msz_CodigoAutorizacion;

        private String msz_NumeroCuotas;


        #endregion



        #region [Properties]

        #region [CodigoComercio]
        [XmlElement(ElementName = "CodigoComercio", DataType = "string")]
        public String CodigoComercio
        {
            get { return msz_CodigoComercio; }
            set { msz_CodigoComercio = value; }
        }
        #endregion

        #region [CodigoAutorizacion]
        [XmlElement(ElementName = "CodigoAutorizacion", DataType = "string")]
        public String CodigoAutorizacion
        {
            get { return msz_CodigoAutorizacion; }
            set { msz_CodigoAutorizacion = value; }
        }
        #endregion

        #region [NumeroCuotas]
        [XmlElement(ElementName = "NumeroCuotas", DataType = "string")]
        public String NumeroCuotas
        {
            get { return msz_NumeroCuotas; }
            set { msz_NumeroCuotas = value; }
        }
        #endregion

        #endregion

        
    }



    [XmlInclude(typeof(TelefonosBE)), Serializable]
    public class TelefonosBE : Entity
    {
        #region [Private Members]
        private String msz_A;

        private String msz_B;

        private String msz_C;


        #endregion



        #region [Properties]

        #region [A]
        [XmlElement(ElementName = "A", DataType = "string")]
        public String A
        {
            get { return msz_A; }
            set { msz_A = value; }
        }
        #endregion

        #region [B]
        [XmlElement(ElementName = "B", DataType = "string")]
        public String B
        {
            get { return msz_B; }
            set { msz_B = value; }
        }
        #endregion

        #region [C]
        [XmlElement(ElementName = "C", DataType = "string")]
        public String C
        {
            get { return msz_C; }
            set { msz_C = value; }
        }
        #endregion

        #endregion

        
    }



    [XmlInclude(typeof(ParamBE)), Serializable]
    public class ParamBE : Entity
    {
        #region [Private Members]
        private String msz_RUTCliente;

        private int? mi_Id;

        private int? mi_NroPauta;

        private int? mi_IdFormaPago;

        private int? mi_IdFormaPagoOriginal;

        private int? mi_IdMedioPago;

        private int? mi_IdMedioPagoOriginal;

        private DateTime? mdt_FechaSolicitud;

        private String msz_TextoAviso;

        private int? mi_IdPACFormatoAvisoClasificado;

        private String msz_Ordenamiento;

        private int? mi_CantidadReal;

        private int? mi_CantidadInformada;

        private int? mi_IdSujetoCliente;

        private int? mi_IdSujetoBeneficiario;

        private Double? md_TarifaFinal;

        private Double? md_TarifaFinalNeto;

        private Double? md_TarifaFinalNetoOriginal;

        private Double? md_TarifaAuditoria;

        private Double? md_TarifaPalabraInformada;

        private int? mi_IdMedioOperacional;

        private String msz_CodigoMedioOperacional;

        private int? mi_IdGrupoOperacional;

        private int? mi_IdPOCanalOperacional;

        private int? mi_IdPPEstado;

        private int? mi_IdPPEstadoOriginal;

        private Boolean? mb_VigenteAdPower;

        private Boolean? mb_EsProcesadoMasivo;

        private Boolean? mb_Vigente;

        private String msz_Observaciones;

        private String msz_UsuarioCreacion;

        private DateTime? mdt_FechaCreacion;

        private String msz_UsuarioUltimaModificacion;

        private DateTime? mdt_FechaUltimaModificacion;

        private int? mi_IdPFMotivoCuentaCorrienteEspecial;

        private int? mi_IdPFMotivoSinCargo;

        private int? mi_IdContratoComercial;

        private int? mi_FolioContratoComercial;

        private int? mi_IdSubContratoComercial;

        private int? mi_FolioSubContratoComercial;

        private int? mi_IdContratoComercialOriginal;

        private int? mi_FolioContratoComercialOriginal;

        private int? mi_IdSubContratoComercialOriginal;

        private int? mi_FolioSubContratoComercialOriginal;

        private String msz_ArchivoFisico;

        private String msz_ArchivoFisicoNoEditable;

        private int? mi_IdOrigenAviso;

        private String msz_ObservacionesCuentaCorrienteEspecial;

        private Double? md_TarifaValorInformado;

        private String msz_RutaArchivoFisico;

        private String msz_NombreArchivoLogico;

        private String msz_RutaArchivoFisicoNoEditable;

        private String msz_NombreArchivoLogicoNoEditable;

        private Double? md_ValorAnchoAviso;

        private int? mi_IdAnchoAviso;

        private Boolean? mb_EsUsuarioAutorizador;

        private int? mi_IdTipoComportamientoCanal;

        private int? mi_IdUnidadMedidaFisica;

        private Double? md_UnidadEquivalenteConvenio;

        private int? mi_IdPACTipoComprobanteSolicitado;

        private int? mi_IdPromocion;

        private String msz_ObservacionesEstadoRechazado;

        private String msz_IdFicha;

        private DateTime? mdt_FechaPrimeraPublicacion;

        private Boolean? mb_EsHorarioBajo;

        private int? mi_NroComprobanteBeneficiario;

        private int? mi_IdPACTipoComprobanteBeneficiario;

        private int? mi_IdSujetoAutorizador;

        private int? mi_IdIndicadorCME;

        private TelefonoPagadorBE m_TelefonoPagadorBE = new TelefonoPagadorBE();
        private AutorizacionesBE m_AutorizacionesBE = new AutorizacionesBE();
        private ReclamoBE m_ReclamoBE = new ReclamoBE();
        private ProductosCatalogoBE m_ProductosCatalogoBE = new ProductosCatalogoBE();
        private FichaBE m_FichaBE = new FichaBE();
        private TelefonosLlamadorBE m_TelefonosLlamadorBE = new TelefonosLlamadorBE();
        private DateTime? mdt_FechaHoraUltimoMomentoAprobacion;

        private int? mi_CantidadPublicaciones;

        private String msz_DescripcionAdPower;

        private int? mi_VersionAdPower;

        private String msz_LlaveExterna;

        private Boolean? mb_RequiereIdentificarFicha;

        private DatosIVRBE m_DatosIVRBE = new DatosIVRBE();
        private DateTime? mdt_FechaUltimaPublicacion;

        private TelefonosBECollection m_TelefonosBECollection = new TelefonosBECollection();

        #endregion



        #region [Properties]

        #region [RUTCliente]
        [XmlElement(ElementName = "RUTCliente", DataType = "string")]
        public String RUTCliente
        {
            get { return msz_RUTCliente; }
            set { msz_RUTCliente = value; }
        }
        #endregion

        #region [Id]
        [XmlElement(ElementName = "Id", DataType = "int")]
        public int? Id
        {
            get { return mi_Id; }
            set { mi_Id = value; }
        }
        #endregion

        #region [NroPauta]
        [XmlElement(ElementName = "NroPauta", DataType = "int")]
        public int? NroPauta
        {
            get { return mi_NroPauta; }
            set { mi_NroPauta = value; }
        }
        #endregion

        #region [IdFormaPago]
        [XmlElement(ElementName = "IdFormaPago", DataType = "int")]
        public int? IdFormaPago
        {
            get { return mi_IdFormaPago; }
            set { mi_IdFormaPago = value; }
        }
        #endregion

        #region [IdFormaPagoOriginal]
        [XmlElement(ElementName = "IdFormaPagoOriginal", DataType = "int")]
        public int? IdFormaPagoOriginal
        {
            get { return mi_IdFormaPagoOriginal; }
            set { mi_IdFormaPagoOriginal = value; }
        }
        #endregion

        #region [IdMedioPago]
        [XmlElement(ElementName = "IdMedioPago", DataType = "int")]
        public int? IdMedioPago
        {
            get { return mi_IdMedioPago; }
            set { mi_IdMedioPago = value; }
        }
        #endregion

        #region [IdMedioPagoOriginal]
        [XmlElement(ElementName = "IdMedioPagoOriginal", DataType = "int")]
        public int? IdMedioPagoOriginal
        {
            get { return mi_IdMedioPagoOriginal; }
            set { mi_IdMedioPagoOriginal = value; }
        }
        #endregion

        #region [FechaSolicitud]
        [XmlElement(ElementName = "FechaSolicitud", DataType = "dateTime")]
        public DateTime? FechaSolicitud
        {
            get { return mdt_FechaSolicitud; }
            set { mdt_FechaSolicitud = value; }
        }
        #endregion

        #region [TextoAviso]
        [XmlElement(ElementName = "TextoAviso", DataType = "string")]
        public String TextoAviso
        {
            get { return msz_TextoAviso; }
            set { msz_TextoAviso = value; }
        }
        #endregion

        #region [IdPACFormatoAvisoClasificado]
        [XmlElement(ElementName = "IdPACFormatoAvisoClasificado", DataType = "int")]
        public int? IdPACFormatoAvisoClasificado
        {
            get { return mi_IdPACFormatoAvisoClasificado; }
            set { mi_IdPACFormatoAvisoClasificado = value; }
        }
        #endregion

        #region [Ordenamiento]
        [XmlElement(ElementName = "Ordenamiento", DataType = "string")]
        public String Ordenamiento
        {
            get { return msz_Ordenamiento; }
            set { msz_Ordenamiento = value; }
        }
        #endregion

        #region [CantidadReal]
        [XmlElement(ElementName = "CantidadReal", DataType = "int")]
        public int? CantidadReal
        {
            get { return mi_CantidadReal; }
            set { mi_CantidadReal = value; }
        }
        #endregion

        #region [CantidadInformada]
        [XmlElement(ElementName = "CantidadInformada", DataType = "int")]
        public int? CantidadInformada
        {
            get { return mi_CantidadInformada; }
            set { mi_CantidadInformada = value; }
        }
        #endregion

        #region [IdSujetoCliente]
        [XmlElement(ElementName = "IdSujetoCliente", DataType = "int")]
        public int? IdSujetoCliente
        {
            get { return mi_IdSujetoCliente; }
            set { mi_IdSujetoCliente = value; }
        }
        #endregion

        #region [IdSujetoBeneficiario]
        [XmlElement(ElementName = "IdSujetoBeneficiario", DataType = "int")]
        public int? IdSujetoBeneficiario
        {
            get { return mi_IdSujetoBeneficiario; }
            set { mi_IdSujetoBeneficiario = value; }
        }
        #endregion

        #region [TarifaFinal]
        [XmlElement(ElementName = "TarifaFinal", DataType = "double")]
        public double? TarifaFinal
        {
            get { return md_TarifaFinal; }
            set { md_TarifaFinal = value; }
        }
        #endregion

        #region [TarifaFinalNeto]
        [XmlElement(ElementName = "TarifaFinalNeto", DataType = "double")]
        public double? TarifaFinalNeto
        {
            get { return md_TarifaFinalNeto; }
            set { md_TarifaFinalNeto = value; }
        }
        #endregion

        #region [TarifaFinalNetoOriginal]
        [XmlElement(ElementName = "TarifaFinalNetoOriginal", DataType = "double")]
        public double? TarifaFinalNetoOriginal
        {
            get { return md_TarifaFinalNetoOriginal; }
            set { md_TarifaFinalNetoOriginal = value; }
        }
        #endregion

        #region [TarifaAuditoria]
        [XmlElement(ElementName = "TarifaAuditoria", DataType = "double")]
        public double? TarifaAuditoria
        {
            get { return md_TarifaAuditoria; }
            set { md_TarifaAuditoria = value; }
        }
        #endregion

        #region [TarifaPalabraInformada]
        [XmlElement(ElementName = "TarifaPalabraInformada", DataType = "double")]
        public double? TarifaPalabraInformada
        {
            get { return md_TarifaPalabraInformada; }
            set { md_TarifaPalabraInformada = value; }
        }
        #endregion

        #region [IdMedioOperacional]
        [XmlElement(ElementName = "IdMedioOperacional", DataType = "int")]
        public int? IdMedioOperacional
        {
            get { return mi_IdMedioOperacional; }
            set { mi_IdMedioOperacional = value; }
        }
        #endregion

        #region [CodigoMedioOperacional]
        [XmlElement(ElementName = "CodigoMedioOperacional", DataType = "string")]
        public String CodigoMedioOperacional
        {
            get { return msz_CodigoMedioOperacional; }
            set { msz_CodigoMedioOperacional = value; }
        }
        #endregion

        #region [IdGrupoOperacional]
        [XmlElement(ElementName = "IdGrupoOperacional", DataType = "int")]
        public int? IdGrupoOperacional
        {
            get { return mi_IdGrupoOperacional; }
            set { mi_IdGrupoOperacional = value; }
        }
        #endregion

        #region [IdPOCanalOperacional]
        [XmlElement(ElementName = "IdPOCanalOperacional", DataType = "int")]
        public int? IdPOCanalOperacional
        {
            get { return mi_IdPOCanalOperacional; }
            set { mi_IdPOCanalOperacional = value; }
        }
        #endregion

        #region [IdPPEstado]
        [XmlElement(ElementName = "IdPPEstado", DataType = "int")]
        public int? IdPPEstado
        {
            get { return mi_IdPPEstado; }
            set { mi_IdPPEstado = value; }
        }
        #endregion

        #region [IdPPEstadoOriginal]
        [XmlElement(ElementName = "IdPPEstadoOriginal", DataType = "int")]
        public int? IdPPEstadoOriginal
        {
            get { return mi_IdPPEstadoOriginal; }
            set { mi_IdPPEstadoOriginal = value; }
        }
        #endregion

        #region [VigenteAdPower]
        [XmlElement(ElementName = "VigenteAdPower", DataType = "Boolean")]
        public Boolean? VigenteAdPower
        {
            get { return mb_VigenteAdPower; }
            set { mb_VigenteAdPower = value; }
        }
        #endregion

        #region [EsProcesadoMasivo]
        [XmlElement(ElementName = "EsProcesadoMasivo", DataType = "Boolean")]
        public Boolean? EsProcesadoMasivo
        {
            get { return mb_EsProcesadoMasivo; }
            set { mb_EsProcesadoMasivo = value; }
        }
        #endregion

        #region [Vigente]
        [XmlElement(ElementName = "Vigente", DataType = "Boolean")]
        public Boolean? Vigente
        {
            get { return mb_Vigente; }
            set { mb_Vigente = value; }
        }
        #endregion

        #region [Observaciones]
        [XmlElement(ElementName = "Observaciones", DataType = "string")]
        public String Observaciones
        {
            get { return msz_Observaciones; }
            set { msz_Observaciones = value; }
        }
        #endregion

        #region [UsuarioCreacion]
        [XmlElement(ElementName = "UsuarioCreacion", DataType = "string")]
        public String UsuarioCreacion
        {
            get { return msz_UsuarioCreacion; }
            set { msz_UsuarioCreacion = value; }
        }
        #endregion

        #region [FechaCreacion]
        [XmlElement(ElementName = "FechaCreacion", DataType = "dateTime")]
        public DateTime? FechaCreacion
        {
            get { return mdt_FechaCreacion; }
            set { mdt_FechaCreacion = value; }
        }
        #endregion

        #region [UsuarioUltimaModificacion]
        [XmlElement(ElementName = "UsuarioUltimaModificacion", DataType = "string")]
        public String UsuarioUltimaModificacion
        {
            get { return msz_UsuarioUltimaModificacion; }
            set { msz_UsuarioUltimaModificacion = value; }
        }
        #endregion

        #region [FechaUltimaModificacion]
        [XmlElement(ElementName = "FechaUltimaModificacion", DataType = "dateTime")]
        public DateTime? FechaUltimaModificacion
        {
            get { return mdt_FechaUltimaModificacion; }
            set { mdt_FechaUltimaModificacion = value; }
        }
        #endregion

        #region [IdPFMotivoCuentaCorrienteEspecial]
        [XmlElement(ElementName = "IdPFMotivoCuentaCorrienteEspecial", DataType = "int")]
        public int? IdPFMotivoCuentaCorrienteEspecial
        {
            get { return mi_IdPFMotivoCuentaCorrienteEspecial; }
            set { mi_IdPFMotivoCuentaCorrienteEspecial = value; }
        }
        #endregion

        #region [IdPFMotivoSinCargo]
        [XmlElement(ElementName = "IdPFMotivoSinCargo", DataType = "int")]
        public int? IdPFMotivoSinCargo
        {
            get { return mi_IdPFMotivoSinCargo; }
            set { mi_IdPFMotivoSinCargo = value; }
        }
        #endregion

        #region [IdContratoComercial]
        [XmlElement(ElementName = "IdContratoComercial", DataType = "int")]
        public int? IdContratoComercial
        {
            get { return mi_IdContratoComercial; }
            set { mi_IdContratoComercial = value; }
        }
        #endregion

        #region [FolioContratoComercial]
        [XmlElement(ElementName = "FolioContratoComercial", DataType = "int")]
        public int? FolioContratoComercial
        {
            get { return mi_FolioContratoComercial; }
            set { mi_FolioContratoComercial = value; }
        }
        #endregion

        #region [IdSubContratoComercial]
        [XmlElement(ElementName = "IdSubContratoComercial", DataType = "int")]
        public int? IdSubContratoComercial
        {
            get { return mi_IdSubContratoComercial; }
            set { mi_IdSubContratoComercial = value; }
        }
        #endregion

        #region [FolioSubContratoComercial]
        [XmlElement(ElementName = "FolioSubContratoComercial", DataType = "int")]
        public int? FolioSubContratoComercial
        {
            get { return mi_FolioSubContratoComercial; }
            set { mi_FolioSubContratoComercial = value; }
        }
        #endregion

        #region [IdContratoComercialOriginal]
        [XmlElement(ElementName = "IdContratoComercialOriginal", DataType = "int")]
        public int? IdContratoComercialOriginal
        {
            get { return mi_IdContratoComercialOriginal; }
            set { mi_IdContratoComercialOriginal = value; }
        }
        #endregion

        #region [FolioContratoComercialOriginal]
        [XmlElement(ElementName = "FolioContratoComercialOriginal", DataType = "int")]
        public int? FolioContratoComercialOriginal
        {
            get { return mi_FolioContratoComercialOriginal; }
            set { mi_FolioContratoComercialOriginal = value; }
        }
        #endregion

        #region [IdSubContratoComercialOriginal]
        [XmlElement(ElementName = "IdSubContratoComercialOriginal", DataType = "int")]
        public int? IdSubContratoComercialOriginal
        {
            get { return mi_IdSubContratoComercialOriginal; }
            set { mi_IdSubContratoComercialOriginal = value; }
        }
        #endregion

        #region [FolioSubContratoComercialOriginal]
        [XmlElement(ElementName = "FolioSubContratoComercialOriginal", DataType = "int")]
        public int? FolioSubContratoComercialOriginal
        {
            get { return mi_FolioSubContratoComercialOriginal; }
            set { mi_FolioSubContratoComercialOriginal = value; }
        }
        #endregion

        #region [ArchivoFisico]
        [XmlElement(ElementName = "ArchivoFisico", DataType = "string")]
        public String ArchivoFisico
        {
            get { return msz_ArchivoFisico; }
            set { msz_ArchivoFisico = value; }
        }
        #endregion

        #region [ArchivoFisicoNoEditable]
        [XmlElement(ElementName = "ArchivoFisicoNoEditable", DataType = "string")]
        public String ArchivoFisicoNoEditable
        {
            get { return msz_ArchivoFisicoNoEditable; }
            set { msz_ArchivoFisicoNoEditable = value; }
        }
        #endregion

        #region [IdOrigenAviso]
        [XmlElement(ElementName = "IdOrigenAviso", DataType = "int")]
        public int? IdOrigenAviso
        {
            get { return mi_IdOrigenAviso; }
            set { mi_IdOrigenAviso = value; }
        }
        #endregion

        #region [ObservacionesCuentaCorrienteEspecial]
        [XmlElement(ElementName = "ObservacionesCuentaCorrienteEspecial", DataType = "string")]
        public String ObservacionesCuentaCorrienteEspecial
        {
            get { return msz_ObservacionesCuentaCorrienteEspecial; }
            set { msz_ObservacionesCuentaCorrienteEspecial = value; }
        }
        #endregion

        #region [TarifaValorInformado]
        [XmlElement(ElementName = "TarifaValorInformado", DataType = "double")]
        public double? TarifaValorInformado
        {
            get { return md_TarifaValorInformado; }
            set { md_TarifaValorInformado = value; }
        }
        #endregion

        #region [RutaArchivoFisico]
        [XmlElement(ElementName = "RutaArchivoFisico", DataType = "string")]
        public String RutaArchivoFisico
        {
            get { return msz_RutaArchivoFisico; }
            set { msz_RutaArchivoFisico = value; }
        }
        #endregion

        #region [NombreArchivoLogico]
        [XmlElement(ElementName = "NombreArchivoLogico", DataType = "string")]
        public String NombreArchivoLogico
        {
            get { return msz_NombreArchivoLogico; }
            set { msz_NombreArchivoLogico = value; }
        }
        #endregion

        #region [RutaArchivoFisicoNoEditable]
        [XmlElement(ElementName = "RutaArchivoFisicoNoEditable", DataType = "string")]
        public String RutaArchivoFisicoNoEditable
        {
            get { return msz_RutaArchivoFisicoNoEditable; }
            set { msz_RutaArchivoFisicoNoEditable = value; }
        }
        #endregion

        #region [NombreArchivoLogicoNoEditable]
        [XmlElement(ElementName = "NombreArchivoLogicoNoEditable", DataType = "string")]
        public String NombreArchivoLogicoNoEditable
        {
            get { return msz_NombreArchivoLogicoNoEditable; }
            set { msz_NombreArchivoLogicoNoEditable = value; }
        }
        #endregion

        #region [ValorAnchoAviso]
        [XmlElement(ElementName = "ValorAnchoAviso", DataType = "double")]
        public double? ValorAnchoAviso
        {
            get { return md_ValorAnchoAviso; }
            set { md_ValorAnchoAviso = value; }
        }
        #endregion

        #region [IdAnchoAviso]
        [XmlElement(ElementName = "IdAnchoAviso", DataType = "int")]
        public int? IdAnchoAviso
        {
            get { return mi_IdAnchoAviso; }
            set { mi_IdAnchoAviso = value; }
        }
        #endregion

        #region [EsUsuarioAutorizador]
        [XmlElement(ElementName = "EsUsuarioAutorizador", DataType = "Boolean")]
        public Boolean? EsUsuarioAutorizador
        {
            get { return mb_EsUsuarioAutorizador; }
            set { mb_EsUsuarioAutorizador = value; }
        }
        #endregion

        #region [IdTipoComportamientoCanal]
        [XmlElement(ElementName = "IdTipoComportamientoCanal", DataType = "int")]
        public int? IdTipoComportamientoCanal
        {
            get { return mi_IdTipoComportamientoCanal; }
            set { mi_IdTipoComportamientoCanal = value; }
        }
        #endregion

        #region [IdUnidadMedidaFisica]
        [XmlElement(ElementName = "IdUnidadMedidaFisica", DataType = "int")]
        public int? IdUnidadMedidaFisica
        {
            get { return mi_IdUnidadMedidaFisica; }
            set { mi_IdUnidadMedidaFisica = value; }
        }
        #endregion

        #region [UnidadEquivalenteConvenio]
        [XmlElement(ElementName = "UnidadEquivalenteConvenio", DataType = "double")]
        public double? UnidadEquivalenteConvenio
        {
            get { return md_UnidadEquivalenteConvenio; }
            set { md_UnidadEquivalenteConvenio = value; }
        }
        #endregion

        #region [IdPACTipoComprobanteSolicitado]
        [XmlElement(ElementName = "IdPACTipoComprobanteSolicitado", DataType = "int")]
        public int? IdPACTipoComprobanteSolicitado
        {
            get { return mi_IdPACTipoComprobanteSolicitado; }
            set { mi_IdPACTipoComprobanteSolicitado = value; }
        }
        #endregion

        #region [IdPromocion]
        [XmlElement(ElementName = "IdPromocion", DataType = "int")]
        public int? IdPromocion
        {
            get { return mi_IdPromocion; }
            set { mi_IdPromocion = value; }
        }
        #endregion

        #region [ObservacionesEstadoRechazado]
        [XmlElement(ElementName = "ObservacionesEstadoRechazado", DataType = "string")]
        public String ObservacionesEstadoRechazado
        {
            get { return msz_ObservacionesEstadoRechazado; }
            set { msz_ObservacionesEstadoRechazado = value; }
        }
        #endregion

        #region [IdFicha]
        [XmlElement(ElementName = "IdFicha", DataType = "string")]
        public String IdFicha
        {
            get { return msz_IdFicha; }
            set { msz_IdFicha = value; }
        }
        #endregion

        #region [FechaPrimeraPublicacion]
        [XmlElement(ElementName = "FechaPrimeraPublicacion", DataType = "dateTime")]
        public DateTime? FechaPrimeraPublicacion
        {
            get { return mdt_FechaPrimeraPublicacion; }
            set { mdt_FechaPrimeraPublicacion = value; }
        }
        #endregion

        #region [EsHorarioBajo]
        [XmlElement(ElementName = "EsHorarioBajo", DataType = "Boolean")]
        public Boolean? EsHorarioBajo
        {
            get { return mb_EsHorarioBajo; }
            set { mb_EsHorarioBajo = value; }
        }
        #endregion

        #region [NroComprobanteBeneficiario]
        [XmlElement(ElementName = "NroComprobanteBeneficiario", DataType = "int")]
        public int? NroComprobanteBeneficiario
        {
            get { return mi_NroComprobanteBeneficiario; }
            set { mi_NroComprobanteBeneficiario = value; }
        }
        #endregion

        #region [IdPACTipoComprobanteBeneficiario]
        [XmlElement(ElementName = "IdPACTipoComprobanteBeneficiario", DataType = "int")]
        public int? IdPACTipoComprobanteBeneficiario
        {
            get { return mi_IdPACTipoComprobanteBeneficiario; }
            set { mi_IdPACTipoComprobanteBeneficiario = value; }
        }
        #endregion

        #region [IdSujetoAutorizador]
        [XmlElement(ElementName = "IdSujetoAutorizador", DataType = "int")]
        public int? IdSujetoAutorizador
        {
            get { return mi_IdSujetoAutorizador; }
            set { mi_IdSujetoAutorizador = value; }
        }
        #endregion

        #region [IdIndicadorCME]
        [XmlElement(ElementName = "IdIndicadorCME", DataType = "int")]
        public int? IdIndicadorCME
        {
            get { return mi_IdIndicadorCME; }
            set { mi_IdIndicadorCME = value; }
        }
        #endregion

        #region [TelefonoPagadorBE]
        public TelefonoPagadorBE TelefonoPagadorBE
        {
            get { return m_TelefonoPagadorBE; }
            set { m_TelefonoPagadorBE = value; }
        }
        #endregion
        #region [AutorizacionesBE]
        public AutorizacionesBE AutorizacionesBE
        {
            get { return m_AutorizacionesBE; }
            set { m_AutorizacionesBE = value; }
        }
        #endregion
        #region [ReclamoBE]
        public ReclamoBE ReclamoBE
        {
            get { return m_ReclamoBE; }
            set { m_ReclamoBE = value; }
        }
        #endregion
        #region [ProductosCatalogoBE]
        public ProductosCatalogoBE ProductosCatalogoBE
        {
            get { return m_ProductosCatalogoBE; }
            set { m_ProductosCatalogoBE = value; }
        }
        #endregion
        #region [FichaBE]
        public FichaBE FichaBE
        {
            get { return m_FichaBE; }
            set { m_FichaBE = value; }
        }
        #endregion
        #region [TelefonosLlamadorBE]
        public TelefonosLlamadorBE TelefonosLlamadorBE
        {
            get { return m_TelefonosLlamadorBE; }
            set { m_TelefonosLlamadorBE = value; }
        }
        #endregion
        #region [FechaHoraUltimoMomentoAprobacion]
        [XmlElement(ElementName = "FechaHoraUltimoMomentoAprobacion", DataType = "dateTime")]
        public DateTime? FechaHoraUltimoMomentoAprobacion
        {
            get { return mdt_FechaHoraUltimoMomentoAprobacion; }
            set { mdt_FechaHoraUltimoMomentoAprobacion = value; }
        }
        #endregion

        #region [CantidadPublicaciones]
        [XmlElement(ElementName = "CantidadPublicaciones", DataType = "int")]
        public int? CantidadPublicaciones
        {
            get { return mi_CantidadPublicaciones; }
            set { mi_CantidadPublicaciones = value; }
        }
        #endregion

        #region [DescripcionAdPower]
        [XmlElement(ElementName = "DescripcionAdPower", DataType = "string")]
        public String DescripcionAdPower
        {
            get { return msz_DescripcionAdPower; }
            set { msz_DescripcionAdPower = value; }
        }
        #endregion

        #region [VersionAdPower]
        [XmlElement(ElementName = "VersionAdPower", DataType = "int")]
        public int? VersionAdPower
        {
            get { return mi_VersionAdPower; }
            set { mi_VersionAdPower = value; }
        }
        #endregion

        #region [LlaveExterna]
        [XmlElement(ElementName = "LlaveExterna", DataType = "string")]
        public String LlaveExterna
        {
            get { return msz_LlaveExterna; }
            set { msz_LlaveExterna = value; }
        }
        #endregion

        #region [RequiereIdentificarFicha]
        [XmlElement(ElementName = "RequiereIdentificarFicha", DataType = "Boolean")]
        public Boolean? RequiereIdentificarFicha
        {
            get { return mb_RequiereIdentificarFicha; }
            set { mb_RequiereIdentificarFicha = value; }
        }
        #endregion

        #region [DatosIVRBE]
        public DatosIVRBE DatosIVRBE
        {
            get { return m_DatosIVRBE; }
            set { m_DatosIVRBE = value; }
        }
        #endregion
        #region [FechaUltimaPublicacion]
        [XmlElement(ElementName = "FechaUltimaPublicacion", DataType = "dateTime")]
        public DateTime? FechaUltimaPublicacion
        {
            get { return mdt_FechaUltimaPublicacion; }
            set { mdt_FechaUltimaPublicacion = value; }
        }
        #endregion

        #region [TelefonosBECollection]
        public TelefonosBECollection TelefonosBECollection
        {
            get { return m_TelefonosBECollection; }
            set { m_TelefonosBECollection = value; }
        }
        #endregion
        #endregion

        
    }



}