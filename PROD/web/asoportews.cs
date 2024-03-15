using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class asoportews : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("AriesCustom", true);
         initialize();
         if ( ! context.isAjaxRequest( ) )
         {
            GXSoapHTTPResponse.AppendHeader("Content-type", "text/xml;charset=utf-8");
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.Method), "get") == 0 )
         {
            if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapHTTPRequest.QueryString), "wsdl") == 0 )
            {
               GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
               GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
               GXSoapXMLWriter.WriteStartElement("definitions");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "test");
               GXSoapXMLWriter.WriteAttribute("xmlns:wsdlns", "test");
               GXSoapXMLWriter.WriteAttribute("xmlns:soap", "http://schemas.xmlsoap.org/wsdl/soap/");
               GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://schemas.xmlsoap.org/wsdl/");
               GXSoapXMLWriter.WriteAttribute("xmlns:tns", "test");
               GXSoapXMLWriter.WriteStartElement("types");
               GXSoapXMLWriter.WriteStartElement("schema");
               GXSoapXMLWriter.WriteAttribute("targetNamespace", "test");
               GXSoapXMLWriter.WriteAttribute("xmlns", "http://www.w3.org/2001/XMLSchema");
               GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
               GXSoapXMLWriter.WriteAttribute("elementFormDefault", "qualified");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "ArrayOfsdtSoporteID");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "0");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "unbounded");
               GXSoapXMLWriter.WriteAttribute("name", "sdtSoporteID");
               GXSoapXMLWriter.WriteAttribute("type", "tns:sdtSoporteID");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteAttribute("name", "sdtSoporteID");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteID");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:int");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS.SAVEDATOS");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Soporteid");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:int");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Hostname");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Serie");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Ipv4");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Mac");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Modelo");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Nombreusuario");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Nombredepartamento");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS.SAVEDATOSResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("name", "retval");
               GXSoapXMLWriter.WriteAttribute("type", "xsd:string");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS.LISTARSOPORTEID");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("element");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS.LISTARSOPORTEIDResponse");
               GXSoapXMLWriter.WriteStartElement("complexType");
               GXSoapXMLWriter.WriteStartElement("sequence");
               GXSoapXMLWriter.WriteElement("element", "");
               GXSoapXMLWriter.WriteAttribute("minOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("maxOccurs", "1");
               GXSoapXMLWriter.WriteAttribute("name", "Csdtsoporteid");
               GXSoapXMLWriter.WriteAttribute("type", "tns:ArrayOfsdtSoporteID");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS.SAVEDATOSSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:SoporteWS.SAVEDATOS");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS.SAVEDATOSSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:SoporteWS.SAVEDATOSResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS.LISTARSOPORTEIDSoapIn");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:SoporteWS.LISTARSOPORTEID");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("message");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS.LISTARSOPORTEIDSoapOut");
               GXSoapXMLWriter.WriteElement("part", "");
               GXSoapXMLWriter.WriteAttribute("name", "parameters");
               GXSoapXMLWriter.WriteAttribute("element", "tns:SoporteWS.LISTARSOPORTEIDResponse");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("portType");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWSSoapPort");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "SAVEDATOS");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"SoporteWS.SAVEDATOSSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"SoporteWS.SAVEDATOSSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "LISTARSOPORTEID");
               GXSoapXMLWriter.WriteElement("input", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"SoporteWS.LISTARSOPORTEIDSoapIn");
               GXSoapXMLWriter.WriteElement("output", "");
               GXSoapXMLWriter.WriteAttribute("message", "wsdlns:"+"SoporteWS.LISTARSOPORTEIDSoapOut");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("binding");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWSSoapBinding");
               GXSoapXMLWriter.WriteAttribute("type", "wsdlns:"+"SoporteWSSoapPort");
               GXSoapXMLWriter.WriteElement("soap:binding", "");
               GXSoapXMLWriter.WriteAttribute("style", "document");
               GXSoapXMLWriter.WriteAttribute("transport", "http://schemas.xmlsoap.org/soap/http");
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "SAVEDATOS");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "testaction/"+"ASOPORTEWS.SAVEDATOS");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("operation");
               GXSoapXMLWriter.WriteAttribute("name", "LISTARSOPORTEID");
               GXSoapXMLWriter.WriteElement("soap:operation", "");
               GXSoapXMLWriter.WriteAttribute("soapAction", "testaction/"+"ASOPORTEWS.LISTARSOPORTEID");
               GXSoapXMLWriter.WriteStartElement("input");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("output");
               GXSoapXMLWriter.WriteElement("soap:body", "");
               GXSoapXMLWriter.WriteAttribute("use", "literal");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteStartElement("service");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWS");
               GXSoapXMLWriter.WriteStartElement("port");
               GXSoapXMLWriter.WriteAttribute("name", "SoporteWSSoapPort");
               GXSoapXMLWriter.WriteAttribute("binding", "wsdlns:"+"SoporteWSSoapBinding");
               GXSoapXMLWriter.WriteElement("soap:address", "");
               GXSoapXMLWriter.WriteAttribute("location", "https://"+context.GetServerName( )+((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "")+context.GetScriptPath( )+"asoportews.aspx");
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.WriteEndElement();
               GXSoapXMLWriter.Close();
               return  ;
            }
            else
            {
               currSoapErr = (short)(-20000);
               currSoapErrmsg = "No SOAP request found. Call " + "https://" + context.GetServerName( ) + ((context.GetServerPort( )>0)&&(context.GetServerPort( )!=80)&&(context.GetServerPort( )!=443) ? ":"+StringUtil.LTrim( StringUtil.Str( (decimal)(context.GetServerPort( )), 6, 0)) : "") + context.GetScriptPath( ) + "asoportews.aspx" + "?wsdl to get the WSDL.";
            }
         }
         if ( currSoapErr == 0 )
         {
            GXSoapXMLReader.OpenRequest(GXSoapHTTPRequest);
            GXSoapXMLReader.ReadExternalEntities = 0;
            GXSoapXMLReader.IgnoreComments = 1;
            GXSoapError = GXSoapXMLReader.Read();
            while ( GXSoapError > 0 )
            {
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Envelope", 1) > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
               }
               if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Body", 1) > 0 )
               {
                  if (true) break;
               }
               GXSoapError = GXSoapXMLReader.Read();
            }
            if ( GXSoapError > 0 )
            {
               GXSoapError = GXSoapXMLReader.Read();
               if ( GXSoapError > 0 )
               {
                  this.SetPrefixesFromReader( GXSoapXMLReader);
                  currMethod = GXSoapXMLReader.Name;
                  if ( ( StringUtil.StringSearch( currMethod+"&", "SAVEDATOS&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        formatError = false;
                        sTagName = GXSoapXMLReader.Name;
                        if ( GXSoapXMLReader.IsSimple == 0 )
                        {
                           GXSoapError = GXSoapXMLReader.Read();
                           nOutParmCount = 0;
                           while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
                           {
                              readOk = 0;
                              readElement = false;
                              this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Soporteid") )
                              {
                                 AV9soporteID = (int)(Math.Round(NumberUtil.Val( GXSoapXMLReader.Value, "."), 18, MidpointRounding.ToEven));
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Hostname") )
                              {
                                 AV10hostName = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Serie") )
                              {
                                 AV11serie = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Ipv4") )
                              {
                                 AV12ipv4 = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Mac") )
                              {
                                 AV13mac = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Modelo") )
                              {
                                 AV14modelo = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Nombreusuario") )
                              {
                                 AV15nombreUsuario = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "Nombredepartamento") )
                              {
                                 AV16nombreDepartamento = GXSoapXMLReader.Value;
                                 readElement = true;
                                 if ( GXSoapError > 0 )
                                 {
                                    readOk = 1;
                                 }
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              if ( ! readElement )
                              {
                                 readOk = 1;
                                 GXSoapError = GXSoapXMLReader.Read();
                              }
                              nOutParmCount = (short)(nOutParmCount+1);
                              if ( ( readOk == 0 ) || formatError )
                              {
                                 context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                                 context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                                 GXSoapError = (short)(nOutParmCount*-1);
                              }
                           }
                        }
                     }
                  }
                  else if ( ( StringUtil.StringSearch( currMethod+"&", "LISTARSOPORTEID&", 1) > 0 ) || ( currSoapErr != 0 ) )
                  {
                     if ( currSoapErr == 0 )
                     {
                        AV24CsdtSoporteID = new GXBaseCollection<SdtsdtSoporteID>( context, "sdtSoporteID", "test");
                     }
                  }
                  else
                  {
                     currSoapErr = (short)(-20002);
                     currSoapErrmsg = "Wrong method called. Expected method: " + "SAVEDATOS,LISTARSOPORTEID";
                  }
               }
            }
            GXSoapXMLReader.Close();
         }
         if ( currSoapErr == 0 )
         {
            if ( GXSoapError < 0 )
            {
               currSoapErr = (short)(GXSoapError*-1);
               currSoapErrmsg = context.sSOAPErrMsg;
            }
            else
            {
               if ( GXSoapXMLReader.ErrCode > 0 )
               {
                  currSoapErr = (short)(GXSoapXMLReader.ErrCode*-1);
                  currSoapErrmsg = GXSoapXMLReader.ErrDescription;
               }
               else
               {
                  if ( GXSoapError == 0 )
                  {
                     currSoapErr = (short)(-20001);
                     currSoapErrmsg = "Malformed SOAP message.";
                  }
                  else
                  {
                     currSoapErr = 0;
                     currSoapErrmsg = "No error.";
                  }
               }
            }
         }
         if ( currSoapErr == 0 )
         {
            if ( ( StringUtil.StringSearch( currMethod+"&", "SAVEDATOS&", 1) > 0 ) || ( currSoapErr != 0 ) )
            {
               gxep_savedatos( ) ;
            }
            else if ( ( StringUtil.StringSearch( currMethod+"&", "LISTARSOPORTEID&", 1) > 0 ) || ( currSoapErr != 0 ) )
            {
               gxep_listarsoporteid( ) ;
            }
         }
         context.CloseConnections();
         sIncludeState = true;
         GXSoapXMLWriter.OpenResponse(GXSoapHTTPResponse);
         GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Envelope");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
         if ( ( StringUtil.StringSearch( currMethod+"&", "SAVEDATOS&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("SoporteWS.SAVEDATOSResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "test");
            if ( currSoapErr == 0 )
            {
               GXSoapXMLWriter.WriteElement("retval", "");
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         else if ( ( StringUtil.StringSearch( currMethod+"&", "LISTARSOPORTEID&", 1) > 0 ) || ( currSoapErr != 0 ) )
         {
            GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
            GXSoapXMLWriter.WriteStartElement("SoporteWS.LISTARSOPORTEIDResponse");
            GXSoapXMLWriter.WriteAttribute("xmlns", "test");
            if ( currSoapErr == 0 )
            {
               if ( AV24CsdtSoporteID != null )
               {
                  AV24CsdtSoporteID.writexml(GXSoapXMLWriter, "Csdtsoporteid", "[*:nosend]test", sIncludeState);
               }
            }
            else
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Fault");
               GXSoapXMLWriter.WriteElement("faultcode", "SOAP-ENV:Client");
               GXSoapXMLWriter.WriteElement("faultstring", currSoapErrmsg);
               GXSoapXMLWriter.WriteElement("detail", StringUtil.Trim( StringUtil.Str( (decimal)(currSoapErr), 10, 0)));
               GXSoapXMLWriter.WriteEndElement();
            }
            GXSoapXMLWriter.WriteEndElement();
            GXSoapXMLWriter.WriteEndElement();
         }
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         cleanup();
      }

      public asoportews( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("AriesCustom", true);
      }

      public asoportews( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         asoportews objasoportews;
         objasoportews = new asoportews();
         objasoportews.context.SetSubmitInitialConfig(context);
         objasoportews.initialize();
         Submit( executePrivateCatch,objasoportews);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((asoportews)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public void gxep_savedatos( )
      {
         /* SaveDatos Constructor */
         /*
            INSERT RECORD ON TABLE soporte

         */
         O4soporteID = A4soporteID;
         A4soporteID = AV9soporteID;
         A5hostName = AV10hostName;
         A9serie = AV11serie;
         A10ipv4 = AV12ipv4;
         A11mac = AV13mac;
         A12modelo = AV14modelo;
         A13nombreUsuario = AV15nombreUsuario;
         A14nombreDepartamento = AV16nombreDepartamento;
         /* Using cursor P002O2 */
         pr_default.execute(0, new Object[] {A5hostName, A9serie, A10ipv4, A11mac, A12modelo, A13nombreUsuario, A14nombreDepartamento});
         A4soporteID = P002O2_A4soporteID[0];
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("soporte");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         this.cleanup();
      }

      public void gxep_listarsoporteid( )
      {
         /* ListarSoporteID Constructor */
         /* Using cursor P002O3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A4soporteID = P002O3_A4soporteID[0];
            O4soporteID = A4soporteID;
            if ( A4soporteID == O4soporteID )
            {
               O4soporteID = A4soporteID;
               AV22sdtSoporteID = new SdtsdtSoporteID(context);
               AV22sdtSoporteID.gxTpr_Soporteid = A4soporteID;
               AV24CsdtSoporteID.Add(AV22sdtSoporteID, 0);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("soportews",pr_default);
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXSoapHTTPRequest = new GxSoapRequest(context) ;
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         GXSoapHTTPResponse = new GxHttpResponse(context) ;
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         currSoapErrmsg = "";
         currMethod = "";
         sTagName = "";
         AV10hostName = "";
         AV11serie = "";
         AV12ipv4 = "";
         AV13mac = "";
         AV14modelo = "";
         AV15nombreUsuario = "";
         AV16nombreDepartamento = "";
         AV24CsdtSoporteID = new GXBaseCollection<SdtsdtSoporteID>( context, "sdtSoporteID", "test");
         A5hostName = "";
         A9serie = "";
         A10ipv4 = "";
         A11mac = "";
         A12modelo = "";
         A13nombreUsuario = "";
         A14nombreDepartamento = "";
         P002O2_A4soporteID = new int[1] ;
         Gx_emsg = "";
         scmdbuf = "";
         P002O3_A4soporteID = new int[1] ;
         AV22sdtSoporteID = new SdtsdtSoporteID(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.asoportews__default(),
            new Object[][] {
                new Object[] {
               P002O2_A4soporteID
               }
               , new Object[] {
               P002O3_A4soporteID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXSoapError ;
      private short currSoapErr ;
      private short readOk ;
      private short nOutParmCount ;
      private int AV9soporteID ;
      private int GX_INS2 ;
      private int O4soporteID ;
      private int A4soporteID ;
      private string currSoapErrmsg ;
      private string currMethod ;
      private string sTagName ;
      private string Gx_emsg ;
      private string scmdbuf ;
      private bool readElement ;
      private bool formatError ;
      private bool sIncludeState ;
      private string AV10hostName ;
      private string AV11serie ;
      private string AV12ipv4 ;
      private string AV13mac ;
      private string AV14modelo ;
      private string AV15nombreUsuario ;
      private string AV16nombreDepartamento ;
      private string A5hostName ;
      private string A9serie ;
      private string A10ipv4 ;
      private string A11mac ;
      private string A12modelo ;
      private string A13nombreUsuario ;
      private string A14nombreDepartamento ;
      private GXXMLReader GXSoapXMLReader ;
      private GXXMLWriter GXSoapXMLWriter ;
      private GxSoapRequest GXSoapHTTPRequest ;
      private GxHttpResponse GXSoapHTTPResponse ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002O2_A4soporteID ;
      private int[] P002O3_A4soporteID ;
      private GXBaseCollection<SdtsdtSoporteID> AV24CsdtSoporteID ;
      private SdtsdtSoporteID AV22sdtSoporteID ;
   }

   public class asoportews__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002O2;
          prmP002O2 = new Object[] {
          new ParDef("@hostName",GXType.NVarChar,40,0) ,
          new ParDef("@serie",GXType.NVarChar,40,0) ,
          new ParDef("@ipv4",GXType.NVarChar,40,0) ,
          new ParDef("@mac",GXType.NVarChar,40,0) ,
          new ParDef("@modelo",GXType.NVarChar,40,0) ,
          new ParDef("@nombreUsuario",GXType.NVarChar,40,0) ,
          new ParDef("@nombreDepartamento",GXType.NVarChar,40,0)
          };
          Object[] prmP002O3;
          prmP002O3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P002O2", "INSERT INTO [soporte]([hostName], [serie], [ipv4], [mac], [modelo], [nombreUsuario], [nombreDepartamento]) VALUES(@hostName, @serie, @ipv4, @mac, @modelo, @nombreUsuario, @nombreDepartamento); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP002O2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P002O3", "SELECT [soporteID] FROM [soporte] ORDER BY [soporteID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002O3,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
