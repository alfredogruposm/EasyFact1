using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using rnd = EquimarFac.TimbradoFelWebService2015;

namespace EquimarFac.DAO
{
    class TimbradoFelWebService
    {
        public string usuario { get; set; }

        public string password { get; set; }

        public string cadenaXML { get; set; }

        public string referencia { get; set; }

        public string rutaXML { get; set; }

        //public string password { get; set; }

        //public string cadenaXML { get; set; }


        public string[] TimbrarCFD()
        {
            try
            {
                usuario = "DEMO111007FP9";
                password = "S%8teo33MY@";
                TimbradoFelWebService2015 felweb = new TimbradoFelWebService2015();
                string[] respuesta = new string[4];
                r = new EquimarFac.TimbradoFelWebService2015();
                
                cadenaXML="<?xml version=" + "1.0 " + " encoding=" + "UTF-8" + "? >" + cadenaXML;
                respuesta = coneccion.(usuario, password, cadenaXML);




                //En el proyecto se agrego una referencia de servicio apuntando al WS de Timbrado de FEL, a la cual se llamo TimbradoFelWebService2015
            //La URL es la siguiente.
            //https://timbrado.facturarenlinea.com/WSTFD.svc
            //Se instancia el WS de Timbrado.
            TimbradoFel2015.WSTFDClient client=new EquimarFac.TimbradoFel2015.WSTFDClient();
            //Se instancia la Respuesta del WS de Timbrado.
            TimbradoFel2015.RespuestaTFD RespuestaTimbrado_FEL = new EquimarFac.TimbradoFel2015.RespuestaTFD();

            //Se carga el XML desde archivo.
            XmlDocument DocumentoXML = new XmlDocument();
            //La direccion se sustituira dependiendo de donde se leera el XML.
            DocumentoXML.Load(cadenaXML);

            //Variable string que contiene el contenido del XML.
            string stringXML;
            stringXML = DocumentoXML.OuterXml;

            //Se realiza la petición al WebService, almacenando la respuesta en el objeto RespuestaTFD (RespuestaTimbrado_FEL)
            //Los parametros son usuario,password,cadenaXML,referencia
            //Los datos de acceso se deben solicitar a FEL.
                
            RespuestaTimbrado_FEL = client.TimbrarCFDI("DEMO010101000", "contraseñaDEMO", stringXML, referencia);

            //Obteniendo la respuesta se valida que haya sido exitosa.
            if (RespuestaTimbrado_FEL.CodigoRespuesta == "800")
            {
                ////Se limpia el TextBox
                //TextBox_RespuestaWS.Clear();
                RespuestaTimbrado_FEL.
                ////Muestro la información del timbre.
                //TextBox_RespuestaWS.Text = RespuestaTimbrado_FEL.Timbre.Estado + System.Environment.NewLine;
                //TextBox_RespuestaWS.Text += RespuestaTimbrado_FEL.Timbre.FechaTimbrado + System.Environment.NewLine;
                //TextBox_RespuestaWS.Text += RespuestaTimbrado_FEL.Timbre.NumeroCertificadoSAT + System.Environment.NewLine;
                //TextBox_RespuestaWS.Text += RespuestaTimbrado_FEL.Timbre.SelloCFD + System.Environment.NewLine;
                //TextBox_RespuestaWS.Text += RespuestaTimbrado_FEL.Timbre.SelloSAT + System.Environment.NewLine;
                //TextBox_RespuestaWS.Text += RespuestaTimbrado_FEL.Timbre.UUID + System.Environment.NewLine;
                
                //Guardo el XML timbrado.
                DocumentoXML.LoadXml(RespuestaTimbrado_FEL.XMLResultado);
                DocumentoXML.Save("C:\\XML\\Prueba_Timbrado.xml");
            }
            else
            {
                //Se limpia el TextBox
                TextBox_RespuestaWS.Clear();

                //Si la petición fue erronea muestro el error.
                TextBox_RespuestaWS.Text = RespuestaTimbrado_FEL.CodigoRespuesta + System.Environment.NewLine;
                TextBox_RespuestaWS.Text += RespuestaTimbrado_FEL.MensajeError + System.Environment.NewLine;
                TextBox_RespuestaWS.Text += RespuestaTimbrado_FEL.MensajeErrorDetallado + System.Environment.NewLine;
            }


                return respuesta;
            }
            catch(Exception Ex)
            {
                string[] respuesta = new string[4];
                respuesta[0]=Ex.ToString();
                return respuesta;
            }
        }

    }
}
