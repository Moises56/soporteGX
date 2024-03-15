using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomaink2bbtntooltip
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2bbtntooltip ()
      {
         domain["Primera"] = "First";
         domain["Anterior"] = "Previous";
         domain["Siguiente"] = "Next";
         domain["Última"] = "Last";
         domain["Listado"] = "List";
         domain["Actualizar"] = "Refresh";
         domain["Agregar"] = "New";
         domain["Ocultar Filtros"] = "HideFilters";
         domain["Mostrar Filtros"] = "ShowFilters";
         domain["Imprimir"] = "Print";
         domain["\"; title=\""] = "ToolTipText";
         domain["Soporte Técnico"] = "TechSupport";
         domain["Ayuda"] = "HelpHeader";
         domain["Cerrar"] = "Close";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return context.GetMessage( value, "") ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["First"] = "Primera";
            domainMap["Previous"] = "Anterior";
            domainMap["Next"] = "Siguiente";
            domainMap["Last"] = "Última";
            domainMap["List"] = "Listado";
            domainMap["Refresh"] = "Actualizar";
            domainMap["New"] = "Agregar";
            domainMap["HideFilters"] = "Ocultar Filtros";
            domainMap["ShowFilters"] = "Mostrar Filtros";
            domainMap["Print"] = "Imprimir";
            domainMap["ToolTipText"] = "\"; title=\"";
            domainMap["TechSupport"] = "Soporte Técnico";
            domainMap["Help"] = "Ayuda";
            domainMap["Close"] = "Cerrar";
         }
         return (string)domainMap[key] ;
      }

   }

}
